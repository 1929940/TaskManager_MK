using System;
using System.Windows.Data;

namespace TaskManager
{
    public class DateConverter : IValueConverter
    {
        //Whenever the Deadline Date is set to null, 
        //it gets displayed in the datagrid as DateTime.MinValue
        //This ensures 'Empty' date fields, stay empty
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime)
            {
                if ((DateTime)value == DateTime.MinValue)
                {
                    return String.Empty;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Dont need to convert Back
            throw new NotImplementedException();
        }
    }
}
