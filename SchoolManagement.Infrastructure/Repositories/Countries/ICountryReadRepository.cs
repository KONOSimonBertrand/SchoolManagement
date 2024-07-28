using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.Repositories
{
    public interface ICountryReadRepository
    {
        public Task<IList<Country>> GetLIstAsync();

    }
}