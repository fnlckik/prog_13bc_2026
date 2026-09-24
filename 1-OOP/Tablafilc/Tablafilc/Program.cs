namespace Tablafilc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService service = new();
            service.ReadUsers("../../../Data/users.csv");
            service.ReadGrades("../../../Data/grades.txt");
            //Console.WriteLine(service.GetUserById(5));
            //Console.WriteLine(string.Join("\n", service.SortUsersByName()));
            //Console.WriteLine(string.Join("\n", service.CountUniqueNames()));
            //Console.WriteLine(service.GetLongestName());
            //Console.WriteLine(string.Join("\n", service.GetHighRatedUsers()));
            //Console.WriteLine(string.Join("\n", service.GetRetiredTeachers()));
            //Console.WriteLine(string.Join("\n", service.GetEarlyGradedStudents()));
            Console.WriteLine(string.Join("\n", service.CountGradesByStudents()));
            Console.WriteLine("Program vége.");
        }
    }
}
