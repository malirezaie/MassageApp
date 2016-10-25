using System;
using System.Net.Http;

namespace TimekitWrapper
{
	public class User
	{
		public User()
		{
			first_name = "";
			last_name = "";
			email = "";
			timezone = "Canada/Eastern";

		}

		public string first_name;
		public string last_name;
		public string email;
		public string timezone;
		public string passWord;
		public string image;
		public string created_at;
		public string updated_at;
		public string api_token;
		public string id;

	}
}
