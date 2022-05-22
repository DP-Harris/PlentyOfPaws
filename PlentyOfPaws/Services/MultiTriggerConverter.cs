using System;
using System.Globalization;
using Xamarin.Forms;

namespace PlentyOfPaws.Services
{
    // Used to verify all enters are filled before enable-ling the click of a button in multiple places throughout the application 
    public class MultiTriggerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((int)value > 0) // length > 0 ?
                return true;            // some data has been entered
            else
                return false;            // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
