using System;
namespace MassageApp.Provider.Model
{
	public class Massage
	{

		public string status;
		public string type;

		public enum MassageStatus
		{
			ACCEPTED, 
			CANCELLED,
			COMPLETE,
			COMPLETED,
			FILLED,
			PENDING,
			REVIEWED,
			SCHEDULED,
			TERMINATED,
			UNKNOWN
		}

		//dont know what to do here with regards to ENUM and string... 
		public enum MassageType
		{
			CHAIR,
			COUPLES,
			DEEP,
			CORPORATE,
			PRENATAL,
			SPORTS,
			SWEDISH,
			UNKNOWN
		}

		public string getStatus()
		{
			// return the correct MassageStatus.Status enum
			return "";
		}

		public string getType()
		{
			//return correct massagetype.type enum
			return "";
		}

	}
}

