using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.Store;

namespace MedievalIo.Services.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreClient _storeClient;

        public StoreService(IStoreClient storeClient)
        {
            _storeClient = storeClient;
        }

        public async Task<List<StoreItem>> GetStoreItemsAsync(string filter, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var storeItems = await _storeClient.GetStoreItemsAsync(apiRequestModel, filter);

            return StoreMapper.Map(storeItems);
        }

        public async Task<bool> BuyItemAsync(BuyItemModel model, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var requestModel = StoreMapper.Map(model);

            return await _storeClient.BuyItemAsync(apiRequestModel, requestModel);
        }

        public async Task<bool> EquipItemAsync(EquipItemModel model, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var requestModel = StoreMapper.Map(model);

            return await _storeClient.EquipItemAsync(apiRequestModel, requestModel);
        }

        public async Task<List<UserItemInfo>> GetUserItemsAsync(string userId, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var usersItems = await _storeClient.GetUserItemsAsync(apiRequestModel, userId);

            return StoreMapper.Map(usersItems);
        }
    }
}
