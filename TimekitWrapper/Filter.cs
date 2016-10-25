using System;
namespace TimekitWrapper
{
	public class Filter
	{
		public Filter()
		{
		}

		public enum FilterType
		{
			business_hours, 
			only_weekend,
			exclude_weekend,
			specific_time,
			specific_day,
		}

	}
}
