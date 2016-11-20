using System;
using System.Threading.Tasks;
using MassageApp.Provider;
using Xamarin.Forms;
using System.Threading.Tasks;
using MassageApp.Provider;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NSAction = System.Action;
using Android.Content;
using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(MassageApp.Provider.Droid.DroidTimeKit))]
namespace MassageApp.Provider.Droid
{
	public class DroidTimeKit : IAuthService
	{
		public Uri StartUri = new Uri("https://api.timekit.io/v2/accounts/google/signup?Timekit-App=appmassage2&callback=https://appmassage.azurewebsites.net");
		public Uri EndUri = new Uri("https://appmassage.azurewebsites.net");

		public async Task<string> LinkTimeKit()
		{
			return await LoginAsyncOverride(Xamarin.Forms.Forms.Context);

		}

		protected Task<string> LoginAsyncOverride(Context context)
		{
			var tcs = new TaskCompletionSource<string>();

			var auth = new WebRedirectAuthenticator(StartUri, EndUri);
			//auth.ShowUIErrors = false;
			auth.ClearCookiesBeforeLogin = true;

			Intent intent = auth.GetUI(context);

			auth.Error += (sender, e) =>
			{
				string message = String.Format(CultureInfo.InvariantCulture, "Authentication failed with HTTP response code {0}.", e.Message);
				InvalidOperationException ex = (e.Exception == null)
					? new InvalidOperationException(message)
					: new InvalidOperationException(message, e.Exception);

				tcs.TrySetException(ex);
			};

			auth.Completed += (sender, e) =>
			{
				if (!e.IsAuthenticated)
					tcs.TrySetException(new InvalidOperationException("Authentication was cancelled by the user."));
				else
					tcs.TrySetResult(e.Account.Properties["email"] + "~" + e.Account.Properties["token"]);
			};

			context.StartActivity(intent);

			return tcs.Task;
		}


	}

}