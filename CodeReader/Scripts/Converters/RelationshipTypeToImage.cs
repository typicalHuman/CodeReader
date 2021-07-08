using CodeReader.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Data;
using CodeReader.Scripts.Extensions;

namespace CodeReader.Scripts.Converters
{
    public class RelationshipTypeToImage : IValueConverter
    {
        private static Dictionary<RelationshipType, string> RelationshipTypes { get; set; } = new Dictionary<RelationshipType, string>
        {
            {RelationshipType.Aggregation, "pack://application:,,,/Images/aggregation.png" },
            {RelationshipType.Association, "pack://application:,,,/Images/association.png" },
            {RelationshipType.Composition, "pack://application:,,,/Images/composition.png" },
            {RelationshipType.Dependency, "pack://application:,,,/Images/dependency.png" },
            {RelationshipType.Inheritance, "pack://application:,,,/Images/inheritance.png" }
        };

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return this.GetSourceByEnumValue(value, RelationshipTypes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return this.GetEnumValueBySource(value, RelationshipTypes);
        }
    }
}
