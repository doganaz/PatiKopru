namespace PatiKopru.Models
{
    public class User
    {
        public int Userid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Donation> Donations { get; set; }

    }
}
