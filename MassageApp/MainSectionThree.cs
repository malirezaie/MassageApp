using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionThree : CardView
	{
		public MainSectionThree()
		{

			HeightRequest = 300;

			StackLayout _content = new StackLayout();

			_content.Children.Add(
				new Label
				{
					Text = "section three"
				}
			);

			this.Content = _content;

		}
	}
}

