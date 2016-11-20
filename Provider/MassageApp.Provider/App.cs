using System;
using Xamarin.Auth;
using Xamarin.Forms;
using MassageApp.Provider.Helpers;

namespace MassageApp.Provider
{
	public class App : Application
	{
		static NavigationPage _NavPage;
		public static double ScreenWidth;
		public static double ScreenHeight;

		public App()
		{
			MainPage = new NavigationPage(GetMainPage());

		}

		public static Page GetMainPage()
		{

			var timeKitAuth = Settings.Current.TimeKitUser;

			Settings.Current.TimeKitUser = "";

			if (string.IsNullOrEmpty(timeKitAuth)){

				//we will go to the Login Page first
				return new LoginPage();

			}
			else {
				return new ProfilePage();
			}

		}

		public static bool IsLoggedIn
		{
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		static string _Token;
		public static string Token
		{
			get {
				return _Token;
			}
		}

		public static void SaveToken(string token)
		{
			_Token = token;
		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
					_NavPage.Navigation.PopModalAsync();
				});
			}
		}
	}
}

