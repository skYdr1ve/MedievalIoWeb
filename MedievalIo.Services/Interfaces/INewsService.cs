using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Services.Models.News;

namespace MedievalIo.Services.Interfaces
{
    public interface INewsService
    {
        Task<bool> CreateNewsAsync(CreateNewsModel model, string endPoint, string token);
        Task<List<NewsModel>> ListNewsRequestAsync(string endPoint, string token);
        Task<bool> UpdateNewsRequestAsync(UpdateNewsModel model, string endPoint, string token);
        Task<NewsModel> ReadNewsRequestAsync(ReadNewsModel model, string endPoint, string token);
    }
}
