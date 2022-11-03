namespace CuratorMagazineWebAPI.Models.Entities
{
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
