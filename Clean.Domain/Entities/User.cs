using Clean.Domain.CommonEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.Domain.Entities
{
    public class User:BaseEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
