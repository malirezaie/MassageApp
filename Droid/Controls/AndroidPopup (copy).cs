using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using MassageApp.Droid;
using Xamarin.Forms;

/*
[assembly: Dependency(typeof(AndroidPopup))]
namespace MassageApp.Droid
{
	public class AndroidPopup : IPopupControl
	{
		public TaskCompletionSource<string> taskCompletionSource;

		public AndroidPopup()
		{
			taskCompletionSource = new TaskCompletionSource<string>();
		}


		public Task<string> DisplayAlert(string title, string subtitle, List<string> items)
		{
			
			AlertDialog.Builder alert = new AlertDialog.Builder(Forms.Context);


			alert.SetTitle(title);
			//alert.SetMessage(subtitle);

			alert.SetItems(items.ToArray(), (sender, e) =>
			{
				taskCompletionSource.SetResult(items[e.Which]);
			});

			alert.SetNegativeButton("Cancel", (sender, e) =>
			{
				taskCompletionSource.SetResult("Cancel");
			});


			alert.Show();
			alert.SetCancelable(true);

			alert.SetOnDismissListener(new CancelListener(this));

			return taskCompletionSource.Task;

		}

		public class CancelListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
		{
			AndroidPopup _popup;
	
			public CancelListener(AndroidPopup popup)
			{
				_popup = popup;
			}

			public void OnDismiss(IDialogInterface dialog)
			{
				_popup.taskCompletionSource.SetResult("Cancel");
			}

		}

		public class AlertDialogFragment : DialogFragment
		{
			public override void OnDismiss(IDialogInterface dialog)
			{
				base.OnDismiss(dialog);
			}


		}


		public string selectedItem(string title, string subtitle, List<string> items)
		{
			throw new NotImplementedException();
		}
	}
}

*/

