[relayCommand] MAUI'de bir methodun command gibi davranmasını sağlayan sınıftır. (Relaycommand fonksiyonun nesne gibi davranmasını sağlıyor diyebiliriz.) Örn; 

[RelayCommand]
private void Kaydet()
{
    Console.WriteLine("Kaydedildi");
}


Xaml'da command methodu normal bir method değil, Icommand (komutların uyması gereken kuralları içeriyor) sınıfından türetilmiş bir komut nesnesi bekliyor.