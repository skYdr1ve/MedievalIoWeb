using System;
using System.Collections.Generic;
using System.Linq;

using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Store;

namespace MedievalIo.Services.Mappers
{
    public static class StoreMapper
    {
        public static List<UserItemInfo> Map(UserItemsInfoResult model)
        {
            return model?.Items?.Select(x => new UserItemInfo
            {
                ItemId = x.ItemId,
                Equipped = x.Equipped
            }).ToList();
        }

        public static List<StoreItem> Map(StoreItemsResult model)
        {
            return model?.Results?.Select(x => new StoreItem
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

        public static BuyItemRequest Map(BuyItemModel model)
        {
            return new BuyItemRequest
            {
                ItemId = model.ItemId,
                UserId = model.UserId
            };
        }

        public static EquipItemRequest Map(EquipItemModel model)
        {
            return new EquipItemRequest
            {
                ItemId = model.ItemId,
                UserId = model.UserId
            };
        }
    }
}
