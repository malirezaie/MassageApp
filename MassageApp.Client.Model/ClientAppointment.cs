using System;


namespace MassageApp.Client.Model
{
	public class ClientAppointment
	{

		// static fields
		static string CLIENTAPPOINTMENT_PREFS_KEY = "clientappointmentkey";

		// instance fields 

		public Address address;

		public bool backToBack;

		public BillingLineItem billingLineItem;

		public string clientID;

		public string currency;

		public DateTime dateAndTime; //was calendar object

		public Discounts discounts;

		public string displayTime;

		public int ID;

		public bool isRepeat;

		public int Length;

		public string localPrice;

		public string localSessionPrice;

		public string localSubtotalPrice;

		public double price;

		public bool result;

		public bool reviewd;

		public SpecialRequests specialRequests;

		public string status;

		public bool confirmed;

		public string subtotalPrice;

		public string Summary;

		public Therapist therapists;

		public string type;


		// methods
		public static void deleteCurrentClientAppointment()
		{

			// DELETE client appt key from shared preferences/ keychain using CLIENTAPPOINTMENT_PREFS_KEY


		}

		public static ClientAppointment getCurrentClientAppointment()
		{

			// RETURN client appt key from shared preferences/ keychain using CLIENTAPPOINTMENT_PREFS_KEY 
			// AND PARSE STRING FROM JSON to ClientAppointment Object

			return new ClientAppointment();

		}

		public static void setCurrentClientAppointment(ClientAppointment client)
		{

			// SET client appt key from shared preferences/ keychain To ClientAppointment Object

		}

		public static int getID(){

			// GET client appt key from shared preferences/ keychain using CLIENTAPPOINTMENT_PREFS_KEY 
			// AND PARSE JSON and then get ID

			return 0; 
		}	

	}
}

