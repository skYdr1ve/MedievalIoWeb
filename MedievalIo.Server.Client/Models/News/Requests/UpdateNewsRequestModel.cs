using System;

namespace MedievalIo.Server.Client.Models.News.Requests
{
    public class UpdateNewsRequestModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
