using System;
using System.Threading.Tasks;
using MassageApp.Client.Model;

namespace MassageApp
{
	public interface IStripe
	{
		Task<string> CreateToken();
		Task<CreditCard> DisplayCardView();

	}
}

