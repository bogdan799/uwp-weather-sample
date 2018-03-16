using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Demo.Converter
{
    public sealed class StringFormatConverter : IValueConverter
    {
        public String Format { get; set; }

        public Object Convert(Object value, Type targetType, Object parameter, String language)
        {
            if (Format == null)
            {
                return value;
            }

            if (value == null || value == DependencyProperty.UnsetValue)
            {
                return null;
            }

            return String.Format(Format, value);
        }

        public Object ConvertBack(Object value, Type targetType, Object parameter, String language)
        {
            throw new NotImplementedException();
        }
    }
}
