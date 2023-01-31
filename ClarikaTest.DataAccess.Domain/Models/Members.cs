using System.ComponentModel.DataAnnotations;

namespace ClarikaTest.DataAccess.Domain.Models
{
    public class Members
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
