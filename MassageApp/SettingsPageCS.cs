using Xamarin.Forms;

namespace MassageApp
{
	public class SettingsPageCS : ContentPage
	{
		public SettingsPageCS ()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				Icon = "settings.png";
			}
			Title = "Settings";
			Content = new StackLayout { 
				Children = {
					new Label {
						Text = "Settings go here",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
