using Academy.Core.Enums;
using Academy.Service.Services.Implementations;
using Academy.Service.Services.Interfaces;

IStudentService studentService = new StudentService();
await Menu();

string request = Console.ReadLine();
while (request != "0")
{
    switch (request)
    {
        case "1":
            //studentService.CreateAsync();
            break;
        case "2":
            break;
        case "3":
            break;
        case "4":
            break;
        case "5":
            break;
        default:
            break;
    }

}
async Task CreateStudent()
{
    string fullName = Console.ReadLine();
    string Group = Console.ReadLine();
    string Average = Console.ReadLine();

    int i = 1;
    foreach (var item in Enum.GetValues(typeof(EducationCategory)))
    {
        Console.WriteLine($"{i}.{item}");
        i++;
    }
    int.TryParse(Console.ReadLine(), out int EnumIndex);

    //bool default=Enum
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


