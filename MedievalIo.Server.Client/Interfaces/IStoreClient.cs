using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface IStoreClient
    {
        Task<StoreItemsResult> GetStoreItemsAsync(ApiRequestModel apiRequestModel, string filter);
    }
}
