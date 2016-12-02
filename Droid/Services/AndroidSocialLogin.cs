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
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(MassageApp.Droid.AndroidPlatform))]
namespace MassageApp.Droid
{
	class AndroidPlatform : ISocialLogin
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

		public Task<MobileServiceUser> LoginFacebookAsync()
		{
			tcs = new TaskCompletionSource<MobileServiceUser>();

			var user = GetCachedUser();

			if (user != null)
			{
				tcs.TrySetResult(user);
			}
			else {

				var activity = Xamarin.Forms.Forms.Context as Android.App.Activity;

				MainActivity.DefaultService.SetPlatformCallback(this); // set context for facebook callbacks
				LoginManager.Instance.LogInWithReadPermissions(activity, new[] { "public_profile","email" });
			}
			return tcs.Task;
		}

		internal async Task OnFacebookLoginSuccess(string tokenString)
		{
			Debug.WriteLine($"Logged into Facebook, access_token: {tokenString}");

			var token = new JObject();
			token["access_token"] = tokenString;

			var user = await App.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook, token);
			Debug.WriteLine($"Logged into MobileService, user: {user.UserId}");

			tcs.TrySetResult(user);
		}

		internal void OnFacebookLoginError(FacebookException e)
		{
			tcs.TrySetException(e);
		}

		internal void OnFacebookLoginCancel()
		{
			tcs.TrySetException(new Exception("Facebook login cancelled"));
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

		public async Task LogoutAsync()
		{
			CookieManager.Instance.RemoveAllCookie();
			AuthStore.DeleteTokenCache();
			//App.
			await App.MobileService.LogoutAsync();
		}
	}
}

