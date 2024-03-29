// Helpers/Settings.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MassageApp.Client.Model;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MassageApp.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
	public class Settings: INotifyPropertyChanged
	{

		static Settings settings;
		public static Settings Current
		{
			get { return settings ?? (settings = new Settings()); }
		}

		public static bool IsFirstStart()
		{
			// TODO: this is for the CURRENT USERID
			return Current.CurrentUser.firstName == "";
		}

		#region MOBILEAPPURL

		public const string MobileAppUrlKey = nameof(MobileAppUrlKey);
		public const string DefaultMobileAppUrl = "https://appmassage.azurewebsites.net/";
		public string MobileAppUrl
		{
			get { return AppSettings.GetValueOrDefault<string>(MobileAppUrlKey, DefaultMobileAppUrl); }

			set { AppSettings.AddOrUpdateValue<string>(MobileAppUrlKey, value); }
		}
	    
		#endregion

	    #region Setting Constants

	    private const string SettingsKey = "settings_key";
	    private static readonly string SettingsDefault = string.Empty;
		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		#endregion

		#region AUTH_STUFF

		public enum AuthOption
		{
			Facebook, Google
		}
		
		public AuthOption AuthenticationType
		{
			get { return AppSettings.GetValueOrDefault<AuthOption>(AuthenticationTypeKey, DefaultAuthType); }

			set
			{
				if (AppSettings.AddOrUpdateValue<AuthOption>(AuthenticationTypeKey, value))
				{
					OnPropertyChanged();
				}
			}
		}

		private const string AuthenticationTypeKey = nameof(AuthenticationTypeKey);
		public const AuthOption DefaultAuthType = AuthOption.Facebook;

		#endregion


		#region MassageAppUSER & Address

		private const string DefaultAddressKey = nameof(DefaultAddressKey);
		public const string DefaultAddress = "";

		public Address CurrentAddress
		{
			get { 
				
				string obj = AppSettings.GetValueOrDefault<string>(DefaultAddressKey, DefaultAddress);
				if (obj == "null" || obj == "")
				{
					return new Address();
				}

				return JsonConvert.DeserializeObject<Address>(obj);
			}
			set { 
				AppSettings.AddOrUpdateValue<string>(DefaultAddressKey, JsonConvert.SerializeObject(value)); 
			}
		}

		private const string CurrentUserIdKey = nameof(CurrentUserIdKey);
		public const string DefaultCurrentUserId = "";

		public User CurrentUser
		{
			get {
					string obj = AppSettings.GetValueOrDefault<string>(CurrentUserIdKey, DefaultCurrentUserId);
					if (obj == "null" || obj == "")
					{
						return new User();
					}

					return JsonConvert.DeserializeObject<User>(obj); 
				}
			set { 
					AppSettings.AddOrUpdateValue<string>(CurrentUserIdKey, JsonConvert.SerializeObject(value)); 
				}
		}

		#endregion


		#region STRIPE

		public const string CurrentCardIDKey = nameof(CurrentCardIDKey);

		public CreditCard CurrentCard
		{
			get
			{
				string obj = AppSettings.GetValueOrDefault<string>(CurrentCardIDKey, "");
				if (obj == "null" || obj == "")
				{
					return new CreditCard();
				}

				return JsonConvert.DeserializeObject<CreditCard>(obj);
			}

			set
			{
				AppSettings.AddOrUpdateValue<string>(CurrentCardIDKey, JsonConvert.SerializeObject(value));
			}
		}

		public const string AdditionalardIDKey = nameof(AdditionalardIDKey);

		public CreditCard AdditionalCard
		{
			get
			{
				string obj = AppSettings.GetValueOrDefault<string>(AdditionalardIDKey, "");
				if (obj == "null" || obj == "")
				{
					return new CreditCard();
				}

				return JsonConvert.DeserializeObject<CreditCard>(obj);
			}

			set
			{
				AppSettings.AddOrUpdateValue<string>(AdditionalardIDKey, JsonConvert.SerializeObject(value));
			}
		}

		public const string StripeAPIKeyID = nameof(StripeAPIKeyID);

		public string StripeApiKey
		{
			get { return AppSettings.GetValueOrDefault<string>(StripeAPIKeyID, ""); }

			set { AppSettings.AddOrUpdateValue<string>(StripeAPIKeyID, value); }
		}


		#endregion


		#region TIMEKIT
		public const string TimeKitUserKey = nameof(TimeKitUserKey);

		public TimekitWrapper.User TimeKitUser
		{
			get
			{
				string obj = AppSettings.GetValueOrDefault<string>(TimeKitUserKey, "");
				if (obj == "null" || obj == "")
				{
					return new TimekitWrapper.User();
				}

				return JsonConvert.DeserializeObject<TimekitWrapper.User>(obj);
			}

			set
			{
				AppSettings.AddOrUpdateValue<string>(TimeKitUserKey, JsonConvert.SerializeObject(value));
			}
		}

		public const string TimeKitCalendarKey = nameof(TimeKitCalendarKey);

		public TimekitWrapper.Calendar TimeKitCalendar
		{
			get
			{
				string obj = AppSettings.GetValueOrDefault<string>(TimeKitCalendarKey, "");
				if (obj == "null" || obj == "")
				{
					return new TimekitWrapper.Calendar("","Main Calendar");
				}

				return JsonConvert.DeserializeObject<TimekitWrapper.Calendar>(obj);
			}

			set
			{
				AppSettings.AddOrUpdateValue<string>(TimeKitCalendarKey, JsonConvert.SerializeObject(value));
			}
		}
		 
		#endregion

		public static string GeneralSettings
	    {
	      get
	      {
	        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
	      }
	      set
	      {
	        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
	      }
	    }

		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}
	}
}