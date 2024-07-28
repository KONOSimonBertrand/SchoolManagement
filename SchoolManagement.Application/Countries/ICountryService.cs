using SchoolManagement.Core.Model;

namespace SchoolManagement.Application
{
    public interface ICountryService
    {
        public Task<IList<Country>> GetCountryList();
    }
}