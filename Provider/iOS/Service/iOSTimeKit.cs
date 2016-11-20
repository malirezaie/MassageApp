using System;
using System.Threading.Tasks;
using MassageApp.Provider;
using Xamarin.Forms;
using System.Threading.Tasks;
using MassageApp.Provider;
using UIKit;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using NSAction = System.Action;


[assembly: Xamarin.Forms.Dependency(typeof(MassageApp.Provider.iOS.iOSTimeKit))]
namespace MassageApp.Provider.iOS
{
	public class iOSTimeKit : IAuthService
	{
		public Uri StartUri = new Uri("https://api.timekit.io/v2/accounts/google/signup?Timekit-App=appmassage2&callback=https://appmassage.azurewebsites.net");
		public Uri EndUri = new Uri("https://appmassage.azurewebsites.net");



		public async Task<string> LinkTimeKit()
		{
			return await LoginAsyncOverride(GetTopViewController().View.Bounds, GetTopViewController());

		}

		public Task<string> LoginAsyncOverride(CoreGraphics.CGRect rect, object view)
		{
			var tcs = new TaskCompletionSource<string>();

			var auth = new WebRedirectAuthenticator(StartUri, EndUri);
			//auth.ShowUIErrors = false;
			//auth.ClearCookiesBeforeLogin = true;

			UIViewController c = auth.GetUI();

			UIViewController controller = null;
			UIPopoverController popover = null;

			auth.Error += (o, e) =>
			{
				NSAction completed = () =>
				{
					Exception ex = e.Exception ?? new Exception(e.Message);
					tcs.TrySetException(ex);
				};

				if (controller != null)
					controller.DismissViewController(true, completed);
				if (popover != null)
				{
					popover.Dismiss(true);
					completed();
				}
			};

			auth.Completed += (o, e) =>
			{

				NSAction completed = () =>
				{
					if (!e.IsAuthenticated)
						tcs.TrySetException(new InvalidOperationException("Authentication was cancelled by the user."));
					else
						tcs.TrySetResult(e.Account.Properties["email"] + "~" + e.Account.Properties["token"]);

				};

				if (controller != null)
					controller.DismissViewController(true, completed);
				if (popover != null)
				{
					popover.Dismiss(true);
					completed();
				}
			};

			controller = view as UIViewController;
			if (controller != null)
			{
				controller.PresentViewController(c, true, null);
			}
			else
			{
				UIView v = view as UIView;
				UIBarButtonItem barButton = view as UIBarButtonItem;

				popover = new UIPopoverController(c);

				if (barButton != null)
					popover.PresentFromBarButtonItem(barButton, UIPopoverArrowDirection.Any, true);
				else
					popover.PresentFromRect(rect, v, UIPopoverArrowDirection.Any, true);
			}

			return tcs.Task;
		}


		private UIViewController GetTopViewController()
		{
			var view = UIApplication.SharedApplication.KeyWindow.RootViewController;

			// Find the view controller that's currently on top. This is required if there's a modal page being displayed
			while (view.PresentedViewController != null)
			{
				view = view.PresentedViewController;
			}

			return view;
		}

	}
}

