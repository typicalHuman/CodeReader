using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CodeReader.Scripts.Extensions
{
    public static class ConverterExtension
    {
        public static string GetSourceByEnumValue<T>(this IValueConverter conv, object value, Dictionary<T, string> sourceDictionary)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return string.Empty;
            T type = (T)value;
            return sourceDictionary.FirstOrDefault(t => t.Key.Equals(type)).Value;
        }

        public static T GetEnumValueBySource<T>(this IValueConverter conv, object value, Dictionary<T, string> sourceDictionary)
        {
            string path = value.ToString();
            foreach (KeyValuePair<T, string> type in sourceDictionary)
            {
                if (type.Value == path)
                    return type.Key;
            }
            return default(T);
        }
    }
}
