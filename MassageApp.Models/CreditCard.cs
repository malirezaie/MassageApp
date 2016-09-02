using System;

namespace MassageApp.Models
{
	public class CreditCard
	{

		//static fields

		public static string CARD_AUTH_KEY = "CardAuthKey";
		public static string CARD_BRAND_KEY = "CardBrandKey";
		public static string CARD_LAST_FOUR_AUTH_KEY = "CardLastFourAuthKey";


		//instance fields

		public int Id;
		public string lastFour;
		public string name;
		public string type;


		//JSON IGNORE
		public string getDefaultCreditCardBrand()
		{
			// get brand from shared preferences/ keychain using CARD_BRAND_KEY
			return "brand";
		}

		//JSON IGNORE
		public string getDefaultCreditCardId()
		{
			// get card ID preferences/ keychain using CARD_AUTH_KEY
			return "ID";
		}

		//JSON IGNORE
		public string getDefaultCreditCardLastFour()
		{
			// get last four from preferences/ keychain using CardLastFourAuthKey
			return "last4";
		}

		//JSON IGNORE
		public static bool hasDefaultCreditCard()
		{

			// check preferences/ keychain using CARD_AUTH_KEY for anything
			return false;
		}

		//JSON IGNORE
		public static bool hasDefaultCreditCardLastFour()
		{

			// check preferences/ keychain using CardLastFourAuthKey for anything
			return false;
		}

	}
}

