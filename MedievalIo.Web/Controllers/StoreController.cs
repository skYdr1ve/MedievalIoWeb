using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Models.Store;
using MedievalIoWeb.Controllers;
using MedievalIoWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MedievalIo.Web.Controllers
{
    public class StoreController : ApiController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("GetStoreItems")]
        public async Task<List<StoreItem>> GetStoreItems(string filter)
        {
            try
            {
                var result = await _storeService.GetStoreItemsAsync(filter, AppSettings.UserServiceEndPoint, UserToken);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("BuyItem")]
        public async Task<bool> BuyItem(BuyItemModel model)
        {
            return await _storeService.BuyItemAsync(model, AppSettings.UserServiceEndPoint, UserToken);
        }

        [HttpPost("EquipItem")]
        public async Task<bool> EquipItem(EquipItemModel model)
        {
            return await _storeService.EquipItemAsync(model, AppSettings.UserServiceEndPoint, UserToken);
        }

        [HttpGet("GetUserItems")]
        public async Task<List<UserItemInfo>> GetUserItems(string userId)
        {
            try
            {
                return await _storeService.GetUserItemsAsync(userId, AppSettings.UserServiceEndPoint, UserToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
