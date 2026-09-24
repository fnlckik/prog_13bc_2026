namespace Tablafilc.Model
{
    internal class Teacher : User
    {
        public Teacher(int id, string name, bool isRetired, List<string> subjects) : base(id, name)
        {
            IsRetired = isRetired;
            Subjects = subjects;
        }

        public bool IsRetired { get; }
        public List<string> Subjects { get; }

        public override bool IsHighRated()
        {
            return IsRetired && Subjects.Contains("Fizika");
        }

        public override string ToString()
        {
            return $"T: {base.ToString()}\n{string.Join(";", Subjects)}";
        }
    }
}
