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
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public int? MotherId { get; set; }
        public virtual Parent? Mother { get; set; }
        public int? FatherId { get; set; }
        public virtual Parent? Father { get; set; }
        public int? GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
    }
}
