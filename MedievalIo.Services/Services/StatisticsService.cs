using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Interfaces;
using MedievalIo.Services.Interfaces;
using MedievalIo.Services.Mappers;
using MedievalIo.Services.Models.User;

namespace MedievalIo.Services.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserClient _userClient;

        public StatisticsService(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public async Task<List<User>> GetStatisticsAsync(string filter, string endPoint, string token)
        {
            var apiRequestModel = AuthenticationMapper.MapToApiRequestModel(endPoint, token);

                var statistics = await _userClient.GetStatisticsAsync(apiRequestModel, filter);

                return UserMapper.Map(statistics);
        }
    }
}
