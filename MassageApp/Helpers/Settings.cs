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

	private const string DefaultUserIdKey = nameof(DefaultUserIdKey);
	public const string UserIdDefault = "";

	public string DefaultUserId
	{
		get { return AppSettings.GetValueOrDefault<string>(DefaultUserIdKey, UserIdDefault); }
		set { AppSettings.AddOrUpdateValue<string>(DefaultUserIdKey, value); }
	}

	private const string CurrentUserIdKey = nameof(CurrentUserIdKey);
	public const string DefaultCurrentUserId = "";

	public User CurrentUser
	{
		get {
				string obj = AppSettings.GetValueOrDefault<string>(CurrentUserIdKey, "");
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

	public const string MobileAppUrlKey = nameof(MobileAppUrlKey);
	public const string DefaultMobileAppUrl = "https://appmassage.azurewebsites.net/";
	public string MobileAppUrl
	{
		get { return AppSettings.GetValueOrDefault<string>(MobileAppUrlKey, DefaultMobileAppUrl); }

		set { AppSettings.AddOrUpdateValue<string>(MobileAppUrlKey, value); }
	}

	

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