using BookSystemApi.Dto.Division;

namespace BookSystemApi.Services.Interfaces
{
    public interface IMsDivisionService
    {
        Task<IEnumerable<DivisionDto>> GetAllDivisionAsyncRaw();
        Task<string> AddDivisionAsynRaw(string name);
    }
}