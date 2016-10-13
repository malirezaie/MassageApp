using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;


namespace MassageApp
{
	public class MainMassagePage : ContentPage
	{
		
		List<CardView> cardViewList;

		public MainMassagePage ()
		{
			
			Title = "MassageApp";

			if (Device.OS == TargetPlatform.iOS)
			{
				Icon = "today.png";
			}


			// Setup TableView Sections
			var section1 = new TableSection
			{
				new ViewCell(){
					View = new MainSectionOne(), Height = 430
				}

			};

			var section2 = new TableSection
			{
				new ViewCell(){
					View = new MainSectionTwo(), Height = 450
				}
			};
			var section3 = new TableSection
			{
				new ViewCell(){
					View = new MainSectionThree(), Height = 300
				}
			};

			var bookbutton = new TableSection
			{
				new ViewCell(){
					View = new ReviewButton(), Height = 80//Margin = new Thickness(-30, 0, -30, -10)
				}
			};


			if (Device.OS == TargetPlatform.Android)
			{
				Content = new ScrollView
				{
					Content = new MainPageAndroid()
				};
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				
				TableView tblview = new TableView
				{
					Root = new TableRoot
					{
						section1,section2,section3, bookbutton

					},
					Intent = TableIntent.Settings,
					HasUnevenRows = true,

				};

				Content = tblview;
			}

		}
	}
}
