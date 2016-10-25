using System;
using System.Collections.Generic;

namespace TimekitWrapper
{
	public class SpecDayAndTimeFilter
	{
		public string day;
		public int start;
		public int end;
		List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

		public SpecDayAndTimeFilter(string _day, int _start, int _end)
		{
			if (_start > -1 && _end < 24 && _start < _end)
			{
				start = _start;
				end = _end;

				day = days.Contains(_day) ? _day : "Monday";

			}
			else {
				throw new Exception("invalid start and end times specified");
			}

		}
	}

	public class SpecDayTimeObject : Filter
	{
		public SpecDayAndTimeFilter specific_day_and_time;

		public SpecDayTimeObject(SpecDayAndTimeFilter _daytime)
		{
			specific_day_and_time = _daytime;
		}
	}


}
