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
				Margin = 0;
				HasShadow = false;
				OutlineColor = Color.Transparent;
				BackgroundColor = Color.Transparent;
			}
		}
	}
}


