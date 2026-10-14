OnAppearing, .NET MAUI ve Xamarin.Forms mimarisinde bir sayfanın ekranda kullanıcıya görünür hale geldiği an otomatik olarak tetiklenen protected ve override bir metottur. Protected çünkü başka yerden çağırılmasını istemiyoruz ve bundan üretilen alt sınıflar olabilmeli. 
OnAppearing İçine: Sayfa kullanıcının karşısına her çıktığında güncellenmesi gereken işlemler.

Örnekler: Bakiye bilgisini günelleme, sepetteki ürün sayısını yenileme, ekran her açıldığında çalışan animasyonlar.
OnDisappearing İçine: Kullanıcı sayfadan ayrıldığı an çalışması gereken temizlik işlemleri.

Örnekler: Arka planda çalışan zamanlayıcıyı (timer) durdurma, dinlenen servis aboneliklerini kapatma.

// EKRANA GELİRKEN (Giriş)
protected override void OnAppearing()
{
    base.OnAppearing();

    // Sayfa ekrana geldiği an çalışır
    VerileriYukle();
}

// EKRANDAN GİDERKEN (Çıkış)
protected override void OnDisappearing()
{
    base.OnDisappearing();

    // Sayfadan ayrılındığı an çalışır
    IslemleriDurdur();
}