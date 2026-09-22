## .NET MAUI → DevExpress MAUI Kontrol Karşılıkları

| Standart .NET MAUI | DevExpress MAUI | Ne için? |
|---|---|---|
| `Entry` | `TextEdit` | Tek satır metin girişi |
| `Entry IsPassword="True"` | `PasswordEdit` | Şifre girişi |
| `Entry Keyboard="Numeric"` | `NumericEdit` | Sayısal veri girişi |
| `Editor` | `MultilineEdit` | Çok satırlı metin girişi |
| `Picker` | `ComboBoxEdit` | Listeden seçim |
| `DatePicker` | `DateEdit` | Tarih seçimi |
| `TimePicker` | `TimeEdit` | Saat seçimi |
| `CollectionView` | `DXCollectionView` | Listeleme |
| `ListView` | `DXCollectionView` | Eski liste yapılarını modern listeye taşıma |
| `SearchBar` | `TextEdit` / `AutoCompleteEdit` | Arama; öneri gerekiyorsa `AutoCompleteEdit` |
| `CheckBox` | `CheckEdit` | İşaretleme / seçim |
| `Switch` | `DXSwitch` | Aç / Kapat işlemleri |
| `Button` | `DXButton` | Buton |
| `ScrollView` | `DXScrollView` | Kaydırılabilir alan |
| `Frame` / `Border` | `DXBorder` | Kart / kutu görünümü |
| `StackLayout` | `DXStackLayout` | Dikey veya yatay yerleşim |
| `Grid` | MAUI `Grid` kalabilir | DevExpress'e çevirmek zorunlu değildir |
| `Label` | MAUI `Label` kalabilir | DevExpress'e çevirmek zorunlu değildir |
| `ActivityIndicator` | MAUI kontrolü kalabilir / `ShimmerView` kullanılabilir | Yükleniyor durumunu göstermek |