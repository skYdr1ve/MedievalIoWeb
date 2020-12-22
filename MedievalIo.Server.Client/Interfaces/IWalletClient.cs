using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedievalIo.Server.Client.Models;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface IWalletClient
    {
        Task<WalletResult> GetAsync(ApiRequestModel apiRequestModel, string id);
    }
}
