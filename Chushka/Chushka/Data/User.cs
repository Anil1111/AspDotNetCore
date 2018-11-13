using System.ComponentModel.DataAnnotations;

namespace Chushka.Data
{
    public enum Role
    {
        User,
        Admin
    }

    public class User
    {
        [Key]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}