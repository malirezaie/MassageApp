using System;
namespace MassageApp.Client.Model
{
	public class User
	{

		//static fields

		static string TAG = "UserModel";
		static string USER_AUTH_KEY = "UserAuthKey";
		static string USER_PREFS_KEY = "AppCurrentUser";

		//instance fields

		//private int ERROR_CODE;

		public string lastName; 
		public bool client;
		public string country;
		public int credits;
		public string email;
		public string firstName;
		public string Id;
		public string inviteCode;
		public string inviteURL;
		public int minutes;
		public string phoneNumber;

		public string sessionToken;

		public bool subscribed;
		public int subscriptionTier;
		public string subscriptionTierName;
		public bool therapist;


		public User()
		{
			lastName = "";
			client = false;
			country = "CANADA";
			credits = 0;
			email = "";
			firstName = "";
			Id = "";
			inviteCode = "";
			inviteURL = "";
			minutes = 0;
			phoneNumber = "";

			sessionToken = "";

			subscribed = false;
			subscriptionTier = 0;
			subscriptionTierName = "";
			therapist = false;

		}

		// METHODS
		public User getCurrentUser()
		{

			// RETURN user key string from shared preferences/ keychain using USER_PREFS_KEY 
			// AND PARSE STRING FROM JSON to User Object

			return new User();

		}


		public int getCurrentUserId()
		{
			// RETURN user ID key from shared preferences/ keychain using USER_AUTH_KEY 
			return 0;

		}

		public string getTierName()
		{
			// RETURN SubScriptionTierName from GetCurrentUser()

			// if null return "NONE"

			return "";
		}

		public static bool isAuthenticated()
		{

			// if NO USER_AUTH_KEY exists, return false 

			return false;
		}

		public static bool isSubscribed()
		{

			// RETURN subscribed from GetCurrentUser()

			return false;
		}

		public static void setCurrentUser(User _user)
		{

			// SET user ID key in shared preferences/ keychain using _user param

		}



	}
}

