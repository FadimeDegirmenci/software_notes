OpenTelemetry, çalışan bir uygulamanın içinde neler olduğunu görebilmek için kullanılan standart bir gözlemleme sistemi. Şunları toplar:
Logs → ne oldu?Bir sorun var mı, ne kadar büyük?	Süre 6 sn'ye, hata %15'e çıktı
Metrics → ne kadar oldu?
Traces → istek nerelerden geçti? -İsteğin sistem boyunca nerelerden geçtiğini ve nerede ne kadar süre harcadığını söyler.

Şöyle kullanılır:
dotnet add package OpenTelemetry.Extensions.Hosting
Bu, OpenTelemetry'yi ASP.NET Core uygulamasına bağlamanı sağlar.

dotnet add package OpenTelemetry.Instrumentation.AspNetCore
Bu, uygulamana gelen HTTP isteklerini otomatik takip eder.

dotnet add package OpenTelemetry.Exporter.OpenTelemetryProtocol
Bu da oluşan trace'leri Aspire Dashboard, Jaeger veya OpenTelemetry Collector gibi bir yere göndermemizi sağlar.



telemetry.cs
using System.Diagnostics;

public static class Telemetri
{
    public const string KaynakAdi = "BenimUygulamam";

    public static readonly ActivitySource Kaynak =
        new(KaynakAdi);
}

program.cs
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// OpenTelemetry kurulumu
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource =>
    {
        resource.AddService("BenimUygulamam");
    })
    .WithTracing(tracing =>
    {
        tracing
            // Kendi oluşturduğumuz Activity'leri dinle
            .AddSource(Telemetri.KaynakAdi)

            // Gelen HTTP isteklerini otomatik takip et
            .AddAspNetCoreInstrumentation()

            // Trace'leri Aspire Dashboard / Collector gibi yere gönder
            .AddOtlpExporter();
    });

var app = builder.Build();


// Basit endpoint
app.MapGet("/urun-ekle/{urunAdi}", (string urunAdi) =>
{
    // Yeni bir span başlat
    using var activity =
        Telemetri.Kaynak.StartActivity("urun-ekle");

    // Span'e bilgi ekle
    activity?.SetTag("urun.adi", urunAdi);

    // Gerçek işlem burada yapılır
    Console.WriteLine($"{urunAdi} eklendi.");

    // Sonucu da span'e ekleyebiliriz
    activity?.SetTag("sonuc", "basarili");

    return $"{urunAdi} başarıyla eklendi.";
});

app.Run();