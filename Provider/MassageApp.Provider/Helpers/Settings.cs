// Helpers/Settings.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MassageApp.Provider.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
	public class Settings : INotifyPropertyChanged
	{

		static Settings settings;
		public static Settings Current
		{
			get { return settings ?? (settings = new Settings()); }
		}

		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
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

		#region TIMEKIT
		public const string TimeKitUserKey = nameof(TimeKitUserKey);

		public string TimeKitUser
		{
			get
			{
				return AppSettings.GetValueOrDefault(TimeKitUserKey, "");
			}

			set
			{
				AppSettings.AddOrUpdateValue(TimeKitUserKey, value);
			}

		}

		#endregion


	}
}