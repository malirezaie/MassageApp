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


			Button logoutButton = new Button
			{
				Text="Logout",
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			logoutButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushModalAsync(new LoginPage());

				var platform = DependencyService.Get<IPlatform>();
				await platform.LogoutAsync();
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
					logoutButton
				}
			};


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}


	}
}


