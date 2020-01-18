using PersonalData.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PersonalData.Convertors
{
	[ValueConversion(typeof(SexType), typeof(string))]
	public class SexEnumTypeToListConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
				return null;

			if (!value.GetType().IsEnum)
				return null;

			var enumValue = (SexType)value;

			switch (enumValue)
			{
				case SexType.Female:
					return "Ж";

				case SexType.Male:
					return "М";

				default: return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
