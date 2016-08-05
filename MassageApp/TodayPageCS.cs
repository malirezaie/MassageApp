using System.Collections.Generic;
using Xamarin.Forms;

namespace MassageApp
{
	public class TodayPageCS : ContentPage
	{
		CardView testCardView;
		List<CardView> cardViewList;

		public TodayPageCS ()
		{
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
			var section1 = new TableSection()
			{
				new ViewCell(){
					View = new MainSectionOne(), Height = 300
				},
				new ViewCell(){
					View = new MainSectionOne(), Height = 300
				},
				new ViewCell(){
					View = new MainSectionOne(), Height = 300
				}

			};

			var section2 = new TableSection("Book")
			{
				new ViewCell(){
					View = new MainSectionTwo()
				}
			};
			var section3 = new TableSection("Book")
			{
				new ViewCell(){
					View = new MainSectionOne(), Height = 300
				}
			};


			TableView tblview = null;


			if (Device.OS == TargetPlatform.Android)
			{

				tblview = new CustomTableView
				{
					Root = new TableRoot
				{
					section2

				},
					Intent = TableIntent.Settings,
					HasUnevenRows = true,
				};

				Content = new ScrollView
				{
					Content = new MainSectionTwo()
				};

					//new MainSectionTwo();
				
			}


			if (Device.OS == TargetPlatform.iOS)
			{

				tblview = new TableView
				{
					Root = new TableRoot
					{
					section3,section3,section3

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
