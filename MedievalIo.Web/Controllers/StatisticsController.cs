using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Models.User;
using MedievalIoWeb.Controllers;
using MedievalIoWeb.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MedievalIo.Web.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("GetStatistics")]
        public async Task<List<User>> GetStatistics(string filter)
        {
            try
            {
                var result = await _statisticsService.GetStatisticsAsync(filter, AppSettings.UserServiceEndPoint, UserToken);

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
