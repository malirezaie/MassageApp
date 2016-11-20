using System;
using MassageApp.Client.Model;
using MassageApp.Helpers;
using Xamarin.Forms;

namespace MassageApp
{
	public class BookButton : Label
	{
		public BookButton()
		{
			HorizontalOptions = LayoutOptions.FillAndExpand;
			//BackgroundColor = Color.FromRgb(33, 150, 243);

			//Label mainText = new Label
			//{
			//	Text = "REVIEW",
			//	TextColor = Color.White,
			//	FontAttributes = FontAttributes.Bold,
			//	FontSize = 16,
			//	VerticalOptions = LayoutOptions.Center,
			//	VerticalTextAlignment = TextAlignment.Center,
			//	HorizontalTextAlignment = TextAlignment.Center,
			//	HorizontalOptions = LayoutOptions.FillAndExpand,
			//	HeightRequest = 80,
			//	BackgroundColor = Color.FromRgb(33, 150, 243)
			//};


			Text = "REVIEW";
			TextColor = Color.White;
			FontAttributes = FontAttributes.Bold;
			FontSize = 16;
			VerticalOptions = LayoutOptions.Center;
			VerticalTextAlignment = TextAlignment.Center;
			HorizontalTextAlignment = TextAlignment.Center;
			HorizontalOptions = LayoutOptions.FillAndExpand;
			HeightRequest = 80;
			BackgroundColor = Color.FromRgb(33, 150, 243);


			var tapGestureRecognizer = new TapGestureRecognizer();

			//tapGestureRecognizer.Tapped += async (s, e) =>
			//{
			//	Label _sender = s as Label;
			//	_sender.Opacity = 0.8;
			//	_sender.BackgroundColor = Color.FromRgb(25, 126, 207);

			//	var action = await Application.Current.MainPage.DisplayAlert("Confirm", "Book Massage?", "Yes", "Cancel");

			//	_sender.Opacity = 1.0;
			//	_sender.BackgroundColor = Color.FromRgb(33, 150, 243);
			//};

			tapGestureRecognizer.Tapped += async (sender, e) =>
			{
				CreditCard card  = await DependencyService.Get<IStripe>().DisplayCardView();
				if (card != null)
				{
					Settings.Current.CurrentCard = card;
					var token = await DependencyService.Get<IStripe>().CreateToken();
					Settings.Current.StripeApiKey = token;
				}
			};

			this.GestureRecognizers.Add(tapGestureRecognizer);


			//Children.Add(mainText);


		}
	}
}

