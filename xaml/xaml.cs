View.cs Dosyasına Ne Zaman Kod Yazılır?
Yalnızca görsel nesnelerin davranışları XAML ile tanımlanamıyorsa View.cs kullanılır:

UI Animasyonları: Bir elemana tıklandığında ekranın yana kayması (storyboard tetikleme).

Focus Yönetimi: Ekran açıldığında imlecin belirli bir TextBox içerisine odaklanması (txtInput.Focus()).

Karmaşık Görsel Olaylar: Harita (Map) bileşeni üzerinde mouse ile özel çizim yapma, 3D render nesnelerini kontrol etme.

Medya Kontrolleri: Video oynatıcının Play() veya Pause() metodlarını doğrudan UI nesnesi üzerinden çağırma.