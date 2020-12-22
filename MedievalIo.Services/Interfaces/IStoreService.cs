using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Services.Models.Store;

namespace MedievalIo.Services.Interfaces
{
    public interface IStoreService
    {
        Task<List<StoreItem>> GetStoreItemsAsync(string filter, string endPoint, string token);
    }
}
