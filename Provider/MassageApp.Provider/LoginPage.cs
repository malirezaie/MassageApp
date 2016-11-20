using Xamarin.Forms;
using MassageApp.Provider.Helpers;
using System;

namespace MassageApp.Provider
{
	public class LoginPage : ContentPage
	{

		public LoginPage()
		{

			Label mainlabel = new Label
			{
				Text = "Please Link Timekit",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, 
				FontSize  = 24
			};

			Label desc = new Label()
			{
				Text = "We use Timekit to Manage our scheduling. Please link your Lazen account",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			Button link_timekit = new Button
			{
				Text = "Link Account",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			link_timekit.Clicked += async (sender, e) =>
			{
				string res = await DependencyService.Get<IAuthService>().LinkTimeKit();

				if (res.Contains("@gmail.com"))
				{
					Settings.Current.TimeKitUser = res;
					await Navigation.PushModalAsync(new ProfilePage());
				}
				else {
					await DisplayAlert("Error", "There was an error linking Timekit. Please try again", "OK");
				}
			};

			var layout = new StackLayout();

			layout.Children.Add(mainlabel);
			layout.Children.Add(desc);
			layout.Children.Add(link_timekit);

			Content = layout;
		}
	}
}