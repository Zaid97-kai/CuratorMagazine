namespace CuratorMagazineWebAPI.Models.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkName { get; set; }
        public string Phone { get; set; }
        public virtual List<User>? MotherChildrens { get; set; }

        public virtual List<User>? FatherChildrens { get; set; }
    }
}
