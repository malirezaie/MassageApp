using System;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Java.IO;
using Xamarin.Facebook;
using Xamarin.Facebook.AppEvents;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using Android.Content;

[assembly: MetaData("net.hockeyapp.android.appIdentifier", Value = "cd0602d475ce4079bcf3761406a939ed")]
//[assembly: MetaData("com.facebook.sdk.ApplicationId",Value="@string/facebook_app_id")]
namespace MassageApp.Droid
{
	[Activity(Label = "MassageApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		public static MainActivity instance;
		public ICallbackManager callbackManager;
		public FacebookCallback facebookCallback;


		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			instance = this;

			base.OnCreate(bundle);

			string STRIPE_KEY = "pk_test_eKfefVzad9wzTrbQiYPJBStR";
			string hockeyappIDAndroid = "cd0602d475ce4079bcf3761406a939ed";

			InitializeHockeyApp(hockeyappIDAndroid);
			Stripe.StripeClient.DefaultPublishableKey = STRIPE_KEY;

			global::Xamarin.Forms.Forms.Init(this, bundle);

			#region screen height & width

			var pixels = Resources.DisplayMetrics.WidthPixels;
			var scale = Resources.DisplayMetrics.Density;

			double dps = (double)((pixels - 0.5f) / scale);

			App.ScreenWidth = dps;

			pixels = Resources.DisplayMetrics.HeightPixels;
			dps = (double)((pixels - 0.5f) / scale);

			App.ScreenHeight = dps;

			#endregion

			#region fb init

			FacebookSdk.SdkInitialize(this);
			callbackManager = CallbackManagerFactory.Create();
			facebookCallback = new FacebookCallback();

			Xamarin.Facebook.Login.LoginManager.Instance.RegisterCallback(callbackManager, facebookCallback);
			#endregion


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

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
		}


		public static MainActivity DefaultService
		{
			get { return instance; }
		}

		void InitializeHockeyApp(string hockeyAppID)
		{
			CrashManager.Register(this, hockeyAppID);
			UpdateManager.Register(this, hockeyAppID, true);
			FeedbackManager.Register(this, hockeyAppID, null);
			MetricsManager.Register(Application);
		}

		internal void SetPlatformCallback(AndroidPlatform platform)
		{
			facebookCallback.platform = platform;
		}

	}

	public class FacebookCallback : Java.Lang.Object, IFacebookCallback
	{
		internal AndroidPlatform platform;

		public void OnCancel()
		{
			platform.OnFacebookLoginCancel();
		}

		public void OnError(FacebookException e)
		{
			platform.OnFacebookLoginError(e);
		}

		public async void OnSuccess(Java.Lang.Object obj)
		{
			LoginResult loginResult = (LoginResult)obj;
			await platform.OnFacebookLoginSuccess(loginResult.AccessToken.Token);
		}
	}

}

