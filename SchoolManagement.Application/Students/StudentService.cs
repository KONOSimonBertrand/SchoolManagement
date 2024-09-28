


using SchoolManagement.Core.Model;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application
{
    public class StudentService : IStudentService
    {
        private readonly IStudentReadRepository studentReadRepository;
        private readonly IStudentWriteRepository studentWriteRepository;
        private readonly IGenerateIdNumberService generateIdNumberService;
        private readonly ISchoolYearReadRepository schoolYearReadRepository;
        public StudentService(IStudentRepository studentRepository, IGenerateIdNumberService generateIdNumberService, ISchoolYearRepository schoolYearRepository)
        {
            this.studentReadRepository = studentRepository;
            this.studentWriteRepository = studentRepository;
            this.generateIdNumberService = generateIdNumberService;
            this.schoolYearReadRepository = schoolYearRepository;
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
          return await studentWriteRepository.AddStudentAsync(student);  
        }

        public async Task<string> GenerateStudentIdNumberAsync()
        {
            string idNumber;
            var lastStudent = await GetLastStudentAsync();
            SchoolYear? lastSchoolYear = await schoolYearReadRepository.GetLastSchoolYearAsync();
            int lastNumber = 0;
            int year = DateTime.Now.Year;
            if (lastStudent != null)
            {
                lastNumber = int.Parse(lastStudent.IdNumber.Substring(3, 4));
            }
            if (lastSchoolYear != null)
            {
                year = int.Parse(lastSchoolYear.Name.Substring(0, 4));
            }
            lastNumber++;
            idNumber = generateIdNumberService.GenerateNextIdNumberWithFourDigit('E', lastNumber, year);
            await Task.Delay(0);
            return idNumber;
        }

        public async Task<Student> GetLastStudentAsync()
        {
            return await studentReadRepository.GetLastStudentAsync();
        }

        public async Task<Student> GetStudentAsync(string idNumber)
        {
            return await studentReadRepository.GetStudentAsync(idNumber);
        }

        public async Task<List<Student>> GetStudentListsync()
        {
            return await studentReadRepository.GetStudentListAsync();
        }

        public async Task<bool> SaveStudentPictureAsync(int studentId, string urlPicture)
        {
            return await studentWriteRepository.AddStudentPictureAsync(studentId, urlPicture);
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            return await studentWriteRepository.UpdateStudentAsync(student);
        }
    }
}
