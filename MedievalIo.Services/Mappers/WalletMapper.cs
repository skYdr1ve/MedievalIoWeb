using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Wallet;

namespace MedievalIo.Services.Mappers
{
    public static class WalletMapper
    {
        public static Wallet Map(WalletResult model)
        {
            return new Wallet
            {
                Coins = model.Coins,
                Gems = model.Gems
            };
        }
    }
}
