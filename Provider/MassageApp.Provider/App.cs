using System;
using Xamarin.Auth;
using Xamarin.Forms;

namespace MassageApp.Provider
{
	public class App : Application
	{
		static NavigationPage _NavPage;

		public App()
		{
			MainPage = GetMainPage();

		}

		public static Page GetMainPage()
		{
			var profilePage = new ProfilePage();

			_NavPage = new NavigationPage(profilePage);

			return _NavPage;
		}

		public static bool IsLoggedIn
		{
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		static string _Token;
		public static string Token
		{
			get { return _Token; }
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

