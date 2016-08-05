using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionTwo : StackLayout
	{
		public MainSectionTwo()
		{

			this.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #1"
					},
					HeightRequest = 300
					
				}
			);

			this.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #2"
					},
					HeightRequest = 300

				}
			);

			this.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #3"
					},
					HeightRequest = 300

				}
			);

		}
	}


	public class MainSectionTwo_Scroll : ScrollView
	{
		public MainSectionTwo_Scroll()
		{

			var _content = new StackLayout(); 

			_content.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #1"
					},
					HeightRequest = 300

				}
			);

			_content.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #2"
					},
					HeightRequest = 300

				}
			);

			_content.Children.Add(
				new CardView
				{
					Content = new Label
					{
						Text = "Hello #3"
					},
					HeightRequest = 300

				}
			);

		}
	}



}

