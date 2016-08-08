using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MassageApp.CustomButton), typeof(MassageApp.iOS.CustomButtonRenderer))]

namespace MassageApp.iOS
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			UIButton thisButton = Control as UIButton;
			thisButton.TouchDown += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchDownEvent");
			};
			thisButton.TouchUpInside += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};
		}
	}
}