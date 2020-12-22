using MedievalIo.Services.Interfaces;
using MedievalIoWeb.Controllers;

namespace MedievalIo.Web.Controllers
{
    public class NewsController : ApiController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
    }
}
