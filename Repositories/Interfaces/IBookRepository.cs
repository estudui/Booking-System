using BookSystemApi.Dto.Book;

namespace BookSystemApi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<int> AddBookAsyncRaw(ReqBook book);
    }
}