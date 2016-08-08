
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MassageApp.CustomButton), typeof(MassageApp.Droid.CustomButtonRenderer))]
namespace MassageApp.Droid
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);
			Android.Widget.Button thisButton = Control as Android.Widget.Button;
			thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
			{
				if (e2.Event.Action == MotionEventActions.Down)
					System.Diagnostics.Debug.WriteLine("TouchDownEvent");
				else if (e2.Event.Action == MotionEventActions.Up)
					System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};

		}
	}
}