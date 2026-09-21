Saga'nın temel mantığı şudur; birden fazla işlem sırayla yapılır. Bir işlem başarısız olursa önceki başarılı işlemleri telafi eden işlemler çalıştırılır. Örneğin 
Sipariş oluşturuldu ✅
↓
Stok ayrıldı ✅
↓
Ödeme başarısız ❌

işlemi geriye yürütüyoruz: stok geri bırakılır, sipariş iptal edilir.


Transaction ve rollbackten farkı 
transaction.Commit(); işlemleri kaydeder, 
transaction.Rollback(); hata olursa işlemleri iptal eder.

Transaction genelde tek bir veritabanında kullanılır, saga ise birden fazla verştabanı varsa kullanılır. Transactionda hata olursa rollback yapılır-işlem doğrudan geri alınır, sagada telafi yapılır-yapılan işin tersini yapan yeni bir işlem çalıştırılır (ReserveStock();----ReleaseStock(); gibi).