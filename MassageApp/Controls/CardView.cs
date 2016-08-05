using System;
using Xamarin.Forms;

namespace MassageApp
{
	public class CardView : Frame
	{
		public CardView()
		{
			Padding = 10;
			Margin = 10;

			if (Device.OS == TargetPlatform.iOS)
			{
				HasShadow = false;
				OutlineColor = Color.Transparent;
				BackgroundColor = Color.Transparent;
			}
		}
	}
}


