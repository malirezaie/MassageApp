using Xamarin.Forms;

namespace MassageApp
{
	public class DetailPageCS : TabbedPage
	{
		public DetailPageCS ()
		{
			this.Title = "MassageApp";

			var navigationPage = new SchedulePageCS ();

			if (Device.OS == TargetPlatform.iOS)
			{
				navigationPage.Icon = "schedule.png";
			}
			navigationPage.Title = "Schedule";

			Children.Add (new MainMassagePage ());
			Children.Add (navigationPage);
			Children.Add (new SettingsPageCS ());

		}
	}
}
