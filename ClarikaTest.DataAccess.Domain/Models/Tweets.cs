using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClarikaTest.DataAccess.Domain.Models
{
    public class Tweets
    {

        public string Email { get; set; }
        public string Message { get; set; }

        [Column("posted_on")]
        [Key]
        public DateTime PostedOn { get; set; }

        public Members Members { get; set; }
    }
}
