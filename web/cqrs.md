Command Query Separation
Bir işlemin ya veri getirmesine ya da veride değişiklik yapmasına izin verilmesini ifade eder. İkisine aynı anda izin verilmez. Command, veriyi değiştirir. Query, veriyi getirir.
Örneğin bu kod hem veri okuyor hem üzerinde işlem yapıyor: public Product GetProduct(int id)
{
    var product = db.Products.Find(id);

    product.ViewCount++;

    db.SaveChanges();

    return product;
} yani kötü bir kod. 
CQS kod içinde bu işlemlerin ayrılmasını, CQSR mimari yapıda bu işlerin ayrılmasını ifade eder.
Doğru bir örnek; 
public class CreateProductHandler
{
    private readonly AppDbContext dbContext;

    public CreateProductHandler(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Handle(CreateProductCommand command)
    {
        Product product = new Product
        {
            Name = command.Name,
            Price = command.Price
        };

        dbContext.Products.Add(product);

        await dbContext.SaveChangesAsync();
    }
} command tarafı.

Query tarafı: 
public class GetProductHandler
{
    private readonly AppDbContext dbContext;

    public GetProductHandler(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Product> Handle(GetProductQuery query)
    {
        return await dbContext.Products.FindAsync(query.Id);
    }
}





Özetle eskiden aynı service içinde ayrım yapılıyordu: 
public class ProductService
{
    public void AddProduct()
    {
    }

    public Product GetProduct()
    {
    }

    public void DeleteProduct()
    {
    }

    public void UpdateProduct()
    {
    }
}
CQRS'de 
CreateProductCommand
UpdateProductCommand
DeleteProductCommand

GetProductQuery
GetProductsQuery diye ayırıyoruz. Sonra her birinin kendi handlerı oluyor: CreateProductCommand
        ↓
CreateProductHandler


GetProductQuery
        ↓
GetProductHandler

CQRS kodu azaltmıyor daha düzenli parçalara bölüyor.
