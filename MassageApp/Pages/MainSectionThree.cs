using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionThree : AppSection
	{
		public MainSectionThree()
		{

			HeightRequest = 300;

			MainTitle.Text = "AVAILABILITY";
			MainSubTitle.Text = "Tell us your earliest start time and when you must finish by";

			Label _tempText = new Label
			{

				Text = "Enter your address to determine available times...",
				HeightRequest = 150,
				VerticalOptions = LayoutOptions.Center,
				VerticalTextAlignment = TextAlignment.Center

			};

			_content.Children.Add(_tempText);

			//if (Device.OS == TargetPlatform.iOS)
			//{
			//	_content.Children.Add(new BookButton
			//	{
			//		Margin = new Thickness(-30, 0, -30, -10)
			//	});
			//}

			this.Content = _content;

		}
	}
}

