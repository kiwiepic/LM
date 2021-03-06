﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CLM.Extensions
{
    public static class FormatProviderExtension
    {
        public static string FormatIt(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null) throw new ArgumentNullException("arg");
            if (arg.GetType() != typeof(int)) return arg.ToString();
            DateTime date = (DateTime)arg;
            switch (format)
            {
                case "mycustomformat":
                    switch (CultureInfo.CurrentCulture.Name)
                    {
                        case "en-GB":
                            return date.ToString("ddd dd MMM");
                        default:
                            return date.ToString("ddd MMM dd");
                    }
                default:
                    throw new FormatException();
            }
        }

        public static string ToString(this int d, IFormatProvider formatProvider, string format)
        {
            return FormatIt(format, d, formatProvider);
        }
    }
}
