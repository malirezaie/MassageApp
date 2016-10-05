using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using MassageApp.Helpers;
using MassageApp.Client.Model;

namespace MassageApp
{
	class AuthHandler : DelegatingHandler
	{
		public IMobileServiceClient Client { get; set; }

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (this.Client == null)
			{
				throw new InvalidOperationException("Make sure to set the 'Client' property in this handler before using it.");
			}

			// Cloning the request, in case we need to send it again
			var clonedRequest = await CloneRequestAsync(request);
			var response = await base.SendAsync(clonedRequest, cancellationToken);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				try
				{
					AuthStore.DeleteTokenCache(); // cached token was invalid, so should clear it
					await DoLoginAsync(Settings.Current.AuthenticationType);

					clonedRequest = await CloneRequestAsync(request);

					clonedRequest.Headers.Remove("X-ZUMO-AUTH");
					clonedRequest.Headers.Add("X-ZUMO-AUTH", Client.CurrentUser.MobileServiceAuthenticationToken);

					// Resend the request
					response = await base.SendAsync(clonedRequest, cancellationToken);
				}
				catch (InvalidOperationException)
				{
					// user cancelled auth, so return the original response
					return response;
				}
			}

			return response;
		}

		public static async Task DoLoginAsync(Settings.AuthOption authOption)
		{
			//if (authOption == Settings.AuthOption.GuestAccess)
			//{
			//	Settings.Current.CurrentUserId = Settings.Current.DefaultUserId;
			//	return; // can't authenticate
			//}

			var mobileClient = DependencyService.Get<IPlatform>();

			var user =
				authOption == Settings.AuthOption.Facebook ?
					await LoginFacebookAsync(mobileClient) :
					await mobileClient.LoginAsync(MobileServiceAuthenticationProvider.Google);

			App.AuthenticatedUser = user;
			System.Diagnostics.Debug.WriteLine("Authenticated with user: " + user.UserId);

			if (string.IsNullOrEmpty(Settings.Current.CurrentUser.firstName))
			{
				Settings.Current.CurrentUser =
					await App.MobileService.InvokeApiAsync<User>(
					"User",
					HttpMethod.Get,
					null);
				
				Debug.WriteLine($"Set current userID to: {Settings.Current.CurrentUser.Id}");
			}

			AuthStore.CacheAuthToken(user);
		}

		private static Task<MobileServiceUser> LoginFacebookAsync(IPlatform mobileClient)
		{
			// use server flow if the service URL has been customized
			return //Settings.IsDefaultServiceUrl() ?
				//mobileClient.LoginFacebookAsync();//:
				mobileClient.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
		}

		private async Task<HttpRequestMessage> CloneRequestAsync(HttpRequestMessage request)
		{
			var result = new HttpRequestMessage(request.Method, request.RequestUri);
			foreach (var header in request.Headers)
			{
				result.Headers.Add(header.Key, header.Value);
			}

			if (request.Content != null && request.Content.Headers.ContentType != null)
			{
				var requestBody = await request.Content.ReadAsStringAsync();
				var mediaType = request.Content.Headers.ContentType.MediaType;
				result.Content = new StringContent(requestBody, Encoding.UTF8, mediaType);
				foreach (var header in request.Content.Headers)
				{
					if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
					{
						result.Content.Headers.Add(header.Key, header.Value);
					}
				}
			}

			return result;
		}
	}
}

