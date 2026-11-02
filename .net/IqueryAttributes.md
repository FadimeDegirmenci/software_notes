.NET MAUI uygulamasında `IQueryAttributable` arabirimi, Shell navigasyonu ile bir sayfadan diğerine veri aktarırken gelen karmaşık nesneleri veya query parametrelerini yakalamak ve işlemek için kullanılır. (Navigation: Bir sayfadan başka bir sayfaya gitmek. Navigation Parameters: Gittiğimiz sayfaya veri göndermek. IQueryAttributable: Gönderilen veriyi karşılamak.)

Sayfalar arası veri aktarımında parametreler key-value (`Dictionary<string, object>`) şeklinde iletilir. Hedef sayfa (veya ViewModel), `IQueryAttributable` arabirimini uyguladığında bu parametreler otomatik olarak `ApplyQueryAttributes` metoduna düşer.


Örneğin veriyi gönderen bir taraf var: 
// UrunlerViewModel.cs
public async Task UrunSecildiAsync(Product secilenUrun)
{
    var parameters = new Dictionary<string, object>
    {
        { "SelectedProduct", secilenUrun },
        { "SourcePage", "AnaSayfa" }
    };

    // UrunDetayPage sayfasına parametrelerle git
    await Shell.Current.GoToAsync("UrunDetayPage", parameters);
}




Bir de veriyi karşılayan taraf var: 
// UrunDetayViewModel.cs
using System.Collections.Generic;
using Microsoft.Maui.Controls;

public class UrunDetayViewModel : IQueryAttributable
{
    public Product Urun { get; set; }
    public string GelinenSayfa { get; set; }

    // IQueryAttributable ile gelen metot
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // 1. Ürün nesnesini yakala
        if (query.TryGetValue("SelectedProduct", out var productObj) && productObj is Product product)
        {
            Urun = product;
        }

        // 2. Ekstra bilgi varsa yakala
        if (query.TryGetValue("SourcePage", out var sourceObj))
        {
            GelinenSayfa = sourceObj.ToString();
        }

        // İpucu: Parametreler geldikten sonra veritabanı veya API çağrısı 
        // yapmak isterseniz tam bu noktada bir yükleme metodu çağırabilirsiniz.
    }
}