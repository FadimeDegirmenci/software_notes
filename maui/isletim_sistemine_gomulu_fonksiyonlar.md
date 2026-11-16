İşletim Sisteminin Kendi Ekranlarını Açan Yerleşik Araçlar

MediaPicker (Kamera ve Galeri): Cihazın kendi kamera uygulamasını veya fotoğraf galerisini açar (MediaPicker.Default.CapturePhotoAsync()).

FilePicker (Dosya Yöneticisi): Android'in "Dosyalar" veya iOS'un "Files" uygulamasını açarak kullanıcının cihazdan belge/dosya seçmesini sağlar (FilePicker.Default.PickAsync()).

Share (Paylaşım Menüsü): Telefonun altından açılan standart paylaşım menüsünü (WhatsApp, E-posta, Bluetooth vb. ile paylaş) tetikler (Share.Default.RequestAsync(...)).

Launcher (Harici Uygulama / Tarayıcı Açıcı): Bir web sitesini cihazın varsayılan tarayıcısında açar veya harita uygulamasını başlatır (Launcher.Default.OpenAsync("https://...")).

DatePicker ve TimePicker (Tarih ve Saat Seçiciler): XAML arayüzüne eklendiğinde tıklandıkları an Android'in takvim/saat tekerleğini, iOS'un ise kendi tarih/saat seçici menüsünü açarlar.

DisplayActionSheet (Seçenek Listesi / Alt Menü): Kullanıcıya birden fazla seçenek sunup birini seçmesini istemek için kullanılır. iOS'ta ekranın altından kayan bir menü (ActionSheet), Android'de ise ortada açılan bir seçim listesi olarak görünür.

DisplayAlert (Uyarı ve Onay Penceresi): Kullanıcıya sadece bilgi vermek ("Tamam" butonuyla) veya Evet/Hayır şeklinde basit bir onay almak için kullanılır.

DisplayPromptAsync (Hazır ve Hızlı): İşletim sisteminin standart penceresini açar. Sadece tek bir metin kutusu alabilir, tasarımı (renk, yazı tipi, butonlar) değiştirilemez ve ekstra kurulum gerektirmez. Basit, tek soruluk girişler (örneğin "Adınız?") için idealdir