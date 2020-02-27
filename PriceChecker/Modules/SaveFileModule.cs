using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceChecker.Modules
{
    public class SaveFileModule
    {
        public class CsvRecord
        {
            public string HotelName { get; set; }
            public string RoomName { get; set; }
            public DateTime CloseDate { get; set; }
            public bool Acknowledged { get; set; }

        }
        public static bool Save(List<CsvRecord> records)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Csv File (*.csv)|*.csv";
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            var fileName = dlg.FileName;
            using (var writer = new System.IO.StreamWriter(fileName))
            {
                using (var csv = new CsvHelper.CsvWriter(writer))
                {
                    csv.WriteRecords(records);
                }
            }
            return true;
        }
    }
}
