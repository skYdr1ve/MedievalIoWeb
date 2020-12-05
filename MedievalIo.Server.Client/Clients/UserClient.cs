using System;
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

            using (var response = await SendRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<AuthenticateResult>(response);
            }
        }

        public async Task<RegisterUserResult> SendRegistrationRequestAsync(ApiRequestModel apiRequestModel, RegistrationRequest contract)
		{
			var requestUrl = "users";

            using (var response = await SendRequestAsync(apiRequestModel, requestUrl, contract))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<RegisterUserResult>(response);
            }
        }
    }
}
