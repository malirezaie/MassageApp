using System;
using System.Globalization;

namespace MassageApp.Provider.Model
{
	public class Availability
	{
		public Availability()
		{
		}

		public bool enabled;
		public Calendar end;
		public int ID;
		public Calendar start;


		public static int toDayOfWeek(string day)
		{
			//return either day to day of week integer... easy using DateTime
			return 1;
		}


	}
}

