using System;
using System.Threading.Tasks;
using MassageApp.Provider;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(MassageApp.Provider.iOS.LoginPageRenderer))]
namespace MassageApp.Provider.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			var auth = new OAuth2Authenticator(
				clientId: "appmassage", // your OAuth2 client id
				scope: "", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri("https://api.timekit.io/v2/accounts/google/signup?Timekit-App="), // the auth URL for the service
				redirectUrl: new Uri("http://appmassage.azurewebsites.net"));

			auth.Completed += (sender, eventArgs) =>
			{
				// We presented the UI, so it's up to us to dimiss it on iOS.
				App.SuccessfulLoginAction.Invoke();

				if (eventArgs.IsAuthenticated)
				{
					// Use eventArgs.Account to do wonderful things
					App.SaveToken(eventArgs.Account.Properties["access_token"]);
				}
				else {
					// The user cancelled
				}
			};

			PresentViewController(auth.GetUI(), true, null);
		}
	}
}
