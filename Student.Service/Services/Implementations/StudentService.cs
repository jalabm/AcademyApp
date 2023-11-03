using Academy.Core.Enums;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Core.Models.BaseModels;
using Academy.Service.Services.Interfaces;
using Academy.Core.Models;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository = new StudentRepository();

        public async Task<string> CreateAsync(string fullName, string group, double average, EducationCategory educationCategory)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "FullName can not be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";
            if (average <= 0)
                return "Average can not be less than 0";

           Student student = new Student(fullName, group, average, educationCategory);
           await _studentRepository.AddAsync(student);

            return "Created successfully";
        }

        public async Task GetAllAsync()
        {

            List<Student> students = await _studentRepository.GetAllAsync();
            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id},Fullname:{student.FullName},Group:{student.Group},Average:{student.Average}, educationCategory:{student.EducationCategory},CreatedAt:{student.CreatedAt},UpdatedAt:{student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null) ;
            return "student not found";
        }

        public Task<string> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(string fullName, string group, double average, EducationCategory educationCategory)
        {
            throw new NotImplementedException();
        }
    }
}

