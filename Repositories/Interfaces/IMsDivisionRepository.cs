using BookSystemApi.Dto.Division;

namespace BookSystemApi.Repositories.Interfaces
{
    public interface IMsDivisionRepository
    {
        Task<IEnumerable<DivisionDto>> GetDivisionAsyncRaw();
        Task<int> AddDivisionAsyncRaw(string name);
    }
}