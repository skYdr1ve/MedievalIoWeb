using System.Threading.Tasks;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface IStoreClient
    {
        Task<StoreItemsResult> GetStoreItemsAsync(ApiRequestModel apiRequestModel, string filter);
        Task<bool> BuyItemAsync(ApiRequestModel apiRequestModel, BuyItemRequest model);
        Task<bool> EquipItemAsync(ApiRequestModel apiRequestModel, EquipItemRequest model);
        Task<UserItemsInfoResult> GetUserItemsAsync(ApiRequestModel apiRequestModel, string userId);
    }
}
