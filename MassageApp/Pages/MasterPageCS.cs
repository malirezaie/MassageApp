using System;
using System.Collections.Generic;
using MassageApp.Helpers;
using Xamarin.Forms;

namespace MassageApp
{
	public class MasterPageCS : ContentPage
	{
		public ListView ListView { get { return listView; } }

		ListView listView;
		public Button logoutButton;

		public bool TIMEKIT_AUTH;

		TimekitWrapper.TimeKitClient _timekitClient;

		public MasterPageCS()
		{
			var masterPageItems = new List<MasterPageItem>();

			masterPageItems.Add(new MasterPageItem
			{
				Title = "Contacts",
				//IconSource = "contacts.png",
				//TargetType = typeof(ContactsPageCS)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "TodoList",
				//IconSource = "todo.png",
				//TargetType = typeof(TodoListPageCS)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = $"Name: {Settings.Current.CurrentUser.firstName} {Settings.Current.CurrentUser.lastName}",
				//IconSource = "reminders.png",
				//TargetType = typeof(ReminderPageCS)
			});

			listView = new ListView
			{
				ItemsSource = masterPageItems,
				ItemTemplate = new DataTemplate(() =>
				{
					var imageCell = new ImageCell();
					imageCell.SetBinding(TextCell.TextProperty, "Title");
					imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
					return imageCell;
				}),
				VerticalOptions = LayoutOptions.FillAndExpand,
				SeparatorVisibility = SeparatorVisibility.None
			};


			logoutButton = new Button
			{
				Text="Logout",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			TIMEKIT_AUTH = !string.IsNullOrEmpty(Settings.Current.TimeKitUser.email);
			_timekitClient = new TimekitWrapper.TimeKitClient(Settings.Current.TimeKitUser.email, Settings.Current.TimeKitUser.api_token);

			Button timeKitButton = new Button
			{
				Text = TIMEKIT_AUTH ? "TimeKit Authenticated": "Timekit",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				IsEnabled = !TIMEKIT_AUTH
			};

			timeKitButton.Clicked += TimeKitButton_Clicked; 
			//timeKitButton.Clicked -= TimeKitButton_Clicked;

			Button SyncCalendar = new Button
			{
				Text = "Sync Calendar",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			SyncCalendar.Clicked += async (sender, e) =>
			{

				var action = await DisplayActionSheet("Calendar", "Cancel", null, "Post Calendar","SyncFilter", "GetFilter");

				if (action.Equals("Post Calendar"))
				{
					if (string.IsNullOrEmpty(Settings.Current.TimeKitCalendar.name))
					{

						var _currCalendar = Settings.Current.TimeKitCalendar;
						_currCalendar.name = $"{Settings.Current.TimeKitUser.first_name}{Settings.Current.TimeKitUser.last_name}Calendar";

						var resp = await _timekitClient.PostCalendarAsync(_currCalendar);
						if (resp != null)
						{
							await DisplayAlert("Success!", $"You posted Calendar and ID is:{resp.id}", "OK");
							Settings.Current.TimeKitCalendar = resp;
						}
					}
					else {
						await DisplayAlert("Already Sent!", "you already have a calendar!", "OK");
					}
				}
				if (action.Equals("SyncFilter"))
				{
					if (TIMEKIT_AUTH)
					{
						//create one with username and password

						List<TimekitWrapper.Filter> filters = new List<TimekitWrapper.Filter>();

						filters.Add(new TimekitWrapper.SpecDayTimeObject(new TimekitWrapper.SpecDayAndTimeFilter("Monday", 10, 13)));
						filters.Add(new TimekitWrapper.SpecDayTimeObject(new TimekitWrapper.SpecDayAndTimeFilter("Friday", 14, 20)));

						filters.Add(new TimekitWrapper.SpecTimeObject(new TimekitWrapper.SpecificTimeFilter(0, 8)));
						filters.Add(new TimekitWrapper.SpecTimeObject(new TimekitWrapper.SpecificTimeFilter(21, 23)));

						var resp = await _timekitClient.PostFilterAsync(filters,true);

						if (resp)
						{
							await DisplayAlert("Success!", "Sync worked!", "OK");
						}
						else {
							await DisplayAlert("Error", "Sync did not work", "OK");
						}

						int j = 19;
					}

					else {
						await DisplayAlert("Error", "Please sync Timekit first!", "OK");
					}
				}
				else {
					// GET CALENDARS
				}

			};

			Padding = new Thickness(0, 40, 0, 0);

			if (Device.OS == TargetPlatform.iOS)
			{
				//Icon = "hamburger.png";
			}

			Title = "Profile";
			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
				listView,
					SyncCalendar,
					timeKitButton,
					logoutButton
				}
			};


		}

		async void TimeKitButton_Clicked(object sender, EventArgs e)
		{
			var firstClient = new TimekitWrapper.TimeKitClient();

			var tempCurrentUser = Settings.Current.CurrentUser;

			string tempEmail = tempCurrentUser.email == null ? tempCurrentUser.firstName + tempCurrentUser.lastName + "3@lazen.ca" : tempCurrentUser.email;

			var tempTimeKitUser = await firstClient.CreateUserAsync(tempCurrentUser.firstName, tempCurrentUser.lastName, tempEmail);

			tempCurrentUser = null;

			if (tempTimeKitUser != null)
			{
				await DisplayAlert("Success!", "created timekit user", "OK");
				Settings.Current.TimeKitUser = tempTimeKitUser;
				((Button)sender).Text = "TimeKit Authenticated";
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}


	}
}


