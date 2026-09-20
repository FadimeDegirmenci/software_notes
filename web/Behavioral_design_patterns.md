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
---------detaylı kod örneği eklenecek------

5. Memento

Bir nesnenin mevcut durumunu kaydeder, sonra gerekirse eski haline geri döndürür.
public class Editor
{
    public string Text { get; set; }
}
public class EditorMemento
{
    public string Text { get; }

    public EditorMemento(string text)
    {
        Text = text;
    }
}
public class Editor
{
    public string Text { get; set; }

    public EditorMemento Save()
    {
        return new EditorMemento(Text);
    }

    public void Restore(EditorMemento memento)
    {
        Text = memento.Text;
    }
}
Editor editor = new Editor();

editor.Text = "Merhaba";
EditorMemento backup = editor.Save();
editor.Restore(backup);
Console.WriteLine(editor.Text);

6. Observer
Bir nesnede değişiklik olduğunda, onu takip eden diğer nesnelere otomatik haber veren bir yapı kuruyoruz.

7. State Pattern
Bir nesnenin davranışı, içinde bulunduğu duruma göre değişsin.

8. Strategy Pattern
Aynı işi yapmanın birden fazla yolu varsa, hangi yöntemi kullanacağını dışarıdan seç. Bunu yapmazsak her iş için if else bloğu açmak zorunda kalırız. Bunun yerine ortak bir interface altında her yöntemi ayrı bir class yap.

9. Template Method
Bir işin ana sırasını sabit tut, ama bazı adımlarını alt class’ların değiştirmesine izin ver.