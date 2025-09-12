using BookSystemApi.Dto.Book;

namespace BookSystemApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<string> AddBookAsynRaw(ReqBook book);
    }
}