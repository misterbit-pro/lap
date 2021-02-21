namespace PrintDB.Models
{
    public class DbItemModel
    {
        public string Name { get; set; }

        public DbItemModel(string name)
        {
            Name = name;
        }
    }
}
