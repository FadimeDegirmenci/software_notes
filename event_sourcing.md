Mevcut durumu saklamak yerine olayları saklamaya verilen isimdir. Böylece geçmişteki herhangi bir durumu da kaybetmemiş oluruz. Hata ne zaman hangi aşamada alındı, kolayca bulabiliriz. Örneğin para yatırıldığında sadece bakiyeyi güncellemeyecek para yatırma olayını kayıt altına alacağız. Para yatırma işlemi için public record MoneyDeposited(decimal Amount); oluşturduk. Burada sadece para yatırma işlemini oluşturduk. public class BankAccount
{
    public decimal Balance { get; private set; }
} burada balanca bakiyemiz.
public class BankAccount
{
    public decimal Balance { get; private set; }

    public void Apply(MoneyDeposited deposit)
    {
        Balance += deposit.Amount;
    }
}
BankAccount account = new BankAccount();

MoneyDeposited deposit = new MoneyDeposited(100);

account.Apply(deposit);
MoneyDeposited deposit1 = new MoneyDeposited(100);

MoneyDeposited deposit2 = new MoneyDeposited(50);

Önceden olsa sadece 150 sonucunu görecektik. 150'ye nasıl ulaştığımızı bilemeyecektik. Şimdi 100 ve 50 yatırma işlemlerinin ardından 150 sonucunu aldığımızı görebiliyoruz. moneydeposit 100 ve moneydeposit 50 diye eventler kaydediliyor.