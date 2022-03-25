using SlnBookStore.Infrastructure.DataAccess.Models;

namespace SlnBookStore.Infrastructure.DataAccess.Repositories
{
    public class BookRepository
    {
        // S.O.L.I.D
        private readonly bookDBContext _bookDBContext;

        public BookRepository()
        {
            _bookDBContext = new bookDBContext();
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _bookDBContext.Books.Where(x => x.Active == true);

            return books;
        }

        public Book Add(Book book)
        {
            book.Id = Guid.NewGuid().ToString();
            book.Active = true;
            book.PublicationDate = DateTime.Now;
            
            _bookDBContext.Books.Add(book);
            return _bookDBContext.SaveChanges() > 0 ? book : new Book();
        }

    }
}
