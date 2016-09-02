using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using HockeyApp;
using UIKit;

namespace MassageApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure("6968e46c0d2442958b5ac64966b40395");
			manager.StartManager();

			App.ScreenWidth = (double)UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = (double)UIScreen.MainScreen.Bounds.Height;

			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

