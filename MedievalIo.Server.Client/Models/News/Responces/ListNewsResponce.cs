using Common.Pagination;
using System.Collections.Generic;

namespace MedievalIo.Server.Client.Models.News.Responces
{
    public class ListNewsResponce
    {
        public IEnumerable<NewsEntity> NewsList { get; set; }
        public Page Page { get; set; }
    }
}
