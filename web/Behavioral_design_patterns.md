Nesnelerin birbirleriyle nasıl iletişim kurduğu ve sorumlulukların nasıl dağıtıldığı burada düzenlenir.
1. Chain of Responsibility
Chain = sırayla kontrol et.

2. Command

Bir işlemi nesne haline getir.Çünkü bir işlemi nesne haline getirirsek onu saklayabilir, sıraya koyabilir, sonra çalıştırabiliriz ve geri alabiliriz.
Mesela noemalde light.TurnOn(); dedik ve çalıştı. Ama kullanıcı geri almak istediğinde hangi işlemi yaptığını bilmesi gerekiyor. Command nesnesi bunu temsil ediyor. Basitçe yapılışı: bir işlemi class içine koyup nesne haline getiriyoruz.

3. Iterator
Nesneler üzerinde hangi veri yapısına ait olduklarını bilmeden dolaşmamıza izin veren yapı. C# bunun için zaten IEnumerable ve IEnumerator sunuyor.
public class BookCollection : IEnumerable<string>
{
    private List<string> books = new()
    {
        "Suç ve Ceza",
        "1984",
        "Dune"
    };

    public IEnumerator<string> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    System.Collections.IEnumerator
        System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
var books = new BookCollection();

foreach (var book in books)
{
    Console.WriteLine(book);
}

4. Mediator
Nesnelerin birbirlerine doğrudan bağlı olmak yerine merkezi bir aracı üzerinden iletişim kurması.