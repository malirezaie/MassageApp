using System;
using System.Threading.Tasks;

namespace MassageApp.Provider
{
	public interface IAuthService
	{
		Task<string> LinkTimeKit();
	}
}
