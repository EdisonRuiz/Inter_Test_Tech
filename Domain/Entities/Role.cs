namespace Domain.Entities
{
    public class Role
    {
        public int IdRole { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Role(string name)
        {
            Name = name.Trim();
        }
    }
}
