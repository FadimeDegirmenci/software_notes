Creational design patternde nesneyi nasıl oluşturacağımıza karar veriyoruz. Stuructural design patternde nesneleri birbirine nasıl bağlayacağımıza karar veriyoruz. Toplam 7 temel pattern var: Adapter, Bridge, Composite, Decorator, Facade, Flyweight, Proxy.

1. Adapter
Uyumlu olmayan iki şeyi uyumlu hale getirme işine denir. Örneğin; eski bir ödeme sistemi şöyle olsun:
public class OldPaymentSystem
{
    public void MakePayment()
    {
        Console.WriteLine("Eski sistemle ödeme yapıldı.");
    }
Ama yeni uygulamamız şu interface'i kullanıyor: 
public interface IPayment
{
    void Pay();
}
Yani Yeni sistem → Pay()

Eski sistem → MakePayment()
Adapter yapıyoruz: public class PaymentAdapter : IPayment
{
    private OldPaymentSystem oldSystem;

    public PaymentAdapter(OldPaymentSystem oldSystem)
    {
        this.oldSystem = oldSystem;
    }

    public void Pay()
    {
        oldSystem.MakePayment();
    }
}
şöyle kullanıyoruz: OldPaymentSystem oldSystem = new OldPaymentSystem();

IPayment payment = new PaymentAdapter(oldSystem);

payment.Pay();
Sınıfı değiştirmeden başka bir sisteme uygun hale getirdi.


2. Bridge
İki ayrı şeyi birbirine bağla ama birbirlerine bağımlı hale getirme.

3. Decorator
Bir nesnenin davranışını sınıfını değiştirmeden değiştirebilmemize yarıyor.
public interface ICoffee
{
    string GetDescription();
}
public class Coffee : ICoffee
{
    public string GetDescription()
    {
        return "Kahve";
    }
}
public class MilkDecorator : ICoffee
{
    private ICoffee coffee;

    public MilkDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public string GetDescription()
    {
        return coffee.GetDescription() + " + Süt";
    }
}
public class CaramelDecorator : ICoffee
{
    private ICoffee coffee;

    public CaramelDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }

    public string GetDescription()
    {
        return coffee.GetDescription() + " + Karamel";
    }
}
ICoffee coffee = new Coffee();

coffee = new MilkDecorator(coffee);

coffee = new CaramelDecorator(coffee);

Console.WriteLine(coffee.GetDescription());-----böylece yeni özellikleri eklemiş olduk.

5. Facade
Karmaşık pek çok işi tek komutla yapmamıza olanak sağlayan yapı. Örn pc başladığı an cpu, ram, hard disk aynı anda başlamasını sağlayan yapı. 

6. Flyweight
Bir türe ait çok fazla ortak özellik varsa ortak özellik tek nesnede tutulur. Böylece ram kullanımı azaltılır. Örn çok sayıda ağaç varsa hepsi aynı türse tür bilgisi bir yerde tutulur, diğer spesifik özellikler ayrı ayrı yazılır.

7. Proxy
Gerçek nesneye doğrudan ulaşmak yerine araya başka bir nesne koymak anlamına gelir. Proxy gerçek projelerde, asıl servisin önüne kontrol/ara katman koymak gerektiğinde kullanılır.En çok şu yerlerde görürsün:

Yetkilendirme: Kullanıcı bir işlemi yapabilir mi kontrol edilir.
Cache: Gerçek servise gitmeden önce veri cache’de var mı bakılır.
Loglama: Metot çağrılmadan önce/sonra log tutulur.
Remote API erişimi: Uzak servise erişen sınıfın önüne bir aracı katman konur.
Lazy loading: Nesne gerçekten gerekene kadar yüklenmez.

Mesela gerçek bir projede ödeme servisin olsun:
public interface IPaymentService
{
    void Pay(decimal amount);
}
public class PaymentService : IPaymentService
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"{amount} TL ödeme yapıldı.");
    }
}
Her ödeme öncesi kullanıcı giriş yapmış mı kontrol etmek istiyoruz. Proxy:
public class PaymentServiceProxy : IPaymentService
{
    private readonly PaymentService paymentService;
    private readonly bool isLoggedIn;

    public PaymentServiceProxy(bool isLoggedIn)
    {
        paymentService = new PaymentService();
        this.isLoggedIn = isLoggedIn;
    }

    public void Pay(decimal amount)
    {
        if (!isLoggedIn)
        {
            Console.WriteLine("Ödeme için giriş yapmalısınız.");
            return;
        }

        paymentService.Pay(amount);
    }
}
Kullanımı şu şekildedir: 
IPaymentService payment =
    new PaymentServiceProxy(true);

payment.Pay(500);
