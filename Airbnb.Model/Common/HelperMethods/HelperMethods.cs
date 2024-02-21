﻿using Airbnb.Model.Common.Enum;
using Airbnb.Model.CustomModels;
using MimeKit;
using System.Globalization;
using System.Web;

namespace Airbnb.Model.Common.HelperMethods
{
    public class HelperMethods
    {
        public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return Math.Round(6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1000);
        }

        public static string FormatePrice(decimal price, CultureInfo culture)
        {
            return string.Format(culture, "{0:C}", Math.Round(price).ToString("C", culture))?.Replace(".00", "")!;
        }
    }
}
