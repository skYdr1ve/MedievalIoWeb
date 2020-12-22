using System.Threading.Tasks;
using MedievalIo.Services.Models.Wallet;

namespace MedievalIo.Services.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> GetAsync(string id, string endPoint, string token);
    }
}
