Projeye başlamadan önce aslında 7 temel şey belirlenir. Kabaca:

Konu	Verilecek karar
Gereksinimler	Ne yapıyoruz?
Proje yönetimi	Nasıl ilerleyeceğiz?
Mimari	Kod nasıl bölünecek?
Teknoloji	Ne kullanacağız?
Veri modeli	Veriler nasıl tutulacak?
Test	Doğru çalıştığını nasıl anlayacağız?
Deployment	Kullanıcıya nasıl ulaştıracağız?

Yazılım geliştirme metodolojisi: En bilinen yöntemler:

Waterfall
Agile
Scrum
Kanban
Iterative Development
Incremental Development
Spiral
Prototype / Prototyping

Mimaride karşına şunlar çıkar:

Layered Architecture
Clean Architecture
Hexagonal Architecture
Onion Architecture
MVC
Microservices
Monolith


Proje başlamadan önce teknoloji seçimi yapılır. Backend, frontend, database, cache, deployment...

Veri modeli hazırlanır. Koddan önce çoğu projede entity'ler düşünülür.Örneğin:

User
--------
Id
Name
Email

Product
--------
Id
Name
Price 


Sonra ilişkiler:

User
  |
  | 1
  |
  | N
Order
  |
  | 1
  |
  | N Buna domain/data modeling tarafı diyebiliriz.

Test stratejisi belirlenir. Örneğin:

Unit Test
Integration Test
End-to-End Test


Deployment stratejisi, projeye başlamadan önce düşünülmesi faydalı olan başka konudur.

Örneğin;  GitHub
   ↓
GitHub Actions
   ↓
Docker Image
   ↓
GHCR
   ↓
VPS
   ↓
Docker
   ↓
Nginx
   ↓
Internet

Non-functional requirements: Sistemin ne yaptığı değil, nasıl çalışması gerektiğidir.

Örneğin:

Sayfa 2 saniyeden kısa sürede açılmalı.

Sistem aynı anda 1000 kullanıcı desteklemeli.

Şifreler plaintext tutulmamalı.

API HTTPS kullanmalı.

Sistem günlük backup almalı.




Risk analizi: Profesyonel projelerde şu da düşünülür: Ne ters gidebilir?

Örneğin:
SMTP mail spam'e düşebilir.
Dosya storage maliyeti artabilir.
Database büyüyebilir.

Sonra önlem düşünülür.

Büyük resmi şöyle düşün: Projeye başlarken aslında aşağıdaki sıra oldukça mantıklıdır:

1. Problem
      ↓
2. Gereksinimler
      ↓
3. MVP
      ↓
4. Proje yönetim yöntemi
      ↓
5. Mimari
      ↓
6. Teknoloji seçimi
      ↓
7. Database tasarımı
      ↓
8. Git sistemi
      ↓
9. Test stratejisi
      ↓
10. Deployment
      ↓
11. Kodlama