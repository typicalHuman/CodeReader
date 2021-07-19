﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace CodeReader.Scripts.Converters
{
    public class IsTextSameWithEnumValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values[0].ToString() == values[1].ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
