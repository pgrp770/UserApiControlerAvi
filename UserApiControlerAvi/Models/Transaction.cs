namespace UserApiControlerAvi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<Payment>? Payments { get; set; }

    }
}
