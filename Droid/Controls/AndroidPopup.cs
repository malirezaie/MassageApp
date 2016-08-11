using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
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

		public Task<string> DisplayAddressAlert(string title, string message)
		{
			return null;
			//return DisplayAlertWithOptions(_model);
		}

		public Task<string> DisplayAlertWithOptions(SelectableItemCell.SelectableItemCellModel _model)
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

			AlertDialogFragment _fragment = AlertDialogFragment.NewInstance(taskCompletionSource, _model);
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
			SelectableItemCell.SelectableItemCellModel _model;

			public AlertDialogFragment(TaskCompletionSource<string> TaskCSource, SelectableItemCell.SelectableItemCellModel model)
			{
				_TaskCSource = TaskCSource;
				this._model = model;
			}

			public static AlertDialogFragment NewInstance(TaskCompletionSource<string> TaskCSource, SelectableItemCell.SelectableItemCellModel model)
			{
				AlertDialogFragment fragment = new AlertDialogFragment(TaskCSource,model);
				return fragment;
			}

			public override Dialog OnCreateDialog(Bundle savedInstanceState)
			{
				/*
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
				*/
				return CreateOptionDialog();
			}

			public Dialog CreateOptionDialog()
			{

				Dialog dialog = new Dialog(Forms.Context);

				dialog.SetTitle(this._model.Title);
				dialog.SetContentView(Resource.Layout.AlertWithOptions);

				TextView subtitle_text = (TextView)dialog.FindViewById(Resource.Id.subtitle);

				subtitle_text.Text = this._model.message;

				RadioGroup rg = (RadioGroup)dialog.FindViewById(Resource.Id.radio_group);

				for (int i = 0; i < this._model._options.Count; i++) 
				{
					RadioButton rb = new RadioButton(Forms.Context);
					rb.Text = this._model._options[i];
					rb.Click += (sender, e) =>
					{
						dialog.Dismiss();
						_TaskCSource.SetResult(((RadioButton)sender).Text);
					};
					rg.AddView(rb);

					if (this._model.selectedIndex == i)
					{
						rb.Checked = true;
					}
				}



				return dialog;
			}



			public override void OnCancel(IDialogInterface dialog)
			{
				_TaskCSource.SetResult("Cancel");
			}

		}


	
	}
}

