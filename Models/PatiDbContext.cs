using Microsoft.EntityFrameworkCore;

namespace PatiKopru.Models
{
    public class PatiDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Veteriner> Veterinerler { get; set; }
        public PatiDbContext(DbContextOptions<PatiDbContext> options)
        : base(options)
        {
        }
        public PatiDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.;Integrated Security=true;Initial Catalog=PatiKopruDb;user=sa;password=abc123;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("tblUsers");
            modelBuilder.Entity<User>().Property(u=>u.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Adres).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Telefon).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("varchar").HasMaxLength(20).IsRequired();

            
            modelBuilder.Entity<Hayvan>().Property(h=>h.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h=>h.Cins).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.Tur).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.Yas).IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.Adres).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Hayvan>().Property(h => h.SahipId).IsRequired(false);

            modelBuilder.Entity<Hayvan>()
                .HasOne(h => h.Sahip)
                .WithMany()
                .HasForeignKey(h => h.SahipId);


            modelBuilder.Entity<Donation>()
                .HasOne(d => d.User)
                .WithMany(u => u.Donations)
                .HasForeignKey(d => d.UserId);
            modelBuilder.Entity<Donation>().Property(d => d.Amount).IsRequired();
            modelBuilder.Entity<Donation>().Property(d => d.DonationType).HasColumnType("varchar").HasMaxLength(40).IsRequired();


            modelBuilder.Entity<Veteriner>().Property(v => v.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Veteriner>().Property(v => v.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Veteriner>().Property(v => v.Adres).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Veteriner>().Property(v => v.Telefon).IsRequired();
            modelBuilder.Entity<Veteriner>().Property(v => v.Email).HasColumnType("varchar").HasMaxLength(30).IsRequired();

        }
    }
}
