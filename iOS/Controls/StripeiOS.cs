using System;
using Xamarin.Forms;
using MassageApp.iOS;
using System.Collections.Generic;
using UIKit;
using System.Threading.Tasks;
using Stripe;
using CoreGraphics;
using MassageApp.Client.Model;
using MassageApp.Helpers;

[assembly: Dependency(typeof(StripeiOS))]
namespace MassageApp.iOS
{
	public class StripeiOS : IStripe
	{

		StripeView stripeView;

		public StripeiOS()
		{
		}

		public Task<CreditCard> DisplayCardView()
		{


			var taskCompletionSource = new TaskCompletionSource<CreditCard>();

			var alert = UIAlertController.Create(
				"Add Card", "\n\n", UIAlertControllerStyle.Alert);

			stripeView = new StripeView();
			stripeView.Frame = new CGRect(10, 40, alert.View.Bounds.Size.Width - 10 * 4.0, stripeView.Frame.Height);


			alert.View.AddSubview(stripeView);

			alert.AddAction(UIAlertAction.Create(
		  						"Cancel", UIAlertActionStyle.Cancel,
		  						a => taskCompletionSource.SetResult(null))
						   );

			alert.AddAction(UIAlertAction.Create(
			  					"Okay", UIAlertActionStyle.Default,
								a => taskCompletionSource.SetResult(SaveCardData(stripeView.Card)))
						   );

			var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;

			vc.PresentViewController(alert, true, null);

			return taskCompletionSource.Task;
		}


		public CreditCard SaveCardData(Card _card)
		{
			if (_card.IsCardValid)
			{
				return new CreditCard
				{
					Number = _card.Number,
					CVC = _card.CVC,
					expMonth = _card.ExpiryMonth,
					expYear = _card.ExpiryYear,
					name = _card.Name
				};

			}
			else {
				return null;
			}

		}

		public async Task<string> CreateToken()
		{
			CreditCard _cc = Settings.Current.CurrentCard;
			Card stripeCard = new Card();
			if (!string.IsNullOrEmpty(_cc.Number))
			{
				stripeCard.Number = _cc.Number;
				stripeCard.CVC = _cc.CVC;
				stripeCard.ExpiryYear = _cc.expYear;
				stripeCard.ExpiryMonth = _cc.expMonth;

				try
				{
					var token = await Stripe.StripeClient.CreateToken(stripeCard);//, StripeClient.DefaultPublishableKey );
					return token.Id;
				}
				catch(StripeInvalidRequestException e)
				{
					return "";
				}

			}
			else {
				return "";
			}

		}


	}
}

