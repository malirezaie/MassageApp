using System.Diagnostics;
using System.Threading.Tasks;
using MassageApp.Helpers;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace MassageApp
{
	public class App : Application
	{
		public static double ScreenWidth;
		public static double ScreenHeight;
		public const string AppName = "MassageApp";
		public static MobileServiceClient MobileService;
		public static MobileServiceUser AuthenticatedUser;
		public MainMasterDetail mainMasterDetail;

		public App()
		{
			mainMasterDetail = new MainMasterDetail();
			MainPage = mainMasterDetail;

		}

		protected override async void OnStart()
		{
			bool firstStart = Settings.IsFirstStart();
			await InitMobileService(firstStart);//(showSettingsPage: firstStart, showLoginDialog: firstStart);
		}

		internal async Task InitMobileService(bool showLoginDialog)//,bool showSettingsPage)
		{

			var authHandler = new AuthHandler();
			MobileService =
				new MobileServiceClient(Settings.Current.MobileAppUrl, authHandler);

			authHandler.Client = MobileService;
			AuthenticatedUser = MobileService.CurrentUser;

			//await InitLocalStoreAsync(LocalDbFilename);
			//InitLocalTables();

			IPlatform platform = DependencyService.Get<IPlatform>();
			//DataFilesPath = await platform.GetDataFilesPath();

			if (showLoginDialog)
			{
				//	await Utils.PopulateDefaultsAsync();

				await DoLoginAsync();

				Debug.WriteLine("*** DoLoginAsync complete");

				//MainPage = new NavigationPage( new MainMasterDetail());
			}
			else {
				// user has already chosen an authentication type, so re-authenticate
				await AuthHandler.DoLoginAsync(Settings.Current.AuthenticationType);

				//MainPage = new NavigationPage(new MainMasterDetail());
			}
		}


		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		private async Task DoLoginAsync()
		{
			var loginPage = new LoginPage();
			await MainPage.Navigation.PushModalAsync(loginPage);
			Settings.Current.AuthenticationType = await loginPage.GetResultAsync();

		}
	}
}