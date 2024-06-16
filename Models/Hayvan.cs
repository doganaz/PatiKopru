namespace PatiKopru.Models
{
    public class Hayvan
    {
        public int Hayvanid { get; set; }
        public string Ad { get; set; }
        public string Cins { get; set; }
        public string Tur { get; set; }
        public int Yas { get; set; }
        public string Adres { get; set; }
        public int? SahipId { get; set; }
        public User? Sahip { get; set; }
        public string SahipAdSoyad => Sahip != null ? $"{Sahip.Ad} {Sahip.Soyad}" : ""; // Sahip adı ve soyadını birleştiren bir read-only property eklendi

    }
}
