using static EaTS.WC;

namespace EaTS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Agency Agency { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
