using MedievalIo.Server.Client.Models;
using MedievalIo.Server.Client.Models.News.Requests;
using MedievalIo.Server.Client.Models.News.Responces;
using System.Threading.Tasks;

namespace MedievalIo.Server.Client.Interfaces
{
    public interface INewsClient
    {
        Task<CreateNewsResponce> CreateNewsAsync(ApiRequestModel apiRequestModel, CreateNewsRequestModel model);
        Task<ListNewsResponce> ListNewsRequestAsync(ApiRequestModel apiRequestModel, ListNewsRequestModel model);
        Task<UpdateNewsResponce> UpdateNewsRequestAsync(ApiRequestModel apiRequestModel, UpdateNewsRequestModel model);
        Task<ReadNewsResponce> ReadNewsRequestAsync(ApiRequestModel apiRequestModel, ReadNewsRequestModel model);
    }
}
