using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Models.News;
using MedievalIo.Services.Models.Store;
using MedievalIoWeb.Controllers;
using MedievalIoWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MedievalIo.Web.Controllers
{
    public class NewsController : ApiController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetNews")]
        public async Task<List<NewsModel>> GetNews()
        {
            try
            {
                var result = await _newsService.ListNewsRequestAsync(AppSettings.UserServiceEndPoint, UserToken);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
