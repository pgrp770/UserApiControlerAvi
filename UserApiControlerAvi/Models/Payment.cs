namespace UserApiControlerAvi.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Amount {  get; set; }
    }
}
