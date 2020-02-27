using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceChecker
{
    public partial class frmAllotmentCheckerMain : Form
    {
        BackgroundWorker _wk;
        BO.HotelBO hbo;
        Objects.WebActionObject objGetHtml, objClick, objEnterData, objBrowse, objGetWebRoomTypes,
            objClickCmbRoomTypes;
        List<Models.Hotel> _selectedHotels = null;
        
        public void InitializeWorker()
        {
            if(_wk !=null)
            {
                _wk.Dispose();
            }
            _wk = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            _wk.ProgressChanged += _wk_ProgressChanged;
            _wk.DoWork += _wk_DoWork;
            _wk.RunWorkerCompleted += _wk_RunWorkerCompleted;
        }

        private void _wk_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtProgress.AppendText(Environment.NewLine + " All tasks completed");
            var reporter = new FrmCloseDateReport();
            reporter.Show();
        }

        private void _wk_DoWork(object sender, DoWorkEventArgs e)
        {
            RunCrawler();
        }
        void RunCrawler()
        {
            Models.WebAction actGetHtml, actClickSearch, actEnterData, actBrowse, actWebRoomTypes, 
                actClickCmbRoomTypes;
            var abo = new BO.ActionBO();
            actGetHtml = abo.GetAction(22);
            actClickSearch = abo.GetAction(21);
            actEnterData = abo.GetAction(20);          
            actBrowse = abo.GetAction(18);
            actWebRoomTypes = abo.GetAction(38);
            actClickCmbRoomTypes = abo.GetAction(39);
            objGetHtml = new Objects.WebActionObject(actGetHtml);
            objClick = new Objects.WebActionObject(actClickSearch);
            objEnterData = new Objects.WebActionObject(actEnterData);           
            objBrowse = new Objects.WebActionObject(actBrowse);
            objGetWebRoomTypes = new Objects.WebActionObject(actWebRoomTypes);
            objClickCmbRoomTypes = new Objects.WebActionObject(actClickCmbRoomTypes);
            objBrowse._wk = objGetHtml._wk = objEnterData._wk = objEnterData._wk = objClick._wk = _wk;
            foreach(var h in _selectedHotels)
            {
                if(string.IsNullOrEmpty(h.HMSID))
                {
                    MessageBox.Show("null or empty hmsId for hotel " + h.HotelName);
                }
            }
            for(int i=0;i<_selectedHotels.Count; i++)
            {
                if(_wk.CancellationPending)
                {
                    break;
                }
                CrawlSingleHotel(_selectedHotels[i]);
            }
            var bld = new StringBuilder();
            
            if (bld.Length > 0)
            {
                _wk.ReportProgress(0, Environment.NewLine +  bld.ToString());
                /* Nov 27: Text just not display 
                Console.WriteLine(bld.ToString());
                var viewer = new frmStringViewer(bld.ToString());
                viewer.Show();*/
            }
        }
        void CrawlSingleHotel(Models.Hotel h)
        {
            _wk.ReportProgress(0, "Crawl hotel " + h.HotelName);                   
            objBrowse._inputDatas["HMSID"] = h.HMSID;
            objBrowse.ExecuteAction(false);
            objGetWebRoomTypes.ExecuteAction(false);
            //Find out what room types are available
            var crTypes = h.ContractRooms.ToList();
            var opthtml = objGetWebRoomTypes._ReturnDataCollection["cmbRoomTypeInnerHtml"] as string;
            var rtdoc = new HtmlAgilityPack.HtmlDocument();
            
            rtdoc.LoadHtml(opthtml);
            var opts = rtdoc.DocumentNode.SelectNodes("//option");
            var rts = opts.Select(o => o.InnerText).ToList();
            foreach(var cr in crTypes)
            {
                if(!opts.Any(x=>x.InnerText== cr.RoomName))                    
                {                    
                    var editor = new frmRoomTypeReMatch(cr, rts);
                    if (editor.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            var validDate = h.ContractValidTo;
            if (validDate < DateTime.Now.Date)
            {
                return;
            }
            //here is the limit of HMS
            if (validDate > DateTime.Today.AddDays(365))
            {
                validDate = DateTime.Today.AddDays(365);
            }
            var fromDate = h.ContractValidFrom;
            var minDt = DateTime.UtcNow.Date.AddDays(h.MinCutOffDates);
            if (fromDate < minDt)
            {
                fromDate = minDt;
            }
            //reload room types to update
            var crbo = new BO.ContractRoomBO();
            crTypes = crbo.GetQueryable(h.HotelId).ToList();
            objEnterData._inputDatas["ToDate"] = validDate.ToString("MM/dd/yyyy");
            objEnterData._inputDatas["FromDate"] = fromDate.ToString("MM/dd/yyyy"); 
            objEnterData.ExecuteAction(false);
            foreach (var cr in crTypes)
            {               
                objClickCmbRoomTypes.ExecuteAction(false);
                /* We don't want to get text into XPath because it can causes err*/
                var cmbXPath = objGetWebRoomTypes._ActionData.ElementLabels.FirstOrDefault().XPath;
                cmbXPath += "/option";
                var elmOption = Modules.BrowserSupport.FindElementInCollection(cmbXPath, cr.RoomName);
                elmOption.Click();
                objClick.ExecuteAction(false);
                objGetHtml.ExecuteAction(false);
                var html = objGetHtml._ReturnDataCollection["PageHtml"] as string;
                var analyzer = new Modules.AllotmentAnalyzer(true);
                var records = analyzer.AnalyzeData(html);
                foreach (var record in records)
                {
                    var rbo = new BO.AllotmentRoomTypeBO();
                    var rtype = rbo.GetRecord(h.HotelId, record.RoomName);
                    if (rtype == null)
                    {
                        rtype = new Models.AllotmentRoomType();
                        rtype.RoomName = record.RoomName;
                        rtype.HotelId = h.HotelId;
                        rtype.DefaultAllotment = 1;
                        rbo.Add(rtype);
                    }
                    if (record.Allotment >= rtype.DefaultAllotment)
                    {
                        continue;
                    }
                    var arbo = new BO.AllotmentRecordBO();
                    //while record date is 12:00:00AM, saving in db will change it to 00:00:00
                    //so we never get the record. need to reset all to zero here
                    var dt = record.Date;
                    dt = new DateTime(dt.Year, dt.Month, dt.Day);

                    if (record.Allotment < rtype.DefaultAllotment)
                    {
                        var r = arbo.GetRecord(dt, rtype.RecordId);
                        if (r == null)
                        {
                            r = new Models.AllotmentRecord();
                            r.CurrentAllotment = record.Allotment;
                            r.AllotmentDate = dt;
                            r.Acknowledged = false;
                            r.AllotmentRoomTypeId = rtype.RecordId;
                            arbo.Add(r);
                        }
                        else
                        {
                            //REcord existed, may be acknowledged may be not. Just leave it there
                            if (record.Allotment < r.CurrentAllotment)
                            {
                                //Need to notify us again
                                r.Acknowledged = false;
                                arbo.Save();
                            }
                        }

                    }
                }
            }
            // var path = @"C:\Users\Thuy Tran\Documents\AllDocs\Disposable\Test\allotment" + h.HotelId + "-" + DateTime.Now.ToString("mm-dd-yyyy-hh-mm-ss") + ".txt";
            //System.IO.File.WriteAllText(path, html);
        }

        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            if(Modules.BrowserSupport.BrowserIsOpenned())
            {               
                    Modules.BrowserSupport.Quit();
             
            }
           
                Modules.BrowserSupport.OpenBrowser("Default");
          
        }

        private void frmAllotmentCheckerMain_Load(object sender, EventArgs e)
        {
           
            BindHotels();
        }

        private void cxAllHotels_CheckedChanged(object sender, EventArgs e)
        {
            if (cxAllHotels.Checked)
            {
                lstHotelList.Enabled = false;
            }
            else
            {
                lstHotelList.Enabled = true;             
                BindHotels();
            }
        }
        void BindHotels()
        {
            hbo = new BO.HotelBO();
            var hh = hbo.GetQueryable(null).Where(h => h.CheckAllotment).OrderBy(h=>h.HotelName).ToList();
            lstHotelList.DataSource = hh;
            lstHotelList.ClearSelected();
        }

        private void _wk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtProgress.AppendText(Environment.NewLine + e.UserState.ToString());
        }


        public frmAllotmentCheckerMain()
        {
            InitializeComponent();
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!Modules.BrowserSupport.BrowserIsOpenned())
            {
                MessageBox.Show("Open browser first and Login first");
                return;
            }
            if(cxAllHotels.Checked)
            {
                _selectedHotels = hbo.GetQueryable(null).Where(h => h.CheckAllotment).ToList();
            }
            else
            {              
                _selectedHotels = new List<Models.Hotel>();
                foreach(var item in lstHotelList.SelectedItems)
                {
                    _selectedHotels.Add((Models.Hotel)item);
                }
            }
            InitializeWorker();
            _wk.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(_wk!=null)
            {
                _wk.CancelAsync();
            }
        }
       
    }
}
