﻿using System;

namespace MedievalIo.Services.Models.News
{
    public class NewsEntity
    {
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }
}
