using System.Collections.Generic;
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
					View = new MainSectionOne(), Height = 400
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
						section1,section2,section3

					},
					Intent = TableIntent.Settings,
					HasUnevenRows = true,

				};

				Content = tblview;
			}

		}
	}
}
