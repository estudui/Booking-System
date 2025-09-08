using BookSystemApi.Dto.Division;
using BookSystemApi.Repositories.Interfaces;
using BookSystemApi.Services.Interfaces;

namespace BookSystemApi.Services
{
    public class MsDivisionService : IMsDivisionService
    {
        private readonly IMsDivisionRepository _divisionRepository;

        public MsDivisionService(IMsDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }

        public async Task<IEnumerable<DivisionDto>> GetAllDivisionAsyncRaw()
        {
            var division = await _divisionRepository.GetDivisionAsyncRaw();
            if (division == null)
            {
                throw new KeyNotFoundException("Division not found");
            }
            return division;
            // return division ?? throw new KeyNotFoundException("Division not found");
        }

        public async Task<string> AddDivisionAsynRaw(string name)
        {
            var insert = await _divisionRepository.AddDivisionAsyncRaw(name);
            return insert > 0 ? "Success" : "Failed";
        }
    }
}