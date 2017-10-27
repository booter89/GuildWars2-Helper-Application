using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enhanced_Guild_Wars_2.Routines
{
    public class Automation
    {
        public static void Test()
        {
            int num = 0;

            Process p = Process.GetProcessesByName("Excel").FirstOrDefault();
            if (p != null)
            {
                IntPtr h = p.MainWindowHandle;
                Utilities.GuildWars.SetForegroundWindow(h);
                System.Threading.Thread.Sleep(1000);
                Utilities.MouseActivity.LeftMouseClick(-1604, 711, 500);
                SendKeys.SendWait("k" + num.ToString());
                num++;
                System.Threading.Thread.Sleep(1000);
                Utilities.MouseActivity.LeftMouseClick(-1087, 544, 500);
                System.Threading.Thread.Sleep(1000);
                SendKeys.SendWait("s" + num.ToString());
            }
        }

        public static void PlaceBuyOrder()
        {

        }

        public static void PlaceSellOrder()
        {

        }

        public static void RemovedAllOrders()
        {

        }
    }
}
