using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Clients
{
	public class UserClient : BaseClient, IUserClient
	{
		public async Task<AuthenticateResult> AuthenticateUserAsync(ApiRequestModel apiRequestModel, string userEmail, string password)
		{
			var requestUrl = "users/login";

			var requestBody = new
			{
				id = userEmail,
                password
			};

			return await SendRequestAsync<AuthenticateResult>(apiRequestModel, requestUrl, requestBody);
		}

        public async Task<RegisterUserResult> SendRegistrationRequestAsync(ApiRequestModel apiRequestModel, RegistrationRequest contract)
		{
			var requestUrl = "user/register";

			return await SendRequestAsync<RegisterUserResult>(apiRequestModel, requestUrl, contract);
        }
    }
}
