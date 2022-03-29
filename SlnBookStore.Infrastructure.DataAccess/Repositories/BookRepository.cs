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

        public Book GetBookById(string id) {
            var book = _bookDBContext.Books.Where(x => x.Active == true && x.Id == id).FirstOrDefault();

            return book;
        }

        public Book Add(Book book)
        {
            book.Id = Guid.NewGuid().ToString();
            book.Active = true;
            book.PublicationDate = DateTime.Now;
            
            _bookDBContext.Books.Add(book);
            return _bookDBContext.SaveChanges() > 0 ? book : new Book();
        }

        public bool Update(Book book) {
            Book bookToModify = GetBookById(book.Id);

            bookToModify.CategoryId = book.CategoryId;
            bookToModify.Name = book.Name;
            bookToModify.Author = book.Author;

            return _bookDBContext.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(string id)
        {
            Book bookToModify = GetBookById(id);

            bookToModify.Active = false;

            return _bookDBContext.SaveChanges() > 0 ? true : false;
        }
    }
}
