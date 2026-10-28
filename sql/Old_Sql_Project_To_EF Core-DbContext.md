Eski projedeki Karmaşık SQL sorgularını veya Stored Procedure'leri değiştirmeden doğrudan DbContext üzerinden çalıştırmak için kullanılan yollardan biri DTO / Model Tanımlama ve Keyless Entity Ayarıdır.
Öncelikle SQL çıktısını karşılayacak bir C# modeli oluşturulur ve DbContext içinde bir anahtarı olup olmadığı (HasNoKey) belirtilir:



public class SiparisRaporDto
{
    public string MusteriAdi { get; set; }
    public decimal ToplamTutar { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<SiparisRaporDto> SiparisRaporlari { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiparisRaporDto>().HasNoKey();
    }
}






DbContext'i Uygulamaya Kaydetme (Program.cs)
DbContext sınıfınızı Dependency Injection konteynerine ekleyerek projenizin istediğiniz yerinde (Controller, Service vb.) constructor üzerinden çağırabilirsiniz.
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SUNUCU_ADI;Database=VERITABANI_ADI;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

// Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));