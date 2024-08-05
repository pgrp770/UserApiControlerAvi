namespace UserApiControlerAvi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public List<Group>? Groups { get; set; } = [];
        public List<Payment>? Payments { get; set; }
    }
}
