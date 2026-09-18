1. Creational Patterns
Bunlar nesne oluşturma kalıplarıdır. Bazı durumlarda nesne oluşturma işini başka bir yapıya verirsin. Örnekleri; Factory, Abstract Factory, Builder, Singleton, Prototype
 Factory için detaylı oluşturma süreci şöyle;

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

