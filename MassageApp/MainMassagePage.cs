using System.Collections.Generic;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainMassagePage : ContentPage
	{
		CardView testCardView;
		List<CardView> cardViewList;

		public MainMassagePage ()
		{

			Title = "MassageApp";

			if (Device.OS == TargetPlatform.iOS)
			{
				Icon = "today.png";
			}

			testCardView = new CardView();
			testCardView.Content = new StackLayout
			{
				Children = {
					new Label {
						Text = "Testing CardView!",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}, 
				HeightRequest = 100
			};


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
					View = new MainSectionTwo(), Height = 300
				}
			};
			var section3 = new TableSection
			{
				new ViewCell(){
					View = new MainSectionThree(), Height = 300
				}
			};


			TableView tblview = null;


			if (Device.OS == TargetPlatform.Android)
			{
				Content = new ScrollView
				{
					Content = new MainPageAndroid()
				};
			}


			if (Device.OS == TargetPlatform.iOS)
			{

				tblview = new TableView
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


			Title = "Today";


			/*new StackLayout { 
				Children = {
					new Label {
						Text = "Today's appointments go here",
						HorizontalOptions = LayoutOptions.Center
					}, 
					testCardView, 
					testCardView
				}
			};
			*/

		}
	}
}
