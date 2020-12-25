using System;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Clients
{
    public class WalletClient : BaseClient, IWalletClient
    {
        public async Task<WalletResult> GetAsync(ApiRequestModel apiRequestModel, string id)
        {
            var requestUrl = $"users/{id}/currencies";

            var requestBody = new { };

            using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<WalletResult>(response);
            }
        }
    }
}
