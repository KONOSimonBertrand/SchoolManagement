using SchoolManagement.Core.Model;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.DataBase;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextSchoolRoomRepositoty : ISchoolRoomRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSchoolRoomRepositoty(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(SchoolRoom room)
        {
            appDbContext.ChangeTracker.Clear();
            room.SchoolClass = appDbContext.SchoolClasses.FirstOrDefault(c => c.Id == room.SchoolClass.Id);
            appDbContext.ShoolRooms.Add(room);
            var result = appDbContext.SaveChanges();
            await Task.Delay(0);
            return result > 0;
        }

        public async Task<SchoolRoom?> GetAsync(string name)
        {
            var result = appDbContext.ShoolRooms.FirstOrDefault(r => r.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolRoom>> GetListAsync()
        {
            var result = appDbContext.ShoolRooms.ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolRoom room)
        {
            bool isDone = false;
            appDbContext.ChangeTracker.Clear();
            var item = appDbContext.ShoolRooms.FirstOrDefault(r => r.Id == room.Id);
            if (item != null)
            {
                item.Id = room.Id;
                item.Name = room.Name;
                item.Sequence = room.Sequence;
                item.SchoolClass = appDbContext.SchoolClasses.FirstOrDefault(x => x.Id == room.SchoolClass.Id);
                appDbContext.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }
    }
}
