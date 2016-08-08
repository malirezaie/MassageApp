using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class AppSection : CardView
	{

		public StackLayout _content { get; set; }

		public Label MainTitle { get; set; }

		public Label MainSubTitle { get; set;}

		public AppSection()
		{
			_content = new StackLayout
			
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			MainTitle = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Black,
				FontSize = 14
			};

			MainSubTitle = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 14

			};

			if (Device.OS == TargetPlatform.iOS)
			{
				//MainLabel.FontSize = 16;
				//MainTitle.HeightRequest = 30;
				//MainSubTitle.HeightRequest = 20;
			}
			else {
				//MainLabel.FontSize = 18;
				//MainTitle.HeightRequest = 20;
				//MainSubTitle.HeightRequest = 20;
			}

			_content.Children.Add(MainTitle);
			_content.Children.Add(MainSubTitle);
		}
	}
}

