using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MassageApp.Droid;
using Xamarin.Forms;
using Stripe;
using MassageApp.Helpers;
using MassageApp.Client.Model;

[assembly: Dependency(typeof(StripeDroid))]
namespace MassageApp.Droid
{
	public class StripeDroid: IStripe
	{
		public StripeDroid()
		{
		}

		public Task<CreditCard> DisplayCardView()
		{
			var taskCompletionSource = new TaskCompletionSource<CreditCard>();

			AlertDialog.Builder _alert = new AlertDialog.Builder((Activity)Forms.Context);
			//var inflater = Forms.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

			LayoutInflater _inflater = ((Activity)Forms.Context).LayoutInflater;

			StripeView stripeView = (StripeView)_inflater.Inflate(Resource.Layout.StripeView, null);

			_alert.SetView(stripeView);
			_alert.SetTitle("Add Card");
			_alert.SetPositiveButton("OK", (sender, e) =>
			{
				taskCompletionSource.SetResult(SaveCardData(stripeView.Card));
			});

			_alert.SetNegativeButton("Cancel", (sender, e) =>
			{
				taskCompletionSource.SetResult(null);
			});

			_alert.Show();

			return taskCompletionSource.Task;

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
				catch (StripeInvalidRequestException e)
				{
					return "";
				}

			}
			else {
				return "";
			}

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


	}
}

