﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Enhanced_Guild_Wars_2.User_Controls.Converter
{
    public class CopperStringConverter : IValueConverter
    {
        public object Convert(Object value, Type targetType, object parameter, CultureInfo culture)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
