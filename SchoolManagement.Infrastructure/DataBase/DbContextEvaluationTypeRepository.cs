

using MySqlX.XDevAPI.Common;
using SchoolManagement.Application.EvaluationTypes;
using SchoolManagement.Core.Model;

namespace SchoolManagement.Infrastructure.DataBase
{
    public class DbContextEvaluationTypeRepository : IEvaluationTypeRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextEvaluationTypeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(EvaluationType evaluationType)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EvaluationTypes.Add(evaluationType);
            var result=appDbContext.SaveChanges();
            await Task.Delay(0);
            return result>0;

        }

        public async Task<EvaluationType?> GetAsync(string code)
        {
            var result=appDbContext.EvaluationTypes.FirstOrDefault(x => x.Code == code);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<EvaluationType>> GetListAsync()
        {
            var result = appDbContext.EvaluationTypes.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(EvaluationType evaluationType)
        {
            appDbContext.ChangeTracker.Clear();
            appDbContext.EvaluationTypes.Update(evaluationType);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;

        }
    }
}
