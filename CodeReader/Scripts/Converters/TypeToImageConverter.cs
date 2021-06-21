using CodeReader.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace CodeReader.Scripts.Converters
{
    public class TypeToImageConverter : IValueConverter
    {
        private static Dictionary<CodeComponentType, string> ComponentTypes { get; set; } = new Dictionary<CodeComponentType, string>
        {
            {CodeComponentType.AbstractClass, "pack://application:,,,/Images/abstractClass.png" },
            {CodeComponentType.Attribute, "pack://application:,,,/Images/attribute.png" },
            {CodeComponentType.Code, "pack://application:,,,/Images/braces.png" },
            {CodeComponentType.Class, "pack://application:,,,/Images/class.png" },
            {CodeComponentType.Delegate, "pack://application:,,,/Images/delegate.png" },
            {CodeComponentType.Enum, "pack://application:,,,/Images/enum.png" },
            {CodeComponentType.Event, "pack://application:,,,/Images/event.png" },
            {CodeComponentType.Indexer, "pack://application:,,,/Images/indexer.png" },
            {CodeComponentType.Interface, "pack://application:,,,/Images/interface.png" },
            {CodeComponentType.Method, "pack://application:,,,/Images/method.png" },
            {CodeComponentType.Namespace, "pack://application:,,,/Images/namespace.png" },
            {CodeComponentType.Property, "pack://application:,,,/Images/property.png" },
            {CodeComponentType.Struct, "pack://application:,,,/Images/struct.png" },
            {CodeComponentType.Variable, "pack://application:,,,/Images/variable.png" },
        };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            CodeComponentType type = (CodeComponentType)value;
               return ComponentTypes.FirstOrDefault(t => t.Key == type).Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string path = value.ToString();
            foreach (KeyValuePair<CodeComponentType, string> type in ComponentTypes)
            {
                if (type.Value == path)
                    return type.Key;
            }
            return null;
        }
    }
}
