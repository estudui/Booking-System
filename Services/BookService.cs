using BookSystemApi.Dto.Book;
using BookSystemApi.Repositories.Interfaces;
using BookSystemApi.Services.Interfaces;

namespace BookSystemApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> AddBookAsynRaw(ReqBook book)
        {
            var insert = await _bookRepository.AddBookAsyncRaw(book);
            return insert > 0 ? "Success" : "Failed";
        }
    }
}