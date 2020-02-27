using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace PriceChecker.Objects
{
    public class WebActionObject
    {
        public Models.WebAction _ActionData { get; set; }
        public BackgroundWorker _wk { get; set; }
        /// <summary>
        /// Use this to access error string incase we don't use worker
        /// </summary>
        public bool _ReportActionName { get; set; }
        public static int DefaultLabelWaitMiliseconds = 500;
        protected Objects.ErrorObject objLastError;
        /*     /// <summary>
             /// Set true if current action is executed inside another action and we want to restart the parent action
             /// </summary>
             public bool _OnErrorRestartUpper { get; set; }*/
        /// <summary>
        /// Use to pass data for auto formatting xpath. Other datas should be passed using unique
        /// variable for each class
        /// </summary>
        public Dictionary<string,object> _inputDatas;
        /// <summary>
        /// A collection of all label return data with key is label name
        /// </summary>       
        public Dictionary<string, object> _ReturnDataCollection { get; set; }

        public HtmlAgilityPack.HtmlNode _CurrentHtmlAgilityNodeParent { get; set; }

   //     public enumAction _action { get; set; }
      
        public WebActionObject(Models.WebAction a)
        {
            _ActionData = a;
            _ReportActionName = true;
            _ReturnDataCollection = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            _inputDatas = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /*This is a default execution of action, some actions may perform differently, like a complex action.
         * We should choose to override execute routine if possible to enable action test */
        public void ExecuteAction(bool reportLabel)
        {
            /* This is moved from constructor: We should launch browser when required only,
             * keep this inside constructor will make unable to access other function that doesnot require browser*/
            //  if (!Modules.BrowserSupport.BrowserIsOpenned() || !Modules.BrowserSupport._ProfileName.Equals(_user.ChromeProfile))
            if (!Modules.BrowserSupport.BrowserIsOpenned())
            {
                //  Modules.BrowserSupport.OpenBrowser(_user.ChromeProfile);
                Modules.BrowserSupport.OpenBrowser(null);
            }
            //The convert node happen repeated and don't need to be reported
            if (_wk != null && _ReportActionName)
            {
                _wk.ReportProgress(0, "Execute action " + _ActionData.ActionName);
            }
            try
            {
                //we handle errors here so to cover all overload method of innerexecuteaction
                InnerExecuteAction(reportLabel);
            }
            catch(MyExceptions.MyMyExceptions)
            {
                throw;
            }
            catch(OpenQA.Selenium.NoSuchElementException)
            {
                throw;
            }
            catch (Exception ex)
            {
                //we should make the error short for easy reading               
                if (objLastError == null)
                {
                    objLastError = new ErrorObject();
                    objLastError.ActionName = _ActionData.ActionName;
                }
                string message = "Error on action: " + _ActionData.ActionName + Environment.NewLine;
                if (objLastError.Label == null)
                {
                    message += "Label Null" + Environment.NewLine;
                }
                else
                {
                    message += "Label: " + objLastError.Label.LabelName + Environment.NewLine;
                }
                message += "Error Type: " + ex.GetType() + Environment.NewLine;               
                message += "Detail message: " + ex.ToString();
                _wk.ReportProgress(0,ex.ToString());
                //  FrmLabelNavigator nav = new FrmLabelNavigator(this, objLastError.Label, message);
                //   DialogResult dresult = nav.ShowDialog();
                DialogResult dresult = DialogResult.Yes;
                /* We supposed to execute manually in LabelNavigator, if success
                 * then we just continue everything, if not then break */                 
                if (dresult != DialogResult.Yes)
                {
                    //if the error is handle we don't need to add it to error collection                   
                    bool isRepeated = Global.CheckIfErrorRepeatedInAPeriod(objLastError, TimeSpan.FromMinutes(60));
                    Global.AddError(objLastError);
                    if (dresult == DialogResult.Abort)
                    {
                        throw new MyExceptions.ActionCanceledException("Action canceled by user");
                    }
                    else if (dresult == DialogResult.Ignore)//this case happens on auto close after some minutes
                    {
                        if (isRepeated)
                        {
                            if (ex is MyExceptions.LabelException)
                            {
                                throw new MyExceptions.LabelException(message);
                            }
                            else
                            {
                                //The exception is likely come from overload version of ExecuteRoutine
                                throw new MyExceptions.MyMyExceptions(message);
                            }
                        }
                    }
                }
            }
        }
        /* A routine can execute flawless but not get what we want, e.g node selected but not have value, or select nodes
         * return count = 0 so we
         * need to return a boolean to tell the action to stop, not throw error everywhere */
        /// <summary>
        /// Make this public so we can call directly to test on a routine. 
        /// </summary>
        /// <param name="routine"></param>
        /// <returns></returns>
        protected virtual void InnerExecuteAction(bool reportLabel)
        {           
            BO.ElementLabelBO elbo = new BO.ElementLabelBO();
            List<int> lblIds = elbo.GetQueryable(_ActionData.ActionId).OrderBy(l => l.LabelOrder).Select(l => l.LabelId).ToList();
            Objects.LabelObject objLabel;
            for (int i = 0; i < lblIds.Count; i++)
            {
                if(_wk!=null &&_wk.CancellationPending)
                {
                    break;
                }
                //well this should be enough to refresh data
                elbo = new BO.ElementLabelBO();
                var label = elbo.GetLabel(lblIds[i]);
                //In this case we use special wait not just sleep
                if (label.ExpectedBehavior != (int)WebElementBehavior.WaitForSomethingHappen)
                {
                    var sleep = label.WaitSeconds == 0 ? DefaultLabelWaitMiliseconds : label.WaitSeconds * 1000;
                    System.Threading.Thread.Sleep(sleep);
                }
                if (_wk != null && _wk.CancellationPending)
                {
                    break;
                }
                if (_wk != null && reportLabel)
                {
                    _wk.ReportProgress(0, "execute label \"" + label.LabelName + "\"");
                }
                objLabel = new LabelObject(label, this._inputDatas);
                objLabel._NodeParent = _CurrentHtmlAgilityNodeParent;
                objLabel._wk = _wk;
                try
                {
                    objLabel.ExecuteBehavior();
                    //do not wait by label.seconds because it is for behavior like waitforvisible etc
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (objLabel._ReturnData != null)
                    {
                        if(_ReturnDataCollection == null)
                        {
                            _ReturnDataCollection = new Dictionary<string, object>();
                        }
                          _ReturnDataCollection[objLabel._LabelData.ReturnDataKey] = objLabel._ReturnData;
                     
                    }
                }
                catch (MyExceptions.BreakRoutineIfFoundException)
                {
                    if (_wk != null)
                    {
                        _wk.ReportProgress(0, "Found label " + label.LabelName + ", break routine" + Environment.NewLine);
                    }
                    break;
                }
                catch (MyExceptions.BreakRoutineIfNOTFoundException)
                {
                    if (_wk != null)
                    {
                        _wk.ReportProgress(0, "Not found label " + label.LabelName + ", break routine" + Environment.NewLine);
                    }
                    break;
                }
                catch (Exception ex)
                {                   
                    //we should make the error short for easy reading
                    string message = "Error on action: " + _ActionData.ActionName + Environment.NewLine;
                    message += "Label: " + label.LabelName + Environment.NewLine;
                    message += "Label Error Type: " + ex.GetType() + Environment.NewLine;
                    message += "Detail message: " + ex.Message;
                    //if the error is handle we don't need to add it to error collection
                    objLastError = new ErrorObject();
                    objLastError.Label = label;
                    objLastError.ActionName = _ActionData.ActionName;
                    //we throw to handle the error upper so we can cover all overload method
                    throw;
                }
            }
        }
        public List<Objects.LabelObject> GetLabelObjects()
        {
            var lbo = new BO.ElementLabelBO();
            var lst = lbo.GetQueryable(_ActionData.ActionId).ToList();
            var objs = new List<Objects.LabelObject>();
            foreach (var lbl in lst)
            {
                objs.Add(new LabelObject(lbl, this._ReturnDataCollection));
            }
            return objs;
        }
    }
}
