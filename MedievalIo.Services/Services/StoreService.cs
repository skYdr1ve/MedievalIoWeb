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
    }
}
