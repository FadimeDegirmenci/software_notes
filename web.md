.NET
│
├── Diller
│   ├── C#
│   ├── F#
│   └── Visual Basic
│
├── Temel Platform
│   ├── .NET Runtime
│   ├── CLR
│   ├── Garbage Collector
│   ├── JIT
│   ├── Native AOT
│   └── .NET Libraries / Base Class Library
│
├── Geliştirme Araçları
│   ├── .NET SDK
│   ├── dotnet CLI
│   ├── MSBuild
│   ├── NuGet
│   └── Roslyn / C# Compiler
│
├── Web
│   └── ASP.NET Core
│       ├── Web API
│       ├── MVC
│       ├── Razor Pages
│       ├── Blazor
│       ├── SignalR
│       └── Minimal APIs
│
├── Veritabanı
│   └── Entity Framework Core
│
├── Masaüstü
│   ├── WPF
│   ├── Windows Forms
│   └── .NET MAUI
│
├── Mobil
│   └── .NET MAUI
│
├── Cloud / Servis
│   ├── Worker Services
│   ├── Background Services
│   ├── Microservices
│   └── Container desteği
│
└── Diğer
    ├── Testing altyapıları
    ├── Logging
    ├── Configuration
    ├── Dependency Injection
    ├── Networking
    ├── Cryptography
    ├── JSON/XML işleme
    ├── Threading
    └── async/await altyapısı

1.General Development Skills 
a.json
JSON veri göndermek, almak ve depolamak için kullanılır.JSON.parse() yöntemi, JSON metnini JavaScript değerlerine dönüştürür. Örnek: // JSON text
const text = '{"name":"John", "age":30, "city":"New York"}';

// Parse the JSON text
const person = JSON.parse(text);


JSON.stringify() yöntemi, bir JavaScript değerini JSON metnine dönüştürür:

Örnek
const person = {
  name: "John",
  age: 30,
  city: "New York"
};

const text = JSON.stringify(person);

document.getElementById("demo").innerHTML = text;

JSON Gidiş-Dönüş şöyledir: 
JSON metni
JSON.parse()
JavaScript değeri
JSON.stringify()
JSON metni

JSON dosyaları için dosya tipi ".json"dir.
JSON metni için MIME tipi "application/json"dur.(İnternette gönderilen verinin türü)

b. XML

<?xml version="1.0" encoding="UTF-8"?>
<bookstore>

  <book category="cooking">
    <title lang="en">Everyday Italian</title>
    <author>Giada De Laurentiis</author>
    <year>2005</year>
    <price>30.00</price>
  </book>
</bookstore>


c. CLR - Common Language Runtime

.NET uygulamalarını çalıştıran ortamdır.

Sen C# ile kod yazarsın:

Console.WriteLine("Merhaba");

Bu kod doğrudan işlemci tarafından çalıştırılmaz. Önce derlenir, sonra CLR devreye girer.

Kabaca:

C# kodu
↓
IL kodu
↓
CLR
↓
Makine kodu
↓
Program çalışır

CLR ayrıca şunları da yönetir:

Bellek yönetimi
Garbage Collection
Hata yönetimi
Thread yönetimi

Neden var?
Programın düşük seviyeli çalışma işlerini senin yerine yönetmek için