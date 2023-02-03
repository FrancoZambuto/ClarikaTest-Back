using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarikaTest.DataAccess.Domain.Models
{
    public class Members
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Tweets> Tweets { get; set; }
    }
}
