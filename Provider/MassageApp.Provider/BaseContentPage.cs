using Xamarin.Forms;

namespace MassageApp.Provider
{
	public class BaseContentPage : ContentPage
	{
		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!App.IsLoggedIn)
			{
				Navigation.PushModalAsync(new LoginPage());
			}
			else {

				Content = new Entry
				{

					Text = App.Token

				};

			}
		}
	}
}