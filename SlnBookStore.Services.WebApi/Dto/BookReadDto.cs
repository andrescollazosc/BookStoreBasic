﻿namespace SlnBookStore.Services.WebApi.Dto
{
    public class BookReadDto
    {
        public string Id { get; set; } = null!;
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Isbn { get; set; }
        public string? Author { get; set; }
    }
}
