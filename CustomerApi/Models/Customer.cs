namespace CustomerApi.Models
{
    public class Customer
    {
        public int Id { get; set; }             // e.g. 1
        public string Name { get; set; } = "";  // e.g. "Jeet Patel"
        public string Email { get; set; } = ""; // e.g. "jeet@example.com"
        public string Phone { get; set; } = ""; // e.g. "jeet@example.com"
    }
}
