using Academy.Core.Enums;
using Academy.Service.Services.Interfaces;
namespace Academy.Service.Services.Implementations
{
	public class MenuService
	{
        IStudentService studentService = new StudentService();
        public  async Task RunApp()
        {

            await Menu();

            string request = Console.ReadLine();
            while (request != "0")
            {
                switch (request)
                {
                    case "1":
                        await CreateStudent();
                        break;
                    case "2":
                       await UpdateStudent();
                        break;
                    case "3":
                        await  RemoveStudent();
                        break;
                    case "4":
                       await  Get();
                        break;
                    case "5":
                        await GetAllStudent();
                        break;
                    default:
                        Console.WriteLine("Menu in this number is not exist");
                        break;
                }
                await Menu();
                request = Console.ReadLine();
            }
        }
        async Task CreateStudent()
        {
           Console.WriteLine("Please add FullName");
           string fullName = Console.ReadLine();
           Console.WriteLine("Please add group");
           string Group = Console.ReadLine();
           Console.WriteLine("Please add Average");
           double.TryParse(Console.ReadLine(), out double Average);

           int i = 1;
           foreach (var item in Enum.GetValues(typeof(EducationCategory)))
           {
              Console.WriteLine($"{i}.{item}");
              i++;
           }

            bool IsExsist;
            int EnumIndex;
           do
           {
              Console.WriteLine("Please add EducationCategory");
              int.TryParse(Console.ReadLine(), out EnumIndex);
              IsExsist = Enum.IsDefined(typeof(EducationCategory), (EducationCategory)EnumIndex);
           } while (!IsExsist);

            string result = await studentService.CreateAsync(fullName, Group, Average, (EducationCategory)EnumIndex);
             Console.WriteLine(result);
        }
        async Task UpdateStudent()
        {
            Console.WriteLine("Please add Id");
            string Id = Console.ReadLine();
            Console.WriteLine("Please add FullName");
            string fullName = Console.ReadLine();
            Console.WriteLine("Please add group");
            string Group = Console.ReadLine();
            Console.WriteLine("Please add Average");
            double.TryParse(Console.ReadLine(), out double Average);

            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EducationCategory)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

            bool IsExsist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Please add EducationCategory");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                IsExsist = Enum.IsDefined(typeof(EducationCategory), (EducationCategory)EnumIndex);
            } while (!IsExsist);

            string result = await studentService.UpdateAsync(Id,fullName, Group, Average, (EducationCategory)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudent()
        {
            Console.WriteLine("Please add Id");
            string Id = Console.ReadLine();
           string result=await studentService.RemoveAsync(Id);
            Console.WriteLine(result);
        }
        async Task GetAllStudent()
        {
            await studentService.GetAllAsync();
        }
        async Task Get()
        {
            Console.WriteLine("Please add Id");
            string Id = Console.ReadLine();
            string result = await studentService.GetAsync(Id);
            Console.WriteLine(result);
        }
        async Task Menu()
        {
          Console.WriteLine("1.Create");
          Console.WriteLine("2.Update");
          Console.WriteLine("3.Remove");
          Console.WriteLine("4.Get");
          Console.WriteLine("5.GetAll");
          Console.WriteLine("0.Close");

        }

	}
}

