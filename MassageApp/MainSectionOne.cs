using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainSectionOne : CardView
	{
		public MainSectionOne()
		{

			StackLayout _content = new StackLayout();

			_content.Children.Add(
				new Label
				{
					Text = "section one"
				}
			);

			this.Content = _content;

		}
	}
}

