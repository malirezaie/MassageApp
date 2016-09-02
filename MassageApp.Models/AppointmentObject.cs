using System;
namespace MassageApp.Models
{
	public class AppointmentObject
	{
		public string addressLineOne;
		public string addresLineTwo;
		public int appointmentID;
		public string date;
		public string dayOfWeek;
		public string details;
		public bool isExpand;
		public string month;
		public string time;
		public string title;
		public string total;

		public string therapistOneBio;
		public int therapistOneId;
		public string therapistOneName;
		public string therapistOnePhoto;
		public int therapistOneRated;
		public int therapistOneRating;

		public string therapistTwoBio;
		public int therapistTwoId;
		public string therapistTwoName;
		public string therapistTwoPhoto;
		public int therapistTwoRated;
		public int therapistTwoRating;



		//methods

		public AppointmentObject createCouplesConfirming;

		public AppointmentObject createCouplesPast;

		public AppointmentObject createSinglesConfirming;

		public AppointmentObject createSinglesPast;

	}
}

