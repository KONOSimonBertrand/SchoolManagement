using SchoolManagement.Core.Model;

namespace SchoolManagement.Core.Repositories
{
    public interface ICountryReadRepository
    {
        public Task<IList<Country>> GetLIstAsync();

    }
}