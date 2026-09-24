namespace Tablafilc.Model
{
    internal class Grade
    {
        public Grade(int studentId, int teacherId, string subject, int value, DateTime date)
        {
            if (value < 1 || value > 5) throw new ArgumentOutOfRangeException("A jegy 1 és 5 közötti kell legyen.");
            StudentId = studentId;
            TeacherId = teacherId;
            Subject = subject;
            Value = value;
            Date = date;
        }

        public int StudentId { get; }
        public int TeacherId { get; }
        public string Subject { get; }
        public int Value { get; }
        public DateTime Date { get; }
    }
}
