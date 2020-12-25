using System;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Clients
{
    public class StoreClient : BaseClient, IStoreClient
    {
        public async Task<StoreItemsResult> GetStoreItemsAsync(ApiRequestModel apiRequestModel, string filter)
        {
            var requestUrl = $"store_items{filter}";

            var requestBody = new { };

            using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<StoreItemsResult>(response);
            }
        }

        public async Task<bool> BuyItemAsync(ApiRequestModel apiRequestModel, BuyItemRequest model)
        {
            var requestUrl = "store_items/buy";

            var requestBody = new
            {
                user_id = model.UserId,
                item_id = model.ItemId
            };

            using (var response = await SendPostRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
        }

        public async Task<bool> EquipItemAsync(ApiRequestModel apiRequestModel, EquipItemRequest model)
        {
            var requestUrl = "store_items/equip";

            var requestBody = new
            {
                user_id = model.UserId,
                item_id = model.ItemId
            };

            using (var response = await SendPostRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
        }

        public async Task<UserItemsInfoResult> GetUserItemsAsync(ApiRequestModel apiRequestModel, string userId)
        {
            var requestUrl = $"store_items/user/{userId}";

            var requestBody = new { };

            using (var response = await SendGetRequestAsync(apiRequestModel, requestUrl, requestBody))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Server API throw exception with code {response.StatusCode}: {response.ReasonPhrase}");
                }

                return await GetResponse<UserItemsInfoResult>(response);
            }
        }
    }
}
