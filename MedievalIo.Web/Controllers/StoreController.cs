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
    }
}
