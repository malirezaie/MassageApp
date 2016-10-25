using System;
using System.Collections.Generic;

namespace TimekitWrapper
{
	public static class FilterCollection
	{

		public static List<Filter> MakeFilterCollection(List<SpecificTimeFilter> _st = null, List<SpecificDayFilter> _sd = null, List<SpecDayAndTimeFilter> _sdt = null)
		{

			List<Filter> filterList = new List<Filter>();

			if (_st != null)
			{
				foreach (var st in _st)
				{
					filterList.Add(st);
				}
			}
			if (_sd != null)
			{
				foreach (var sd in _sd)
				{
					filterList.Add(sd);
				}
			}
			if (_sdt != null)
			{

				foreach (var sdt in _sdt)
				{
					filterList.Add(sdt);
				}
			}

			return filterList;
		}
	}
}
