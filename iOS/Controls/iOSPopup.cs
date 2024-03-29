﻿using System;
using Xamarin.Forms;
using MassageApp.iOS;
using System.Collections.Generic;
using UIKit;
using System.Threading.Tasks;
using Foundation;

[assembly: Dependency(typeof(iOSPopup))]
namespace MassageApp.iOS
{
	public class iOSPopup : IPopupControl
	{
		public iOSPopup()
		{
		}

		public Task<string> DisplayAddressAlert(string title, string message)
		{
			var taskCompletionSource = new TaskCompletionSource<string>();

			var alert = UIAlertController.Create(
			  title, message, UIAlertControllerStyle.Alert);

			alert.AddTextField(textField =>
			{
				int j = 10;
			});

			alert.AddAction(UIAlertAction.Create(
		  						"Cancel", UIAlertActionStyle.Cancel,
		  						a => taskCompletionSource.SetResult("Cancel"))
			               );

			alert.AddAction(UIAlertAction.Create(
			  					"Okay", UIAlertActionStyle.Default,
			  					a => taskCompletionSource.SetResult(alert.TextFields[0].Text))
			               );

			var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;

			vc.PresentViewController(alert, true, null);

			return taskCompletionSource.Task;

		}

		/*
		public async Task<string> DisplayAlert()
		{
			var textInputAlertController = UIAlertController.Create("Text Input Alert", "Hey, input some text", UIAlertControllerStyle.ActionSheet);

			//Add Text Input
			textInputAlertController.AddTextField(textField =>
			{
			});

			string _val = null;
			//Add Actions
			var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel was Pressed"));
			var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, 
			                                      (obj) => _val = textInputAlertController.TextFields[0].Text);

			textInputAlertController.AddAction(cancelAction);
			textInputAlertController.AddAction(okayAction);

			var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;

			await vc.PresentViewControllerAsync(textInputAlertController, true);

			return _val;
		}*/


		public Task<string> DisplayAlertWithOptions(SelectableItemCell.SelectableItemCellModel _model)
		{
			var taskCompletionSource = new TaskCompletionSource<string>();

			var alert = UIAlertController.Create(
			  null,_model.message, UIAlertControllerStyle.ActionSheet);

			alert.SetValueForKey(new NSAttributedString(_model.Title, null, UIColor.Red), new NSString("attributedTitle"));

			foreach (string i in _model._options)
			{
				alert.AddAction(UIAlertAction.Create(
			  					i, UIAlertActionStyle.Default,
			  					a => taskCompletionSource.SetResult(i)));
				
			}
			/*
			alert.AddAction(UIAlertAction.Create(
			  "Okay", UIAlertActionStyle.Default,
			  a => taskCompletionSource.SetResult(alert.TextFields[0].Text)));
			*/
			alert.AddAction(UIAlertAction.Create(
			  "Cancel", UIAlertActionStyle.Cancel,
			  a => taskCompletionSource.SetResult("Cancel")));
			
			var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;

			vc.PresentViewController(alert, true, null);

			return taskCompletionSource.Task;
		}


		public string selectedItem(string title, string subtitle,List<string> items)
		{
			throw new NotImplementedException();
		}
	}
}

