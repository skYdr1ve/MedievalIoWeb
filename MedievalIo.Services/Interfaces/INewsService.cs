using System.Collections.Generic;
using System.Threading.Tasks;

using MedievalIo.Server.Client.Models;
using MedievalIo.Services.Models.Authentication;
using MedievalIo.Services.Models.News;

namespace MedievalIo.Services.Interfaces
{
    public interface INewsService
    {
        Task<bool> CreateNewsAsync(CreateNewsModel model, string endPoint);
        Task<IEnumerable<NewsModel>> ListNewsRequestAsync(ListNewsModel model, string endPoint);
        Task<bool> UpdateNewsRequestAsync(UpdateNewsModel model, string endPoint);
        Task<NewsModel> ReadNewsRequestAsync(ReadNewsModel model, string endPoint);
    }
}
