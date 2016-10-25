using System;
using System.Collections.Generic;

namespace TimekitWrapper
{
	public class SpecificTimeFilter : Filter
	{

		public int start;
		public int end;
		public SpecificTimeFilter(int _start, int _end)
		{
			if (_start > -1 && _end < 24 && _start < _end)
			{
				start = _start;
				end = _end;
			}
			else {
				throw new Exception("invalid start and end times specified");
			}
		}
	}

	public class SpecTimeObject : Filter
	{
		public SpecificTimeFilter specific_time;

		public SpecTimeObject(SpecificTimeFilter _time)
		{
			specific_time = _time;
		}
	}
}
