using System.Threading.Tasks;

using MedievalIo.Server.Client.Models;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models.News.Responses;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface INewsClient
    {
        Task<CreateNewsResponse> CreateNewsAsync(ApiRequestModel apiRequestModel, CreateNewsRequestModel model);
        Task<ListNewsResponse> ListNewsRequestAsync(ApiRequestModel apiRequestModel, ListNewsRequestModel model);
        Task<UpdateNewsResponse> UpdateNewsRequestAsync(ApiRequestModel apiRequestModel, UpdateNewsRequestModel model);
        Task<ReadNewsResponse> ReadNewsRequestAsync(ApiRequestModel apiRequestModel, ReadNewsRequestModel model);
    }
}
