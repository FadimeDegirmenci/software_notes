C#'ta TryGetValue, Dictionary (sözlük) ve bazı özel koleksiyonlarda kullanılan, bir anahtara (key) karşılık gelen değeri güvenli ve performanslı bir şekilde almak için tercih edilen bir metottur.

Normalde bir dictionary'den değer okurken köşeli parantez [] kullandığınızda, eğer aradığınız anahtar koleksiyonda yoksa C# bir KeyNotFoundException hatası fırlatır ve programınız çöker. TryGetValue ise bu riski tamamen ortadan kaldırır.


if (urunFiyatlari.TryGetValue("Elma", out int fiyat)) // Tek aramada hem varlık kontrolü hem değer alma
{
    // fiyat değişkeni kullanılabilir
}