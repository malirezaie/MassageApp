using System;
using HockeyApp.Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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

			CrashManager.Register(this, "cd0602d475ce4079bcf3761406a939ed");

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
	}
}

