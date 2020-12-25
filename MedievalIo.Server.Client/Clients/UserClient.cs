using System;
using System.Collections.Generic;
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

            using (var response = await SendPostRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<AuthenticateResult>(response);
            }
        }

        public async Task<(bool, string)> SendRegistrationRequestAsync(ApiRequestModel apiRequestModel, RegistrationRequest contract)
		{
			var requestUrl = "users";

            using (var response = await SendPostRequestAsync(apiRequestModel, requestUrl, contract))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return (false, response.ReasonPhrase);
                }

                return (true, "Success");
            }
        }

        public async Task<StatisticsResult> GetStatisticsAsync(ApiRequestModel apiRequestModel, string filter)
        {
            var requestUrl = $"users{filter}";

            var requestBody = new { };

            using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<StatisticsResult>(response);
            }
        }
    }
}
