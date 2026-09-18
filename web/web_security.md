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
---------------------------
Şunları yaptığından emin ol:
Authentication: Kullanıcının kim olduğunu doğrula.
Authorization: Giriş yapan kullanıcının ne yapmaya yetkili olduğunu kontrol et.
XSS: Kullanıcının siteye zararlı JavaScript sokması durumunu kontrol edecek bir mekanizma yarat.
CSRF: Giriş yapmış kullanıcının oturumunu kullanarak onun adına istek yaptırılmasına engel ol.
SQL Injection: Kullanıcı girdisiyle SQL sorgusunun değiştirilmesine izin verme.
HTTPS/TLS: Tarayıcı ile sunucu arasındaki veriyi şifrele.
Cookie ve Session güvenliği: Oturum bilgilerinin HttpOnly, Secure, SameSite gibi ayarlarla korunmasını sağla.
Password güvenliği: Şifreleri düz metin saklama; hash kullan.
Input Validation: Kullanıcıdan gelen her veriyi server tarafında kontrol et.
File Upload güvenliği: Yüklenen dosyanın türünü, boyutunu ve adını kontrol et.
CORS: Hangi sitelerin tarayıcı üzerinden senin API'ına erişebileceğini belirle.
Security Headers / CSP: Tarayıcıya hangi içeriklerin çalıştırılabileceği gibi güvenlik kuralları ver.
Rate Limiting: Bir kullanıcının kısa sürede binlerce istek göndermesini sınırla.
Secrets yönetimi: API key, DB şifresi gibi bilgileri koda veya GitHub'a koyma.
Logging: Şüpheli girişler ve hatalar gibi olayları kaydet.
Dependency güvenliği: Kullandığın NuGet paketlerini ve .NET sürümünü güncel tut.