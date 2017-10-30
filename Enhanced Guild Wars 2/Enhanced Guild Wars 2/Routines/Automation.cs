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

        public static void PlaceBuyOrder(string weaponName, int quantity)
        {
            //Click Home Tab
            Utilities.MouseActivity.LeftMouseClick(385, 95, 250);
            Utilities.MouseActivity.LeftMouseClick(385, 95, 250);

            //Click Buy Tab
            Utilities.MouseActivity.LeftMouseClick(550, 95, 250);
            Utilities.MouseActivity.LeftMouseClick(550, 95, 250);

            //Remove Filter
            Utilities.MouseActivity.LeftMouseClick(445, 165, 100);
            Utilities.MouseActivity.LeftMouseClick(445, 165, 100);

            //Click Into Search
            Utilities.MouseActivity.LeftMouseClick(70, 165, 250);
            Utilities.MouseActivity.LeftMouseClick(70, 165, 250);

            var word = weaponName.ToCharArray();
            foreach (Char w in word)
            {
                System.Windows.Forms.SendKeys.SendWait(w.ToString());
                System.Threading.Thread.Sleep(100);
            }

            System.Threading.Thread.Sleep(3000);
            //System.Windows.Forms.SendKeys.SendWait(weaponName);

            //Click First Result
            Utilities.MouseActivity.LeftMouseClick(625, 245, 500);
            Utilities.MouseActivity.LeftMouseClick(625, 245, 500);

            //Click First "Current Buyer" check box
            Utilities.MouseActivity.LeftMouseClick(240, 500, 750);
            Utilities.MouseActivity.LeftMouseClick(240, 500, 750);
            
            //System.Windows.Forms.SendKeys.SendWait(quantity.ToString());

            //Click Max. Price Copper and Increase By One
            Utilities.MouseActivity.LeftMouseClick(580, 275, 500);
            Utilities.MouseActivity.LeftMouseClick(580, 275, 500);

            //Click Quantity Text Box
            //Utilities.MouseActivity.LeftMouseClick(385, 240, 500);
            //Utilities.MouseActivity.LeftMouseClick(385, 240, 500);

            //Enter Buy Quantity
            int i = quantity;
            while (i > 0)
            {
                Utilities.MouseActivity.LeftMouseClick(410, 235, 100);
                System.Threading.Thread.Sleep(100);
                i--;
            }

            //Click Place Order
            Utilities.MouseActivity.LeftMouseClick(425, 375, 1000);

            //Close Item Panel
            Utilities.MouseActivity.LeftMouseClick(760, 125, 1000);
        }

        public static void PlaceSellOrder()
        {

        }

        public static void RemovedAllOrders()
        {

        }
    }
}
