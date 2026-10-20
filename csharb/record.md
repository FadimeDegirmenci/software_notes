Bir yapının amacı sadece veri taşımaksa record kullanılır. DTO, Query, Commend genelde record; nesnenin davranışları varsa class kullanılır.

public record CariIslemSecenek(string Baslik, ClickIslem Islem); örneği üzerinden düşünecek olursak;
Tek Satırda Yalın Kod (Boilerplate Kodlardan Kurtulma):
Klasik bir class yazsaydınız; getter'lar, constructor (yapıcı metot), Equals, GetHashCode ve ToString gibi metotları elle yazmanız ya da en az 10-15 satır kod eklemeniz gerekirdi. record ile bunu tek satırda halletmiş olursunuz:

Ekrana basacağınız bir liste veya popup seçeneği oluşturulduktan sonra arka planda yanlışlıkla değiştirilmemelidir. record ile oluşturulan alanlar varsayılan olarak sadece okunabilir (init-only) olur. Yani uygulamanın başka bir yerinde bu seçeneğin başlığı veya işlemi kazayla değiştirilemez.
Değer Temelli Eşitlik (Value Equality):
Normal sınıflarda C#, iki nesneyi karşılaştırırken bellekteki adreslerine bakar. record yapısında ise içindeki veriye bakar:

record nesnesini logladığınızda veya konsola yazdığınızda C# size bellek adresini (YineCo_Ravi_Mobile.Models.CariIslemSecenek) değil, doğrudan içindeki veriyi okunabilir şekilde verir.