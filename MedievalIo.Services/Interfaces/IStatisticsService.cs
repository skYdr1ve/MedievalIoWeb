using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Services.Models.User;

namespace MedievalIo.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<List<User>> GetStatisticsAsync(string filter, string endPoint, string token);
    }
}
