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

3. Builder
Builder, bir nesneyi adım adım oluşturmak için kullanılır.

Mesela bir bilgisayar düşün:

İşlemci
RAM
Ekran kartı
SSD

Bunların hepsini tek seferde constructor'a vermek yerine, adım adım kurabiliriz. Çünkü constructorda bir süre sonra hangi parametrenin ne olduğunu anlamak zorlaşır. Şöyle yapıyoruz: Nesnemiz şu olsun: 
 public class Computer
{
    public string Cpu { get; set; }
    public string Ram { get; set; }
    public string Gpu { get; set; }
}
Build: public class ComputerBuilder
{
    private Computer computer = new Computer();

    public ComputerBuilder SetCpu(string cpu)
    {
        computer.Cpu = cpu;
        return this;
    }

    public ComputerBuilder SetRam(string ram)
    {
        computer.Ram = ram;
        return this;
    }

    public ComputerBuilder SetGpu(string gpu)
    {
        computer.Gpu = gpu;
        return this;
    }

    public Computer Build()
    {
        return computer;
    }
}
Kullanımı:

Computer pc = new ComputerBuilder()
    .SetCpu("Ryzen 7")
    .SetRam("32 GB")
    .SetGpu("RTX 5070")
    .Build();

    Builder kısaca karmaşık bir nesneyi tek seferde değil, parça parça oluşturur.

    4. Singleton

Amaç bir sınıftan uygulama boyunca sadece bir tane nesne oluşturulsun. Örn ayarlar oluşturslım ve her yerde o kullanılsın. public class Settings
{
    private static Settings instance;

    private Settings()
    {
    }

    public static Settings GetInstance()
    {
        if (instance == null)
        {
            instance = new Settings();
        }

        return instance;
    }
}
Kullanımı: 
Settings settings1 = Settings.GetInstance();
Settings settings2 = Settings.GetInstance();
private olduğu için new Settings(); e izin vermiyor.

5. Prototype

Amaç sıfırdan yeni nesne oluşturmak yerine, var olan nesneyi kopyalamak.
public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Enemy Clone()
    {
        return new Enemy
        {
            Name = this.Name,
            Health = this.Health,
            Damage = this.Damage
        };
    }
}


Enemy enemy1 = new Enemy
{
    Name = "Goblin",
    Health = 100,
    Damage = 20
};

Enemy enemy2 = enemy1.Clone();