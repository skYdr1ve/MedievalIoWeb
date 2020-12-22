using System;
using System.Collections.Generic;
using System.Linq;

using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Store;

namespace MedievalIo.Services.Mappers
{
    public static class StoreMapper
    {
        public static List<StoreItem> Map(StoreItemsResult model)
        {
            return model.Results.Select(x => new StoreItem
            {
                Id = Guid.Parse(x.Id),
                Name = x.Name,
                Description = x.Description,
                Type = x.Type,
                CoinsPrice = x.CoinsPrice,
                GemsPrice = x.GemsPrice,
                ImageId = x.ImageId,
                OnSale = x.OnSale,
                SaleCoinsPrice = x.SaleCoinsPrice,
                SaleGemsPrice = x.SaleGemsPrice
            }).ToList();
        }
    }
}
