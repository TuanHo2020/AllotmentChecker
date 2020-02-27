using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PriceChecker.Modules
{
    public class Sleeepy
    {
        public static void SleepWithCheckIfCancel(TimeSpan totalSleep, TimeSpan checkFrequency, BackgroundWorker wk)
        {
            if (wk != null)
            {
                if (wk.CancellationPending)
                {
                    return;
                }
            }
            System.Threading.Thread.Sleep(checkFrequency);
            if (checkFrequency >= totalSleep)
            {
                return;
            }
            totalSleep = totalSleep.Subtract(checkFrequency);
            SleepWithCheckIfCancel(totalSleep, checkFrequency, wk);
        }
    }
}
