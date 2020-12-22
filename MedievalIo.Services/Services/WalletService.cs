using System.Threading.Tasks;
using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.Wallet;

namespace MedievalIo.Services.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletClient _walletClient;

        public WalletService(IWalletClient walletClient)
        {
            _walletClient = walletClient;
        }

        public async Task<Wallet> GetAsync(string id, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

            var wallet = await _walletClient.GetAsync(apiRequestModel, id);

            return WalletMapper.Map(wallet);
        }
    }
}
