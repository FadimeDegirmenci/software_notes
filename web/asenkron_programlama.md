public async Task GetProducts()
{
} 
async bu metodun içinde asenkron işlemler kullanabilirim. await gibi.

public async Task GetProducts()
{
}
task: devam eden veya ilerde tamamlanacak bir işi temsil ediyor.

public async Task GetProducts()
{
}
async Task ======= void gibi düşünebiliriz.

public async Task<Product> GetProduct()
{
} değer dönecekse bu şekilde yapılır.

c# da asenkron metodların sonuna genelde async eklenir: GetProductAsync() gibi.

Asenkron ve paralel aynı değildir. Asenkron programlama beklemeyi verimli yönetir.
Paralel programlama birden fazla işi gerçekten aynı anda yürütmeye çalışır.