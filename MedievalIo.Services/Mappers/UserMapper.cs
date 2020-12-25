using System;
using System.Collections.Generic;
using System.Linq;
using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Authentication;
using MedievalIo.Services.Models.Store;
using MedievalIo.Services.Models.User;

namespace MedievalIo.Services.Mappers
{
    public static class UserMapper
    {
        public static RegistrationRequest Map(RegistrationModel model)
        {
            return new RegistrationRequest
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }

        public static List<User> Map(StatisticsResult model)
        {
            return model.Results.Select(x => new User
            {
                Name = x.Name,
                Stats = new UserStats
                {
                    Id = x.Stats.Id,
                    Games = x.Stats.Games,
                    Wins = x.Stats.Wins,
                    Top5 = x.Stats.Top5,
                    Kills = x.Stats.Kills
                }
            }).ToList();
        }
    }
}
