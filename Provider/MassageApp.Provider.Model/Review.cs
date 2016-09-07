using System;
namespace MassageApp.Provider.Model
{
	public class Review
	{
		public Review()
		{
		}

		public Appointment appointment;
		public string body;
		public Client client;
		public int ID;
		public string success;
		public Therapist therapist;
		public bool therapistRequestedBlock;
		public int value;




	}
}

