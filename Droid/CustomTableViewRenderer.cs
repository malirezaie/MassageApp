using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using MassageApp.Droid;
[assembly: ExportRenderer(typeof(MassageApp.CustomTableView), typeof(MassageApp.CustomTableViewRenderer))]
namespace MassageApp
{
	public class CustomTableViewRenderer : TableViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
				return;

			//Control.DividerHeight = 0;


			var listView = Control as global::Android.Widget.ListView;

			listView.Divider = new ColorDrawable(Android.Graphics.Color.Transparent);
			listView.DividerHeight = 0;

		}
	}
}