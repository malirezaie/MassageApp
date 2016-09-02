using System;

namespace MassageApp.Models
{
	public class Address
	{

		//static fields

		public static string ADDRESS_AUTH_KEY = "AddressAuthKey";
		public static string ADDRESS_CITY_ID_KEY = "AddressCityIDKey";
		public static string ADDRESS_NAME_LABEL = "AddressNameLabel";

		//instance fields

		public string aptNumber;
		public string city;
		public int cityId;
		public string instructions;
		public string province;
		public string street;
		public string postalCode;

		//methods

		//JSON IGNORE

		public static bool doesHaveSubscriptionForAddress()
		{
			//check for subscription @address 

			return false;
		}

		//JSON IGNORE
		public string getDefaultAddressCity()
		{
			// get defaultAddressCity from shared preferences/ keychain using AddressCityIDKey
			return "city";
		}

		//JSON IGNORE
		public int getDefaultAddressId()
		{
			// get defaultAddressID from shared preferences/ keychain using AddressAuthKey
			return 1;

		}

		//JSON IGNORE
		public string getDefaultAddressNameLabel()
		{
			// get defaultAddressNameLabel from shared preferences/ keychain using AddressNameLabel
			return "addressnamelabel";

		}

		//JSON IGNORE
		public bool hasDefaultAddress()
		{
			// check for address from shared preferences/ keychain using AddressAuthKey
			return false;

		}

	}
}