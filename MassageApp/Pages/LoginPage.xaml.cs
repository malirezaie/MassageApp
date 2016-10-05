using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using MassageApp.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MassageApp
{
	public partial class LoginPage : ContentPage
	{

		TaskCompletionSource<Settings.AuthOption> tcs;

		public LoginPage()
		{
			InitializeComponent();
		}

		public Task<Settings.AuthOption> GetResultAsync()
		{
			tcs = new TaskCompletionSource<Settings.AuthOption>();
			return tcs.Task;
		}

		private async void OnFBLoginClicked(object sender, EventArgs e)
		{
			await DoLoginAsync(Settings.AuthOption.Facebook);
		}

		private async void OnGoogLoginClicked(object sender, EventArgs e)
		{
			await DoLoginAsync(Settings.AuthOption.Google);
		}

		private async Task DoLoginAsync(Settings.AuthOption authOption)
		{
			try
			{
				await AuthHandler.DoLoginAsync(authOption);
				await LoginComplete(authOption);
			}
			catch (Exception)
			{
				// if user cancels, then show ERROR
				// TODO: ERROR 
			}
		}

		private async Task LoginComplete(Settings.AuthOption option)
		{
			//TODO: DependencyService.Get<IPlatform>().LogEvent("Login" + option);

			await Navigation.PopModalAsync();
			//await Navigation.PushModalAsync(new MainMasterDetail());

			tcs.TrySetResult(option);
		}

	}
}

