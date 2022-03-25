namespace SlnBookStore.Infrastructure.DataAccess.Models
{
    public partial class Book
    {
        public string Id { get; set; } = null!;
        public string? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Isbn { get; set; }
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool? Active { get; set; }

        public virtual Category? Category { get; set; }
    }
}
