using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_Guild_Wars_2.Entities
{
    public class GoldSilverCopper
    {
        public int value { get; set; }
        public string gold { get; set; }
        public string silver { get; set; }
        public string copper { get; set; }

        public bool isNegative { get; set; }
        public string negativeSign { get; set; }

        public GoldSilverCopper(int value)
        {
            this.value = value;

            isValueNegative();

            this.gold = setGold(value);

            this.silver = setSilver(value);

            this.copper = setCopper(value);
        }

        public void isValueNegative()
        {
            if (this.value <= 0)
            {
                this.isNegative = true;

                this.negativeSign = "-";
            }
            else
            {
                this.isNegative = false;

                this.negativeSign = null;
            }
        }


        public string setGold(int value)
        {
            int v = value;

            if (isNegative)
            {
                v = value * -1;
            }

            string cost = v.ToString();

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
            int v = value;

            if (isNegative)
            {
                v = value * -1;
            }

            string cost = v.ToString();

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
            int v = value;

            if (isNegative)
            {
                v = value * -1;
            }

            string cost = v.ToString();

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
}
