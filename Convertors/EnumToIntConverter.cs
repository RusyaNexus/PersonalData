using System;
using System.Globalization;
using System.Windows.Data;

namespace PersonalData.Convertors
{
	public class EnumToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			if (!value.GetType().IsEnum)
				return null;


			return (int)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!targetType.IsEnum)
			{
				return null;
			}

			return Enum.ToObject(targetType, value);
		}
	}
}
