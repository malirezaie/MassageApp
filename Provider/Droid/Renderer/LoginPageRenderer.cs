using System;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using Android.Content;
using MassageApp.Provider;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(LoginPage), typeof(MassageApp.Provider.Droid.LoginPageRenderer))]
namespace MassageApp.Provider.Droid
{
	public class LoginPageRenderer: PageRenderer
	{

		public Uri StartUri = new Uri("https://api.timekit.io/v2/accounts/google/signup?Timekit-App=appmassage2");
		public Uri EndUri = new Uri("http://appmassage.azurewebsites.net");


		public LoginPageRenderer()
		{


		}
		protected async override void OnElementChanged( ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || Element == null)
			{
				return;
			}

			try
			{
				string res = await LoginAsyncOverride(Forms.Context);

			}
			catch (Exception e)
			{

			}

		}


		protected Task<string> LoginAsyncOverride(Context context)
		{
			var tcs = new TaskCompletionSource<string>();

			var auth = new WebRedirectAuthenticator(StartUri, EndUri);
			//auth.ShowUIErrors = false;
			auth.ClearCookiesBeforeLogin = false;

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
					tcs.TrySetResult(e.Account.Properties["token"]);
			};

			context.StartActivity(intent);

			return tcs.Task;
		}


	}
}
