using System.Threading.Tasks;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Models.Wallet;
using Microsoft.AspNetCore.Mvc;
using MedievalIoWeb.Controllers;
using MedievalIoWeb.Helpers;

namespace MedievalIo.Web.Controllers
{
    public class WalletController : ApiController
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("GetWallet")]
        public async Task<Wallet> GetWallet()
        {
            var result = await _walletService.GetAsync(Id, AppSettings.UserServiceEndPoint, UserToken);

            return result;
        }
    }
}
