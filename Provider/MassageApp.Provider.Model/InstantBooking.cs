using System;
using System.Collections.Generic;
using System.Globalization;

namespace MassageApp.Provider.Model
{
	public class InstantBooking
	{
		public InstantBooking()
		{
		}

		static int DAYS_IN_WEEK = 7;
		static List<string> days = new List<string>{ "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

		static string TAG;

		//instance fields

		public bool active;
		public DateTime end; // OR Calendar
		public DateTime start; // OR Calendar

		public string getDayOfWeek(int dayOfWeek)
		{
			if (0 < dayOfWeek && dayOfWeek < 8)
				return days[dayOfWeek-1];
			else
				return "ERROR";
			
		}

		public int toDayOfWeek(string day)
		{
			return days.IndexOf(day);
		}

		public string getMonthAsString(int month)
		{
			string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul","Aug","Sep","Oct","Nov","Dec" };
			if (0 < month && month < 13)
				return months[month-1];
			else
				return "ERROR";

		}

		public string getTimesFormattedForApi(Calendar calendar)
		{
			// return to simple date format 
			return "";
		}

	}
}

