using System;
using System.Collections.Generic;

namespace MassageApp.Provider.Model
{
	public class Request
	{

		static string TAG;

		public Address address;
		public Client client;
		public DateTime date;
		public string day;
		public string dayOfWeek;
		public int ID;
		public string month;
		public double price;
		public string sessionLength;
		public string summary;

		public List<Therapist> therapist;

		public string time;

		public string getTherapistPrice()
		{
			// therapise ID is equal to the current user ID
			foreach (var _therapist in therapist)
			{
				if (_therapist.ID == User.getCurrentUser().ID)
				{
					if (_therapist.payoutValue < 0)
					{
						return "TBD";
					}
					if (_therapist.payoutValue == 0)
					{
						return price.ToString();
					}
					else{
						return _therapist.payoutValue.ToString();
					}
				}
			}
			return "";
		}




	}
}