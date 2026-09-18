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
