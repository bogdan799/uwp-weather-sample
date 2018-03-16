using System;
using Windows.UI.Xaml.Data;

namespace Demo.Converter
{
    public sealed class DateTimeFormatConverter 
        : IValueConverter
    {
        public String Format { get; set; }

        public Object Convert(Object value, Type targetType, Object parameter, String language)
        {
            return (value as DateTime?)?.ToString(Format);
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, String language)
        {
            throw new NotImplementedException();
        }
    }
}
