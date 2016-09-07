using System;
namespace MassageApp.Provider.Model
{
	public class Appointment
	{

		//static fields

		static string APPOINTMENT_ID;
		static string NEARBY_OFFER;
		static string OFFER_ID;
		static string SPECIAL_REQUEST;
		static string TAG;

		enum SECTIONS
		{
			CANCELLED,
			TODAY,
			UPCOMING
		}

		public Address address;
		public AppointmentRequest appointmentRequest;

		public string cancelledDate;
		public DateTime checkedInDate;
		public DateTime checkedOutDate;
		public Client client;
		public bool clientReviewed;

		public string date;
		public string distance
		{
			get
			{
				return distance + "km away";
			}

		}
		public string massageType;
		public Massage.MassageStatus status;
		public int ID;
		public bool is_rebook_for_you;
		public int length;
		public Request request;
		public string specialRequest;

		public Therapist therapist;
		public bool therapistReviewed;
		public string time;
		public string UTC;

		DateTime getUTCDateTime()
		{
			//return this.time as UTC
			return DateTime.UtcNow;
		}

		string Address()
		{
			return address.getAddress();
		}

		string getMassageTypeAndDuration()
		{

			return request.sessionLength + massageType + length;
		}

		string getMonth()
		{
			return "month";
		}

		string getTimeAndDay()
		{

			return "timeandday";
		}

		string getNamePlusAddress()
		{
			return "namePlusAddress";
		}

		string getRequestDate()
		{
			return "requestDate";
		}

		string getRequestSummaryPlusPostalCode()
		{
			return request.summary + request.address.postalCode;
		}

		public string getRequestTime()
		{
			return "requestTime";
		}

		/* // DONT KNOW THIS ONE
		public SECTIONS getSection()
		{
			

		}
		*/

		public bool isCancelled()
		{
			if (status == Massage.MassageStatus.CANCELLED)
				return true;
			else
				return false;		   
		}

		public bool isLive()
		{
			// return true if time is currently 
			// 20 mins before OR start time OR 30 mins after  
			// massage start time
			return true;
		}

	}
}

