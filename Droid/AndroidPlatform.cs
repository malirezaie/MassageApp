//using Microsoft.WindowsAzure.MobileServices.Files;
//using Microsoft.WindowsAzure.MobileServices.Files.Metadata;
//using Microsoft.WindowsAzure.MobileServices.Files.Sync;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.IO;
using System.Threading.Tasks;
//using Xamarin.Media;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Android;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using System.Linq;
using MassageApp.Helpers;
using Xamarin.Forms;
using Android.Webkit;

[assembly: Xamarin.Forms.Dependency(typeof(MassageApp.Droid.AndroidPlatform))]
namespace MassageApp.Droid
{
	class AndroidPlatform : IPlatform
	{
		private TaskCompletionSource<MobileServiceUser> tcs; // used in LoginFacebookAsync

		public AndroidPlatform()
		{
		}

		public async Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider)
		{
			var user = GetCachedUser();

			if (user == null)
			{
				user = await App.MobileService.LoginAsync(Forms.Context, provider);
			}

			return user;
		}

		//public async Task<MobileServiceUser> LoginFacebookAsync()
		//{
		//	tcs = new TaskCompletionSource<MobileServiceUser>();
		//	var loginManager = new LoginManager();
		//	var view = GetTopViewController();

		//	var user = GetCachedUser();

		//	if (user != null)
		//	{
		//		tcs.TrySetResult(user);
		//	}
		//	else {
		//		Debug.WriteLine("Starting Facebook client flow");
		//		loginManager.LogInWithReadPermissions(new[] { "public_profile" }, view, LoginTokenHandler);
		//	}

		//	return await tcs.Task;
		//}

		//private async void LoginTokenHandler(LoginManagerLoginResult loginResult, NSError error)
		//{
		//	if (loginResult.Token != null)
		//	{
		//		Debug.WriteLine($"Logged into Facebook, access_token: {loginResult.Token.TokenString}");

		//		var token = new JObject();
		//		token["access_token"] = loginResult.Token.TokenString;

		//		var user = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook, token);
		//		Debug.WriteLine($"Logged into MobileService, user: {user.UserId}");

		//		tcs.TrySetResult(user);
		//	}
		//	else {
		//		tcs.TrySetException(new Exception("Facebook login failed"));
		//	}
		//}

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

		public async Task LogoutAsync()
		{
			CookieManager.Instance.RemoveAllCookie();
			AuthStore.DeleteTokenCache();
			//App.
			await App.MobileService.LogoutAsync();
		}
	}
}

