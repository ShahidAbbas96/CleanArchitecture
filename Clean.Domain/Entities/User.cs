using Clean.Domain.CommonEntities;

namespace Clean.Domain.Entities
{
    public class User:BaseEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
