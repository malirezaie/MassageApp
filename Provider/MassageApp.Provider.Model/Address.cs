using System;
namespace MassageApp.Provider.Model
{
	public class Address
	{

		static string TAG = "Addres";

		public string aptNumber = "apt_number";
		public string city;
		public string instructions;
		public string latitude;
		public string longitude;
		public string neighborhood;
		public string oilType = "oil_type";

		public string specialNeeds = "special_needs";
		public string province;
		public string street;
		public string postalCode;

		//methods
		public string getAddress()
		{
			//send back string with concat with pipe or whatever for address
			return "";
		}



	}
}

