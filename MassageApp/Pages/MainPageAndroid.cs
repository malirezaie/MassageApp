using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class MainPageAndroid : StackLayout
	{
		public MainPageAndroid()
		{

			this.Children.Add(
				new MainSectionOne()
			);

			this.Children.Add(
				new MainSectionTwo()
			);

			this.Children.Add(
				new MainSectionThree()
			);

			this.Children.Add(
				new BookButton()
			);

		}
	}

}

