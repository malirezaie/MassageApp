using System;

using Xamarin.Forms;

namespace MassageApp
{
	public class MainMasterDetail : MasterDetailPage
	{
		MasterPageCS masterPage;

		public MainMasterDetail()
		{
			masterPage = new MasterPageCS();
			Master = masterPage;
			Detail = new NavigationPage(new MainMassagePage());//new DetailPageCS());
        	
			masterPage.logoutButton.Clicked += async (sender, e) =>
			{
				closeDrawer();
				await Navigation.PushModalAsync(new LoginPage());
				var platform = DependencyService.Get<ISocialLogin>();
				await platform.LogoutAsync();
			};

    	}

		public void closeDrawer()
		{
			IsPresented = false;
		}
	}
}


