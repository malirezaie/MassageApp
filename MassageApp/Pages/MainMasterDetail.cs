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
        
    	}
	}
}


