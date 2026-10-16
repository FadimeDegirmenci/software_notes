IQueryAttributable arabiriminin amacı, başka bir sayfadan bu sayfaya yönlendirme yapılırken veya bir seçim sayfasından (örneğin "Grup Seçim Sayfası") geriye dönülürken gönderilen verileri ViewModel içinde otomatik olarak yakalamaktır.
ApplyQueryAttributes metodu sayfa açıldığı anda çalıştığı için verileri yüklemek için ekstra bir yaşam döngüsü (Lifecycle) eventi dinlemenize gerek kalmaz.
// Sayfaya dışarıdan bir veri gönderildiğinde BU METOT otomatik çalışır
public void ApplyQueryAttributes(IDictionary<string, object> gelenPaket)
{
    // "Gelen paketin içinde 'GrupKodu' var mı?" diye bakıyoruz
    if (gelenPaket.ContainsKey("GrupKodu"))
    {
        // Kutudan 'A01' değerini çıkarıp değişkene atıyoruz
        _grupKodu = gelenPaket["GrupKodu"].ToString();
        
        // Artık elimizde 'A01' var, ekrandaki listeyi A01'e göre filtreleyebiliriz!
    }
}

Normalde iki farklı ekran/ViewModel arasında veri taşımak zordur. IQueryAttributable sayesinde: Bir önceki ekranda ne seçildiyse, yeni açılan ekran o seçimi anında öğrensin" demiş oluyoruz. Örneğin aşağıdaki kodda yazılan metodu biz çağırmıyoruz, arkada sistem (MAUI / Shell) bizim yerimize otomatik çağırıyor.
public partial class PageStokListeViewModel : ObservableObject, IQueryAttributable
{
    private string _grupKodu;

    // Bu metot sen çağırmadan, sayfa açıldığı AN otomatik çalışır!
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // "query" nesnesinin içinde {"GrupKodu", "GID"} bilgisi hazır gelir.
        
        if (query.ContainsKey("GrupKodu"))
        {
            _grupKodu = query["GrupKodu"].ToString(); 
            // Artık _grupKodu = "GID" oldu! 
            // Şimdi bu "GID" değerine göre veritabanından stokları çekebilirsin.
        }
    }
}