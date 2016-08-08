using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionTwo : CardView
	{
		public MainSectionTwo()
		{

			HeightRequest = 300;

			StackLayout _content = new StackLayout();

			_content.Children.Add(
				new Label
				{
					Text = "section two"
				}
			);

			this.Content = _content;

		}
	}
}

