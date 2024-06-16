namespace PatiKopru.Models
{
    public class Donation
    {
        public int Donationid { get; set; }
        public int Amount { get; set; }
        public string DonationType {  get; set; }
        public DateTime Date { get; set; }

        // User ile ilişkilendirme
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
