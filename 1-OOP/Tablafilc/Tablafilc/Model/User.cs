namespace Tablafilc.Model
{
    internal abstract class User
    {
        protected User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }

        public abstract bool IsHighRated();

        public override string ToString()
        {
            return this.Name;
        }
    }
}
