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

[assembly: Dependency(typeof(StripeDroid))]
namespace MassageApp.Droid
{
	public class StripeDroid //: IStripe
	{
		public StripeDroid()
		{
		}

		public Task<string> CreateToken()
		{
			throw new NotImplementedException();
		}

		public Task<bool> DisplayCardView()
		{
			throw new NotImplementedException();
		}
	}
}

