`ObservableCollection<T>`, .NET ortamında (`System.Collections.ObjectModel` namespace'i altında) yer alan, listeye eleman eklendiğinde, eleman silindiğinde veya liste temizlendiğinde** bu değişiklikleri otomatik olarak kullanıcı arayüzüne (UI) bildiren dinamik bir koleksiyon sınıfıdır.

`INotifyPropertyChanged` tekil nesnelerin özellik (property) değişimlerini bildirirken, `ObservableCollection<T>` listenin kendisindeki (yapısal) değişimleri bildirir.



Standart bir `List<T>` nesnesine `.Add()` ile yeni bir eleman eklediğinizde ekrandaki liste (`ListBox`, `DataGrid`, `CollectionView` vb.) güncellenmez. `ObservableCollection<T>` kullandığınızda ise ekstra kod yazmanıza gerek kalmadan arayüz otomatik yenilenir.

Temel Kullanım Örneği

using System.Collections.ObjectModel;

public class PersonelListesiViewModel
{
    // Arayüze bağlanan koleksiyon
    public ObservableCollection<string> Personeller { get; set; }

    public PersonelListesiViewModel()
    {
        Personeller = new ObservableCollection<string>
        {
            "Ahmet",
            "Mehmet"
        };
    }

    public void YeniPersonelEkle(string ad)
    {
        // Eklendiği anda UI'daki liste otomatik güncellenir
        Personeller.Add(ad); 
    }

    public void PersonelSil(string ad)
    {
        // Silindiği anda UI'dan da otomatik kalkar
        Personeller.Remove(ad); 
    }
}
