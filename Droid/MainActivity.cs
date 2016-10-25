using System;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

[assembly: MetaData("net.hockeyapp.android.appIdentifier", Value = "cd0602d475ce4079bcf3761406a939ed")]
namespace MassageApp.Droid
{
	[Activity(Label = "MassageApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			string STRIPE_KEY = "pk_test_eKfefVzad9wzTrbQiYPJBStR";
			string hockeyappIDAndroid = "cd0602d475ce4079bcf3761406a939ed";

			InitializeHockeyApp(hockeyappIDAndroid);
			Stripe.StripeClient.DefaultPublishableKey = STRIPE_KEY;

			global::Xamarin.Forms.Forms.Init(this, bundle);

			var pixels = Resources.DisplayMetrics.WidthPixels;
			var scale = Resources.DisplayMetrics.Density;

			double dps = (double)((pixels - 0.5f) / scale);

			App.ScreenWidth = dps;

			pixels = Resources.DisplayMetrics.HeightPixels;
			dps = (double)((pixels - 0.5f) / scale);

			App.ScreenHeight = dps;

			LoadApplication(new App());
		}

		protected override void OnResume()
		{
			base.OnResume();
			Tracking.StartUsage(this);
		}

		protected override void OnPause()
		{
			base.OnPause();
			Tracking.StopUsage(this);
		}

		void InitializeHockeyApp(string hockeyAppID)
		{
			CrashManager.Register(this, hockeyAppID);
			UpdateManager.Register(this, hockeyAppID, true);
			FeedbackManager.Register(this, hockeyAppID, null);
			MetricsManager.Register(Application);
		}
	}
}

