using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ModernHttpClient;

namespace TimekitWrapper
{
	public class TimeKitClient
	{
		public static HttpClient _client;
		public string timekitAppString = "appmassage";

		// USED TO CREATE CLIENT TO GET USER
		public TimeKitClient()
		{
		}

		//password is API KEY for the CURRENT USER
		public TimeKitClient(string username, string password)
		{
			_client = new HttpClient(new NativeMessageHandler());

			_client.BaseAddress = new Uri("https://api.timekit.io/v2/");

			_client.DefaultRequestHeaders.TryAddWithoutValidation("Timekit-App", timekitAppString);

			var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

			_client.DefaultRequestHeaders.Authorization = authValue;

		}

		public async Task<User> CreateUserAsync(string firstname, string lastname, string _email)
		{
			var httpclient = new HttpClient();
			httpclient.DefaultRequestHeaders.TryAddWithoutValidation("Timekit-App", timekitAppString);

			var user = new User
			{
				first_name = firstname,
				last_name = lastname,
				email = _email
			};

			var json = JsonConvert.SerializeObject(user);

			var content = new StringContent(json, Encoding.UTF8, "application/json");


			var response = await httpclient.PostAsync("https://api.timekit.io/v2/users", content);


			if (response.IsSuccessStatusCode)
			{
				var raw = await response.Content.ReadAsStringAsync();

				JObject first = JObject.Parse(raw);
				user = JsonConvert.DeserializeObject<User>(first["data"].ToString());
			}

			return user;
		}

		public class TypeFilter { };
		public class AndFilter:TypeFilter{ public List<Filter> and;}
		public class OrFilter:TypeFilter{ public List<Filter> or;}

		// TYPE TRUE FOR AND, FALSE FOR OR
		public async Task<bool> PostFilterAsync(List<Filter> _and, bool type)
		{
			TypeFilter _fil;
			if (type)
			{
				_fil = new AndFilter { and = _and };
			}
			else
			{
				_fil = new OrFilter { or = _and };
			}

			var json = JsonConvert.SerializeObject(_fil);
			var content = new StringContent(json, Encoding.UTF8, "application/json");


			var response = await _client.PostAsync("findtime/filtercollections", content);

			//response.EnsureSuccessStatusCode();

			//var result = "";
			if (response.IsSuccessStatusCode)
			{
				//result = await response.Content.ReadAsStringAsync();
				return true;
			}

			return false;
		}



		public async Task<Calendar> PostCalendarAsync(Calendar _calendar)
		{

			var json = JsonConvert.SerializeObject(_calendar);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("calendars", content);

			var _Cal = new Calendar(_calendar.name, _calendar.description);

			if (response.IsSuccessStatusCode)
			{
				var raw = await response.Content.ReadAsStringAsync();

				JObject first = JObject.Parse(raw);
				_Cal = JsonConvert.DeserializeObject<Calendar>(first["data"].ToString());
			}

			return _Cal;

		}

	}
}
