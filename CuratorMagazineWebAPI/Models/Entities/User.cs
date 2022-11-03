namespace CuratorMagazineWebAPI.Models.Entities
{
    /// <summary>
    /// Пользователь системы
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public virtual Role Role { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public int? MotherId { get; set; }
        public Parent? Mother { get; set; }
        public int? FatherId { get; set; }
        public Parent? Father { get; set; }
        public Group? Group { get; set; }

    }
}
