Bir classın ihtiyaç duyduğu nesneyi kendisi üretmesi yerine dışarıdan almasını ifade eder. Classların birbirine bağımlı hale gelmesinden doğan sorunu çözmek için üretilmiş bir çözümdür.

Eskiden şöyleydi: public class ProductService
{
    private ProductRepository repository = new ProductRepository();

    public void GetProducts()
    {
        repository.GetAll();
    }
} new ProductRepository(); diyerek kendi nesnesini üretiyordu.

Yeni versiyonda new yok public class ProductService
{
    private readonly ProductRepository repository;

    public ProductService(ProductRepository repository)
    {
        this.repository = repository;
    }

    public void GetProducts()
    {
        repository.GetAll();
    }
}
.NET'de builder.Services.AddScoped<ProductRepository>(); istenildiğinde nesne oluştur ve ver demek.

ProductServices içinde
public class ProductService
{
    private readonly ProductRepository repository;

    public ProductService(ProductRepository repository)
    {
        this.repository = repository;
    }
}
public ProductService(ProductRepository repository) ProductService oluşturulurken .NET constructor'a bakar, ihtiyaç duyduğu türleri DI container'da arar, bulursa nesnelerini oluşturur ve constructor'a gönderir.