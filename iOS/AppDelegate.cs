using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using HockeyApp.iOS;
using UIKit;

namespace MassageApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			string STRIPE_KEY = "pk_test_eKfefVzad9wzTrbQiYPJBStR";

			string hockeyAppID = "6968e46c0d2442958b5ac64966b40395";

			InitializeHockeyApp(hockeyAppID);

			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure("6968e46c0d2442958b5ac64966b40395");
			manager.StartManager();

			Stripe.StripeClient.DefaultPublishableKey = STRIPE_KEY;

			App.ScreenWidth = (double)UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = (double)UIScreen.MainScreen.Bounds.Height;

			global::Xamarin.Forms.Forms.Init();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			LoadApplication(new App());

			Facebook.CoreKit.ApplicationDelegate.SharedInstance.FinishedLaunching(app, options);

			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
			return Facebook.CoreKit.ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
		}

		void InitializeHockeyApp(string iOSHockeyAppID)
		{
			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure(iOSHockeyAppID);
			manager.LogLevel = BITLogLevel.Debug;
			manager.StartManager();
			manager.Authenticator.AuthenticateInstallation();
			manager.UpdateManager.CheckForUpdate();
		}

		public override void OnActivated(UIApplication uiApplication)
		{
			base.OnActivated(uiApplication);

			// log app activation to Facebook app events
			Facebook.CoreKit.AppEvents.ActivateApp();
			Facebook.CoreKit.Settings.LimitEventAndDataUsage = true; // tell Facebook not to use app events for ad serving
		}

	}
}

