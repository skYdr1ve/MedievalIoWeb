using System;

namespace MedievalIo.Services.Models.News
{
    public class NewsModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
