1. SQL Injection
SELECT * FROM Users
WHERE Name = @name    parameterized query kullanılır.

2. CSRF — Cross-Site Request Forgery

Burada saldırgan senin giriş yapmış olmanı kullanır. Örneğin bankaya giriş yaptın: banka.com

Tarayıcıda giriş cookie'n duruyor. Başka bir kötü site sana fark ettirmeden:banka.com/para-gonder adresine istek göndermeye çalışabilir.

Tarayıcı cookie'yi otomatik gönderebileceği için banka: "Bu kullanıcı zaten giriş yapmış." diye düşünebilir. Buna CSRF denir.

3. Clickjacking

Saldırgan senin siteni görünmez veya gizlenmiş bir iframe içine koyabilir.

Sen başka bir şeye tıklıyor gibi görünürken aslında:

"Para gönder"

gibi bir butona tıklıyor olabilirsin.

HTTP güvenlik header'ları ile sitenin başka sitelerde iframe içinde açılması engellenebilir.

4. DoS - Denial of Service
Sunucuya aşırı miktarda istek gönderilip sunucunun gerçek kullanıcılara cevap verememesi amaçlanır.

------------------
Kullanıcı verilerini doğrula ve gerektiğinde temizle.
SQL'de parameterized query kullan.
HTTPS kullan.
Güçlü parola politikaları ve mümkünse 2FA kullan.
Yazılımları güncel tut.
Gereksiz hassas veri saklama.
Güvenlik açıklarını tarama araçlarıyla kontrol et.
Güncel OWASP tehditlerini takip et.