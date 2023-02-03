namespace ClarikaTest.Models
{
    public class Members
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public List<Tweets> Tweets { get; set; }
    }
}
