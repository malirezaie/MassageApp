using System;
namespace MassageApp.Provider.Model
{
	public class Settings
	{
		public Settings()
		{
		}

		public string licenseExpirationDate;
		public string licenseNumber;
		public string licensePhotoURL;
		public string licenseProvince;
		public int massageCount;
		public int massagesUntilPayIncrease;
		public int payLevel;

		public bool prenatalMassage;
		public bool deepTissueMassage;
		public bool sportsMassage;
		public bool swedishMassage;

		public string totalEarned;
		public string totalUnpaid;


	}
}

