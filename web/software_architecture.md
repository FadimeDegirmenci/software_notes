Monolith, bir uygulamanın ana parçalarının tek bir uygulama içinde birlikte çalışması ve birlikte deploy edilmesi demektir.

Örneğin:

E-ticaret uygulaması
├─ Kullanıcı işlemleri
├─ Ürünler
├─ Siparişler
├─ Ödeme
└─ Admin

Bunların hepsi aynı .NET uygulamasının içindeyse buna monolithic application denir.
------------------------------------------------------------
Microservices, büyük bir uygulamayı küçük ve bağımsız servisler halinde geliştirme yaklaşımıdır. Örneğin bir e-ticaret sistemi Product Service, Order Service, Payment Service,
User Service, Notification Service şeklinde ayrılabilir. Product Service sadece şu işlerle ilgilenir: ürün ekleme, ürün silme, ürün listeleme, stok bilgisi.