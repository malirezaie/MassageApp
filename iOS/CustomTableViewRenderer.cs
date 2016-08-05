using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

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

			var tableView = Control as UITableView;
			tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
		}
	}
}