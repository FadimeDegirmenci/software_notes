Asp.net'de public class ProductService
{
    private readonly ILogger<ProductService> _logger;

    public ProductService(ILogger<ProductService> logger)
    {
        _logger = logger;
    }

    public void ProductGetir()
    {
        _logger.LogInformation("Ürün getirme işlemi başladı");
    }
} log yapmamızı sağlar. (Ilogger)