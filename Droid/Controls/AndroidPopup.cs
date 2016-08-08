using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using MassageApp.Droid;
using Xamarin.Forms;


[assembly: Dependency(typeof(AndroidPopup))]
namespace MassageApp.Droid
{
	public class AndroidPopup : IPopupControl
	{
		public AndroidPopup()
		{
			
		}


		public Task<string> DisplayAlert(string title, string subtitle, List<string> items)
		{
			
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
			FragmentTransaction ft = ((Activity)Forms.Context).FragmentManager.BeginTransaction();

			//Remove fragment else it will crash as it is already added to backstack
			Fragment prev = ((Activity)Forms.Context).FragmentManager.FindFragmentByTag("dialog");
			if (prev != null)
			{
				ft.Remove(prev);
			}

			ft.AddToBackStack(null);

			AlertDialogFragment _fragment = AlertDialogFragment.NewInstance(taskCompletionSource, title, subtitle, items);
			_fragment.Show(ft, "dialog");

			return taskCompletionSource.Task;

		}

		// For custom Dialogs!
		public class AlertDialogFragment : DialogFragment
		{
			TaskCompletionSource<string> _TaskCSource;
			string title;
			string message;
			List<string> items;

			public AlertDialogFragment(TaskCompletionSource<string> TaskCSource, string title, string msg, List<string> items)
			{
				_TaskCSource = TaskCSource;
				this.title = title;
				this.message = msg;
				this.items = items;
			}

			public static AlertDialogFragment NewInstance(TaskCompletionSource<string> TaskCSource, string title, string msg, List<string> items)
			{
				AlertDialogFragment fragment = new AlertDialogFragment(TaskCSource,title,msg,items);
				return fragment;
			}

			public override Dialog OnCreateDialog(Bundle savedInstanceState)
			{
				AlertDialog.Builder alert = new AlertDialog.Builder(Forms.Context);


				alert.SetTitle(title);
				//alert.SetMessage(subtitle);

				alert.SetItems(items.ToArray(), (sender, e) =>
				{
					_TaskCSource.SetResult(items[e.Which]);
				});

				alert.SetNegativeButton("Cancel", (sender, e) =>
				{
					_TaskCSource.SetResult("Cancel");
				});

				return alert.Create();
			}

			public override void OnCancel(IDialogInterface dialog)
			{
				_TaskCSource.SetResult("Cancel");
			}

		}


		public string selectedItem(string title, string subtitle, List<string> items)
		{
			throw new NotImplementedException();
		}
	}
}

