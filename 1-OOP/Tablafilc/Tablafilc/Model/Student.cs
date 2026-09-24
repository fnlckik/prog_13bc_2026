
namespace Tablafilc.Model
{
    internal class Student : User, IGradeable
    {
        private List<Grade> grades;

        public Student(int id, string name, string className) : base(id, name)
        {
            ClassName = className;
            grades = [];
        }

        public string ClassName { get; }

        public List<Grade> Grades { get => new(grades); }

        public void AddGrade(Grade grade)
        {
            grades.Add(grade);
        }

        public override bool IsHighRated()
        {
            return grades.Average(g => g.Value) > 4.5;
        }

        public override string ToString()
        {
            return $"S: {base.ToString()}\n{string.Join(" ", grades.Select(g => g.Value))}";
        }
    }
}
