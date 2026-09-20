Repository pattern, veritabanıyla konuşma işini ayrı bir class’a vermektir. Veritabanına gidip veri getiren veya veri kaydeden class. 
Eskiden controller direkt veritabanına giderdi: public class ProductController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public ProductController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Product GetProduct(int id)
    {
        return dbContext.Products.Find(id);
    }
}
Daha düzenli projelerde service olurdu: 
public class ProductService
{
    private readonly AppDbContext dbContext;

    public ProductService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Product GetProduct(int id)
    {
        return dbContext.Products.Find(id);
    }
}
Önceki işlemler doğru ve genelde yeterli ama büyük projelerde service ve controllar daha rahat olsun diye veritabanı işlemleri için repository diye bir class ile ayrım yapıyoruz. Örn gerçek bir senaryoda şöyle kullanılır:
İlk adım: 
public interface IProductRepository
{
    Product GetById(int id);
    void Add(Product product);
}
İkinci adım:
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Product GetById(int id)
    {
        return dbContext.Products.Find(id);
    }

    public void Add(Product product)
    {
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
    }
}
Üçüncü adım:
public class ProductService
{
    private readonly IProductRepository repository;

    public ProductService(IProductRepository repository)
    {
        this.repository = repository;
    }

    public Product GetProduct(int id)
    {
        return repository.GetById(id);
    }
}



IProductRepository nasıl ProductRepository oluyor?

Burada Dependency Injection devreye giriyor.
builder.Services.AddScoped<IProductRepository, ProductRepository>();

yazıyoruz.

Bu satır .NET’e şunu söylüyor: Bir yerde IProductRepository istenirse, ProductRepository nesnesi ver. Yani Service şunu istiyor:

public ProductService(IProductRepository repository)

.NET arkada şunu oluşturuyor:

new ProductRepository(...) ve Service’e veriyor.




Özetle Ef corevarken repository diye ayırmaya orta projelerde gerek yok.