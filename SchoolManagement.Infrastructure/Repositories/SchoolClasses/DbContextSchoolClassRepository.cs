
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.DataBase;
using System;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DbContextSchoolClassRepository : ISchoolClassRepository
    {
        private readonly AppDbContext appDbContext;
        public DbContextSchoolClassRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> AddAsync(SchoolClass schoolClass)
        {
            appDbContext.ChangeTracker.Clear();
            schoolClass.Group = appDbContext.SchoolGroups.FirstOrDefault(g => g.Id == schoolClass.Group.Id);
            appDbContext.SchoolClasses.Add(schoolClass);
            var resut = appDbContext.SaveChanges();
            await Task.Delay(0);
            return resut > 0;
        }

        public async Task<bool> AddSubjectAsync(ClassSubject classSubject)
        {
            appDbContext.ChangeTracker.Clear();
            classSubject.Subject = appDbContext.Subjects.FirstOrDefault(g => g.Id == classSubject.SubjectId);
            classSubject.Class= appDbContext.SchoolClasses.FirstOrDefault(g => g.Id == classSubject.GroupId);
            classSubject.Group = appDbContext.SubjectGroups.FirstOrDefault(g => g.Id == classSubject.GroupId);
            appDbContext.ClassSubjects.Add(classSubject);
            var resut = appDbContext.SaveChanges();
            await Task.Delay(0);
            return resut > 0;
        }

        public async Task<bool> DeleteSubjectAsync(int classId, int subjectId, int bookId)
        {
            appDbContext.ChangeTracker.Clear();
            var subject=appDbContext.ClassSubjects.FirstOrDefault(x=>x.ClassId == classId && x.SubjectId==subjectId && x.BookId==bookId);
            appDbContext.ClassSubjects.Remove(subject);
            var resut = appDbContext.SaveChanges();
            await Task.Delay(0);
            return resut > 0;
        }

        public async Task<SchoolClass?> GetAsync(string name)
        {
            var result = appDbContext.SchoolClasses.Include(g => g.Group).FirstOrDefault(c => c.Name == name);
            await Task.Delay(0);
            return result;
        }

        public async Task<IList<SchoolClass>> GetListAsync()
        {
            var result = appDbContext.SchoolClasses.Include(g => g.Group).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<ClassSubject> GetSubjectAsync(int classId, int subjectId, int bookId)
        {
            var result= appDbContext.ClassSubjects.FirstOrDefault(x => x.ClassId == classId && x.SubjectId == subjectId && x.BookId == bookId);
            await Task.Delay(0);
            return result ;
        }

        public async Task<IList<ClassSubject>> GetSubjectListAsync(int classId)
        {
            var result = appDbContext.ClassSubjects.Include(x=>x.Class).Include(g => g.Group).ToList();
            await Task.Delay(0);
            return result;
        }

        public async Task<bool> UpdateAsync(SchoolClass schoolClass)
        {
            bool isDone = false;
            var item = appDbContext.SchoolClasses.FirstOrDefault(c => c.Id == schoolClass.Id);
            if (item != null)
            {
                appDbContext.ChangeTracker.Clear();
                item.Id = schoolClass.Id;
                item.Name = schoolClass.Name;
                item.Sequence = schoolClass.Sequence;
                item.Group = schoolClass.Group = appDbContext.SchoolGroups.FirstOrDefault(g => g.Id == schoolClass.Group.Id);
                appDbContext.SchoolClasses.Update(item);
                if (appDbContext.SaveChanges() > 0) isDone = true;
            }
            await Task.Delay(0);
            return isDone;
        }

        public Task<bool> UpdateSubjectAsync(ClassSubject classSubject)
        {
            throw new NotImplementedException();
        }
    }
}
