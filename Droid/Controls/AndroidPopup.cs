using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
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

			public void setTitleAndSubtitle()
			{



			}

			public override Dialog OnCreateDialog(Bundle savedInstanceState)
			{

				/*AlertDialog.Builder alert = new AlertDialog.Builder(Forms.Context,Resource.Style.AlertDialogCustom);

				alert.SetTitle(_model.Title);
				//alert.SetMessage(subtitle);

				var inflater = Forms.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

				Android.Views.View view = inflater.Inflate(Resource.Layout.TitleAndSubtitleView, null);

				alert.SetCustomTitle(view);

				alert.SetSingleChoiceItems(_model._options.ToArray(),this._model.selectedIndex, (sender, e) =>
				{
					this.Dismiss();
					_TaskCSource.SetResult(_model._options[e.Which]);
				});


				alert.SetNegativeButton("Cancel", (sender, e) =>
				{
					_TaskCSource.SetResult("Cancel");
				});


				TextView _title = ((TextView)view.FindViewById(Resource.Id.alertTitle));
				TextView _sbtitle = ((TextView)view.FindViewById(Resource.Id.alertSubtitle));

				_title.Text = _model.Title;
				_sbtitle.Text = _model.message;

				return alert.Create(); 
				*/
				return CreateOptionDialog();
			}

			public Dialog CreateOptionDialog()
			{

				var inflater = Forms.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

				Android.Views.View _Content = inflater.Inflate(Resource.Layout.AlertWithOptions, null);

				//Android.Views.View _Title = inflater.Inflate(Resource.Layout.TitleAndSubtitleView, null);

				AlertDialog.Builder dialog = new AlertDialog.Builder(Forms.Context, Resource.Style.AlertDialogCustom);

				//dialog.SetTitle(this._model.Title);

				//dialog.SetCustomTitle(_Title);
				dialog.SetView(_Content);

				dialog.SetNegativeButton("Cancel", (sender, e) =>
				{
					_TaskCSource.SetResult("Cancel");
				});

				TextView title_text = (TextView)_Content.FindViewById(Resource.Id.alertTitle);
				TextView subtitle_text = (TextView)_Content.FindViewById(Resource.Id.alertSubtitle);

				title_text.Text = this._model.Title;
				subtitle_text.Text = this._model.message;

				RadioGroup rg = (RadioGroup)_Content.FindViewById(Resource.Id.radio_group);

				AlertDialog _dialog = dialog.Create();

				for (int i = 0; i < this._model._options.Count; i++)
				{
					RadioButton rb = new RadioButton(Forms.Context);
					rb.Text = this._model._options[i];
					rb.Click += (sender, e) =>
					{
						_dialog.Dismiss();
						_TaskCSource.SetResult(((RadioButton)sender).Text);
					};
					rg.AddView(rb);

					if (this._model.selectedIndex == i)
					{
						rb.Checked = true;
					}
				}

				//_dialog.FindViewById

				return _dialog;
			}

			public override void OnCancel(IDialogInterface dialog)
			{
				_TaskCSource.SetResult("Cancel");
			}

		}


	
	}
}

