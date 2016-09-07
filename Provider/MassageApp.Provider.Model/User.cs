namespace MassageApp.Provider.Model
{
	class User
	{

		static string TAG = "UserModel";
		static string USER_AUTH_KEY = "UserAuthKey";
		static string USER_AVATAR_URL = "TherapistAvatar";
		static string USER_PREFS_KEY = "SootheCurrentUser";
		static string USER_RATINGS_KEY = "SootheTherapistRating";
		static string USER_SPECIAL_REQUEST_COUNT_KEY = "SootheTherapistSpecialRequestCount";
		static string USER_SPECIAl_REQUEST_OOBE_COMPLETED = "SootheSpecialRequestOobe";




		public string lastName;
		public string avatarURL;
		public bool client;
		public string country;
		public int credits;
		public string email;
		public string firstName;
		public int ID;
		public bool insantAvailabilityQualified;
		public string inviteCode;
		public string inviteURL;
		public int minutes;
		public string rating;
		public string SESSION_TOKEN;
		public bool therapist;


		public static User getCurrentUser()
		{

			// USE THE USER_PREFS_KEY to get string from 
			// shared preferences / keychain and then JSON Parse
			// into a USER object

			return new User();
		}

		public int getCurrentUserID()
		{
			// USE THE USER_AUTH_KEY to get string from 
			// shared preferences / keychain and then JSON Parse
			// into a user ID
			return 0;
		}

		public static bool isAuthenticated()
		{
			// USE THE USER_AUTH_KEY to get string from 
			// shared preferences / keychain and then JSON Parse
			// IF Equal 0 return false ELSE return true
			return true;
		}

		public void setCurrentUser(User user)
		{

			// USE THE USER_PREFS_KEY to SET string  
			// shared preferences / keychain and then JSON Parse
			// FROM USER object parsed into JSON

		}

	}
}