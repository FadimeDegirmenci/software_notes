Başka bir projede kullanmak için şablon
Yeni bir sayfa için ViewModel yazarken bu iskeleti kopyalayıp isimleri değiştirebilirsin. 

using System.Collections.ObjectModel;
using System.Windows.Input;
 
public class OrnekViewModel : BaseViewModel
{
    // 1) Liste: ObservableCollection
    public ObservableCollection<Kayit> Kayitlar { get; } = new();
 
    // 2) Değişen tek değer: SetProperty
    private string _aramaMetni = string.Empty;
    public string AramaMetni
    {
        get => _aramaMetni;
        set => SetProperty(ref _aramaMetni, value);
    }
 
    // 3) Seçili öğe: SetProperty (TwoWay bağlanır)
    private Kayit? _seciliKayit;
    public Kayit? SeciliKayit
    {
        get => _seciliKayit;
        set => SetProperty(ref _seciliKayit, value);
    }
 
    // 4) Hesaplanan değer: kaynağın set'inde haber ver
    public int KayitSayisi => Kayitlar.Count;
 
    // 5) Komut: { get; } yeterli
    public ICommand YukleCommand { get; }
 
    public OrnekViewModel()
    {
        YukleCommand = new Command(async () => await YukleAsync());
    }
 
    private async Task YukleAsync()
    {
        SetBusy(true);
        try
        {
            var liste = await KayitlariGetirAsync();   // List<Kayit> döner
            Kayitlar.Clear();
            foreach (var k in liste) Kayitlar.Add(k);
            OnPropertyChanged(nameof(KayitSayisi));   // hesaplanan değeri bildir
        }
        finally
        {
            SetBusy(false);
        }
    }
}

