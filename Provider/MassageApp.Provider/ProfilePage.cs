using MassageApp.Provider.Helpers;
using Xamarin.Forms;

namespace MassageApp.Provider
{
	public class ProfilePage: ContentPage
	{
		Label mainLabel;

		public ProfilePage()
		{
			mainLabel = new Label()
			{
				Text = Settings.Current.TimeKitUser,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			Content = mainLabel;

		}

		public async void promptForLogin()
		{

			string res = await DependencyService.Get<IAuthService>().LinkTimeKit();

			if (!string.IsNullOrEmpty(res))
			{
				App.SaveToken(res);
				//App.SuccessfulLoginAction.Invoke();
				//App.SuccessfulLoginAction.Invoke();

				mainLabel.Text = App.Token;
			}

		}


	}
}