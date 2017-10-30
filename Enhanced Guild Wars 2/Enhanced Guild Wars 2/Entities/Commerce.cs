using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_Guild_Wars_2.Entities
{
    public class Commerce
    {
        //--https://api.guildwars2.com/v2/commerce/prices/--ItemIdHere-
        //API Response
        public int id { get; set; }
        public bool whitelisted { get; set; }
        public Buys buys { get; set; }
        public Sells sells { get; set; }

        public int spread { get; set; }
        public double profit { get; set; }

        public string goldBuy { get; set; }
        public string goldSell { get; set; }
        public string goldSpread { get; set; }

        public string silverBuy { get; set; }
        public string silverSell { get; set; }
        public string silverSpread { get; set; }

        public string copperBuy { get; set; }
        public string copperSell { get; set; }
        public string copperSpread { get; set; }

        public void calculate()
        {
            getSpread();
            getProfit();
            setBuySellSpreadSubstrings();
        }

        public void getSpread()
        {
            this.spread = (int)(sells.unit_price * .85) - buys.unit_price;
        }

        public void getProfit()
        {            
            this.profit = (spread / (double)buys.unit_price);
        }

        public void setBuySellSpreadSubstrings()
        {
            this.goldBuy = setGold(this.buys.unit_price);
            this.goldSell = setGold(this.sells.unit_price);
            this.goldSpread = setGold(this.spread);

            this.silverBuy = setSilver(this.buys.unit_price);
            this.silverSell = setSilver(this.sells.unit_price);
            this.silverSpread = setSilver(this.spread);

            this.copperBuy = setCopper(this.buys.unit_price);
            this.copperSell = setCopper(this.sells.unit_price);
            this.copperSpread = setCopper(this.spread);
        }

        public string setGold(int value)
        {
            string cost = value.ToString();

            string reverseString = new string(cost.ToCharArray().Reverse().ToArray());

            int length = cost.Length;

            if (length > 4)
            {
                string substring = reverseString.Substring(4, (length - 4));

                return substring = new string(substring.ToCharArray().Reverse().ToArray());
            }
            else
            {
                return null;
            }
        }

        public string setSilver(int value)
        {
            string cost = value.ToString();

            string reverseString = new string(cost.ToCharArray().Reverse().ToArray());

            int length = cost.Length;

            if (length > 2)
            {
                string substring = "";

                if (length == 3)
                {
                    substring = reverseString.Substring(2, 1);
                }
                else
                {
                    substring = reverseString.Substring(2, 2);
                }

                return substring = new string(substring.ToCharArray().Reverse().ToArray());
            }
            else
            {
                return null;
            }
        }

        public string setCopper(int value)
        {
            string cost = value.ToString();

            string reverseString = new string(cost.ToCharArray().Reverse().ToArray());

            int length = cost.Length;

            if (length > 0)
            {
                string substring = "";

                if (length == 1)
                {
                    substring = reverseString.Substring(0, 1);
                }
                else
                {
                    substring = reverseString.Substring(0, 2);
                }

                return substring = new string(substring.ToCharArray().Reverse().ToArray());
            }
            else
            {
                return null;
            }
        }
    }

    public class Buys
    {
        public int quantity { get; set; }
        public int unit_price { get; set; }
    }

    public class Sells
    {
        public int quantity { get; set; }
        public int unit_price { get; set; }
    }
}
