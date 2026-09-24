using System.Globalization;
using Tablafilc.Model;

namespace Tablafilc
{
    internal class UserService
    {
        private List<User> users;

        public UserService()
        {
            users = [];
        }

        public void ReadUsers(string path)
        {
            using StreamReader sr = new(path);
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine()!.Split(',');
                User user;
                if (data.Length == 3)
                {
                    user = new Student(id: int.Parse(data[0]),
                                       name: data[1],
                                       className: data[2]);
                }
                else
                {
                    user = new Teacher(id: int.Parse(data[0]),
                                       name: data[1],
                                       isRetired: bool.Parse(data[3]),
                                       subjects: data[2].Split("|").ToList());
                }
                users.Add(user);
            }
        }

        public void ReadGrades(string path)
        {
            using StreamReader sr = new(path);
            sr.ReadLine();
            //string[] lines = sr.ReadToEnd().Split('\n').Skip(1).ToArray();
            while (!sr.EndOfStream)
            {
                string[] data = sr.ReadLine()!.Split(';');
                try
                {
                    Grade g = new(studentId: int.Parse(data[0]),
                                  teacherId: int.Parse(data[1]),
                                  subject: data[2],
                                  value: int.Parse(data[3]),
                                  date: DateTime.Parse(data[4]));
                    Student s = (Student)users.First(u => u.Id == g.StudentId);
                    s.AddGrade(g);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public User GetUserById(int id)
        {
            return users.First(u => u.Id == id);
        }

        public List<string> SortUsersByName()
        {
            return users.Select(u => u.Name).Order().ToList();
        }

        public int CountUniqueNames()
        {
            return users.Select(u => u.Name.Split(' ')[1]).Distinct().Count();
            //return users.DistinctBy(u => u.Name.Split(' ')[1]).Count();
        }

        public string GetLongestName()
        {
            return users.MaxBy(u => u.Name.Length)!.Name;
            //return users.OrderByDescending(u => u.Name.Length).First().Name;
        }

        public List<User> GetHighRatedUsers()
        {
            return users.Where(u => u.IsHighRated()).ToList();
        }

        public List<Teacher> GetRetiredTeachers()
        {
            return users.Where(u => u is Teacher).Select(u => u as Teacher).Where(t => t!.IsRetired).ToList()!;
            //return users.OfType<Teacher>().Where(t => t.IsRetired).ToList();
        }

        public List<Student> GetEarlyGradedStudents()
        {
            return users.OfType<Student>().Where(s => s.Grades.Any(g => g.Date.Month == 9 && g.Date.Day == 2)).ToList();
            //return users.OfType<Student>().Where(s => s.Grades.Any(g => g.Date == new DateTime(2026, 9, 2))).ToList();
        }

        public Dictionary<string, int> CountGradesByStudents()
        {
            //return users.OfType<Student>().ToDictionary(s => s.Name, s => s.Grades.Count);
            Dictionary<string, int> result = new();
            foreach (User user in users)
            {
                if (user is Student)
                {
                    Student s = (Student)user;
                    result.Add(s.Name, s.Grades.Count);
                }
            }
            return result;
        }
    }
}
