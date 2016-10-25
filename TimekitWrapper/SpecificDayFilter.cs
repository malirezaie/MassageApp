using System;
using System.Collections.Generic;
namespace TimekitWrapper
{
	public class SpecificDayFilter
	{
		public string day;
		List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

		public SpecificDayFilter(string _day)
		{
			day = days.Contains(_day) ? _day : "Monday";

		}
	}

	public class SpecDayObject : Filter
	{
		public SpecificDayFilter specific_day;

		public SpecDayObject(SpecificDayFilter _day)
		{
			specific_day = _day;
		}
	}

}
