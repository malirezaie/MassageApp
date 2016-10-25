using System;
using Newtonsoft.Json;

namespace TimekitWrapper
{
	public class Calendar
	{
		public string name;
		public string description;
		public string id;
		public string provider_id;
		public string provider_access;
		public string provider_primary;

		[JsonIgnore]
		public string provider_sync;

		public Calendar(string _name, string _desc)
		{
			name = _name;
			description = _desc;
		}
	}
}
