AddSingleton'ın çalışma mantığı: Uygulama çalıştığı sürece o sınıftan sadece bir tane nesne (instance) oluşturulur. Sayfa veya servis ilk defa çağrıldığında üretilir ve uygulama kapanana kadar bellekte tutularak her yerde aynı nesne yeniden kullanılır.

Ne Zaman Kullanılır?

Tüm uygulamanın ortak erişmesi gereken durum bilgileri (State) tutuluyorsa.

Oluşturulması bellek/işlemci açısından maliyetli olan servisler varsa.

Veritabanı bağlantıları veya API oturum yönetimi gibi yapılar.

Örnekler:

AuthService (Kullanıcının giriş yapıp yapmadığını ve token bilgisini tutan servis).

ThemeService (Uygulama temasını yöneten yapı).

MainPage / AppShell (Uygulamanın ana kabuğu ve ana ekranı).



AddTransient: Çalışma Mantığı: Sınıfa her ihtiyaç duyulduğunda (bir sayfaya geçildiğinde veya bir servise enjekte edildiğinde) baştan sıfır bir nesne üretilir. İşlemi bittiğinde ve referansı kalmadığında bellekten temizlenir (Garbage Collector tarafından toplanır).

Ne Zaman Kullanılır?

Her açıldığında sıfırlanması, temiz bir veriyle başlaması gereken sayfalar.

Hafif, durum tutmayan (stateless) yardımcı servisler.

Kısa ömürlü formlar veya detay sayfaları.

Örnekler:

ProductDetailViewModel (Her ürün detayına tıklandığında yeni bir ürün bilgisi yükleneceği için eski verinin kalmaması gerekir).

PaymentPage (Ödeme ekranı her açıldığında formun temiz olması gerekir).

PdfExportService (Anlık bir dosya oluşturup işi biten servis).




.NET Servis Yaşam Döngüleri (Service Lifetimes)
IoC Container'a bir bağımlılık kaydederken nesnenin ne kadar süre yaşayacağını belirtmeniz gerekir:

Transient (AddTransient): Servis her istendiğinde yeni bir nesne örneği oluşturulur.

Scoped (AddScoped): Her HTTP isteği (request) için tek bir nesne oluşturulur. İstek tamamlanana kadar aynı nesne kullanılır. Veritabanı işlemleri için en yaygın tercihtir.

Singleton (AddSingleton): Uygulama başlatıldığında tek bir nesne oluşturulur ve uygulama kapatılana kadar her yerde aynı nesne kullanılır.



Aşağıdaki örnekte neden servisin kendisini değil de fonksiyonu veriyoruz? Servis durum tutuyor (IsSuccess, Message) diyelim; ViewModel’e servisin kendisini verseydik, sayfa açık kaldığı sürece hep aynı servisi kullanılırdı. Böylece bir önceki işlemden kalan hata mesajı sonraki işleme taşınabilirdi. Fonksiyonla her işlemde temiz bir servis geliyor. Kullanımı ise yine constructora ekleme şeklinde ama ICariService diye eklemiyoruz da Func<ICariService> ekliyoruz.


   builder.Services.AddTransient<Func<ICariService>>(sp => () => sp.GetRequiredService<ICariService>()); 
 