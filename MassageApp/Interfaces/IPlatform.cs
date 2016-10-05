//using Microsoft.WindowsAzure.MobileServices.Files;
//using Microsoft.WindowsAzure.MobileServices.Files.Metadata;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;

namespace MassageApp
{
	public interface IPlatform
	{
		Task<MobileServiceUser> LoginAsync(MobileServiceAuthenticationProvider provider);

		Task<MobileServiceUser> LoginFacebookAsync();

		AccountStore GetAccountStore();

		Task LogoutAsync();
	}
}

