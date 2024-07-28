
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class CountryService : ICountryService
    {
        private readonly ICountryReadRepository countryReadRepository;
        public CountryService(ICountryRepository countryRepository) { 
            this.countryReadRepository = countryRepository;
        }
        public async Task<IList<Country>> GetCountryList()
        {
            return await countryReadRepository.GetLIstAsync();
        }
    }
}
