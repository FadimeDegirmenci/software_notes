Creational Patterns

Bunlar nesne oluşturma kalıplarıdır. Bazı durumlarda nesne oluşturma işini başka bir yapıya verirsin. Örnekleri; Factory, Abstract Factory, Builder, Singleton, Prototype
 
 
 1. Factory için detaylı oluşturma süreci şöyle;

public interface INotification
{
    void Send();
}

public class EmailNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("Email gönderildi.");
    }
}

public class SmsNotification : INotification
{
    public void Send()
    {
        Console.WriteLine("SMS gönderildi.");
    }
}

public class NotificationFactory
{
    public INotification Create(string type)
    {
        if (type == "email")
            return new EmailNotification();

        if (type == "sms")
            return new SmsNotification();

        throw new Exception("Geçersiz bildirim türü.");
    }
}

var factory = new NotificationFactory();

INotification notification = factory.Create("email");

notification.Send();

Amaç: new ile hangi sınıfın oluşturulacağına ana kod karar vermesin. Bu işi bir Factory sınıfı yapsın.

2. Abstract Factory

Factory’de tek bir tür nesne üretiyorduk. Abstract Factory’de ise birbiriyle ilişkili birden fazla nesneyi aynı aileden üretiriz.

Bir mobilya uygulamamız var. İki farklı takım satıyoruz:

Ofis takımı
Ofis sandalyesi
Ofis masası

Gaming takımı
Gaming sandalyesi
Gaming masası

Buradaki önemli nokta şu: Sandalye ile masa aynı takıma ait olmalı. Yani Ofis sandalyesinin yanına Gaming masası gelmesini istemiyoruz. Ayrıca uygulamada birbirine ait nesnelerin yanlışlıkla karıştırılmasını azaltmak ve tüm aileyi kolayca değiştirebilmek de istiyoruz.
 Adım adım yapalım;
 public interface IChair
{
    void Sit();
}

public interface ITable
{
    void Use();
}
public class OfficeChair : IChair
{
    public void Sit()
    {
        Console.WriteLine("Ofis sandalyesine oturdun.");
    }
}
public class OfficeTable : ITable
{
    public void Use()
    {
        Console.WriteLine("Ofis masasını kullanıyorsun.");
    }
}
public class GamingChair : IChair
{
    public void Sit()
    {
        Console.WriteLine("Gaming sandalyesine oturdun.");
    }
}
public class GamingTable : ITable
{
    public void Use()
    {
        Console.WriteLine("Gaming masasını kullanıyorsun.");
    }
}

Şimdi abstract factory kısmını yapıyoruz:
public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

public class OfficeFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new OfficeChair();
    }

    public ITable CreateTable()
    {
        return new OfficeTable();
    }
}

public class GamingFactory : IFurnitureFactory
{
    public IChair CreateChair()
    {
        return new GamingChair();
    }

    public ITable CreateTable()
    {
        return new GamingTable();
    }
}

Kullanım şu şekildedir:
IFurnitureFactory factory = new OfficeFactory();
IChair chair = factory.CreateChair();
ITable table = factory.CreateTable();