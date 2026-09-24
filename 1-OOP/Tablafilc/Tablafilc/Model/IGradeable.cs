namespace Tablafilc.Model
{
    internal interface IGradeable
    {
        List<Grade> Grades { get; }
        void AddGrade(Grade grade);
    }
}
