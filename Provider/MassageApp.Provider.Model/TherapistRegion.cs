using System;
using System.Collections.Generic;

namespace MassageApp.Provider.Model
{
	public class TherapistRegion
	{
		public TherapistRegion()
		{
		}

		public static string REGIONS_PREFS_KEY;

		public int appointmentID;
		public int ID;
		public int radius;
		public int regionActivities;

		public double regionLatitude;
		public double regionLongitude;

		public static List<TherapistRegion> getRegions()
		{

			List<TherapistRegion> regions;
			string SOOTHE_REGIONS = "SootheRegions";

			// get string from shared prefenences / keychain for "SOOTHE_REGIONS"
			// convert to List of Therapist Region 
			// USING JSON CONVERT of course
			regions = new List<TherapistRegion>();

			return regions;

		}

		public static void saveRegions(List<TherapistRegion> regions)
		{

			string SOOTHE_REGIONS = "SootheRegions";

			// convert to List of Therapist Region 
			// USING JSON CONVERT of course
			// SET string to shared prefenences / keychain for "SOOTHE_REGIONS"

		}

		// public Google.Android.gms.Location.GeoFence getGeoFence(){
		// 		in this method we will return a geofence object 
		//  	using the lat, long, and radius variables  
		// 		and ID of the therapist region
		// }



	}
}

