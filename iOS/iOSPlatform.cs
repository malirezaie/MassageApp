//using Microsoft.WindowsAzure.MobileServices.Files;
//using Microsoft.WindowsAzure.MobileServices.Files.Metadata;
//using Microsoft.WindowsAzure.MobileServices.Files.Sync;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.IO;
using System.Threading.Tasks;
//using Xamarin.Media;
using Microsoft.WindowsAzure.MobileServices;
using Foundation;
using Facebook.LoginKit;
using UIKit;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using System.Linq;
using MassageApp.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MassageApp.iOS.iOSPlatform))]
namespace MassageApp.iOS
{
	class iOSPlatform : IPlatform
	{
		private TaskCompletionSource<MobileServiceUser> tcs; // used in LoginFacebookAsync

		public iOSPlatform()
		{
		}

		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
		{
			var user = GetCachedUser();

			if (user == null)
			{
				var view = GetTopViewController();
				user = await App.MobileService.LoginAsync(view, provider);
			}

			return user;
		}

		public async Task<MobileServiceUser> LoginFacebookAsync()
		{
			tcs = new TaskCompletionSource<MobileServiceUser>();
			var loginManager = new LoginManager();
			var view = GetTopViewController();

			var user = GetCachedUser();

			if (user != null)
			{
				tcs.TrySetResult(user);
			}
			else {
				Debug.WriteLine("Starting Facebook client flow");
				try
				{
					loginManager.LogInWithReadPermissions(new[] { "public_profile", "email" }, view, LoginTokenHandler);
				}
				catch(Exception e)
				{
					Debug.WriteLine(e);
				}
			}

			return await tcs.Task;
		}

		private async void LoginTokenHandler(LoginManagerLoginResult loginResult, NSError error)
		{
			if (loginResult.Token != null)
			{
				Debug.WriteLine($"Logged into Facebook, access_token: {loginResult.Token.TokenString}");

				var token = new JObject();
				token["access_token"] = loginResult.Token.TokenString;

				#region try get email
				//var fbrequesturl = "https://graph.facebook.com/me?access_token=" + loginResult.Token.TokenString + "&fields=email,first_name,last_name";

				//using (var client = new System.Net.Http.HttpClient())
				//{
				//	using (var resp = await client.GetAsync(fbrequesturl))
				//	{
				//		resp.EnsureSuccessStatusCode();
				//		var res = await resp.Content.ReadAsStringAsync();

				//	}
				//}
				#endregion

				var user = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook, token);
				Debug.WriteLine($"Logged into MobileService, user: {user.UserId}");

				tcs.TrySetResult(user);
			}
			else {
				tcs.TrySetException(new Exception("Facebook login failed"));
			}
		}



		private MobileServiceUser GetCachedUser()
		{
			var user = AuthStore.GetUserFromCache();
			if (user != null)
			{
				App.MobileService.CurrentUser = user;
			}

			return user;
		}

		public AccountStore GetAccountStore()
		{
			return AccountStore.Create();
		}

		private UIViewController GetTopViewController()
		{
			var view = UIApplication.SharedApplication.KeyWindow.RootViewController;

			// Find the view controller that's currently on top. This is required if there's a modal page being displayed
			while (view.PresentedViewController != null)
			{
				view = view.PresentedViewController;
			}

			return view;
		}

		public async Task LogoutAsync()
		{
			foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
			{
				NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
			}

			AuthStore.DeleteTokenCache();
			await App.MobileService.LogoutAsync();
		}
	}
}

