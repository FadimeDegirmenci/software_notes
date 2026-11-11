Func, bir metodu veya lambda ifadesini değişken gibi saklamamızı ve daha sonra çalıştırmamızı sağlayan hazır bir delegate türüdür.


Örneğin bu fonksiyonu func içinde saklayalım.
public int Carp(int sayi1, int sayi2)
{
    return sayi1 * sayi2;
} 


Func<int, int, int> islem = Carp;



Bu işlem fonksiyonu çalıştıracağımız zamanı belirlemek istediğimizde kullanılır.
Func<IKurulumService> servisOlustur =
    () => new KurulumService(); dediğimizde KurulumService henüz oluşmadı. 





    DEVAMINI YAZ.