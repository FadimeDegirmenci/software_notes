Uyarı: Binding sadece özelliklere bağlanabilir, metodlara bağlanamaz. Binding'in yaptığı iş bir değeri okumak, yani örneğin "RefreshCommand'ın içinde ne var?" diye bakmak. Bir özelliğin içinde bir değer vardır. Binding metodu okuyamaz.

Butonun Command özelliği de içine bir ICommand nesnesi konmasını bekler. Butona basılınca o nesneye "çalış" der. RefreshCommand tam olarak böyle bir nesne. (command ve method birbirine constructure içinde bağlanıyor) Bu sebeple xaml içinde binding kısmına command adını yazıyoruz. 
CommunityToolkit MVVM Sihri (Source Generator)
ViewModel'de kullanılan attribute'lar (öznitelikler), derleme anında XAML ve Code-Behind'ın erişebileceği public yapılar oluşturur:

[ObservableProperty]: Küçük harfle başlayan private alanlardan (private bool yukleniyor;), XAML'da kullanılan büyük harfli public özellikler (Yukleniyor) üretir.

[RelayCommand]: Metot isimlerinin sonuna "Command" takısı getirerek XAML ve C# tarafından tetiklenebilen ICommand nesneleri üretir.