using Academy.Core.Enums;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
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
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _studentRepository.AddAsync(student);

            return "Student created successfully";
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
            if (student == null) 
                   return "student not found";
            Console.WriteLine($"Id:{student.Id},Fullname:{student.FullName},Group:{student.Group},Average:{student.Average}, educationCategory:{student.EducationCategory},CreatedAt:{student.CreatedAt},UpdatedAt:{student.UpdatedAt}");
            return "Successfully Process";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "student not found";

             await _studentRepository.RemoveAsync(student);
            return "Student removed Successfully";

        }

        public async Task<string> UpdateAsync( string id,string fullName, string group, double average, EducationCategory educationCategory)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student can not found";

            if (string.IsNullOrWhiteSpace(fullName))
                return "FullName can not be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";
            if (average <= 0)
                return "Average can not be less than 0";

            student.FullName = fullName;
            student.Group = group;
            student.Average = average;
            student.EducationCategory = educationCategory;
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Student updated Successfully";
        }
    }
}

