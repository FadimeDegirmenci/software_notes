MAUI'de "sayfalama" kavramı, iki temel anlam taşır: Ekran/Gezinme Yönetimi (Page Navigation) ve Veri Sayfalama (Data Pagination).

1. Ekran ve Gezinme Yönetimi (Page Navigation)

Mobil uygulamada farklı ekranlar (sayfalar) oluşturma, bu sayfalar arasında geçiş yapma ve bellek üzerindeki sayfa yığınını (Navigation Stack) yönetme sürecidir.

.NET MAUI'de ekran sayfalama üç ana yapı üzerinden yürütülür:

AppShell (Shell Navigation): 

// Belirtilen rotadaki sayfaya gitme
await Shell.Current.GoToAsync("//MainPage/DetailsPage");

// Sayfalar arası parametre taşıma
await Shell.Current.GoToAsync($"{nameof(DetailPage)}?ItemId={selectedId}");


NavigationPage (Stack Tabanlı Gezinme): Sayfaları bir yığın yapısında üst üste koyar. `PushAsync` ile yeni sayfa eklenir, `PopAsync` veya cihazın "Geri" tuşu ile önceki sayfaya dönülür.
Sayfa Türleri (Page Types):
 `ContentPage`: En temel, tek bir görsel içeriği barındıran ekran.
 `FlyoutPage`: Yan menü (Drawer) yapısını yöneten sayfa türü.
 `TabbedPage`: Alt veya üst sekmelerle sayfalar arası geçiş sağlayan yapı.



---
 2. Veri Sayfalama (Data Pagination / Lazy Loading)

Sunucudan veya yerel veritabanından büyük miktardaki veriyi (örneğin 10.000 ürünlük bir liste) tek seferde çekmek yerine, cihaz performansını ve ağ trafiğini korumak amacıyla parça parça (ör. 20'şerli gruplar halinde) yükleme işlemidir.

.NET MAUI'de veri sayfalama genellikle `CollectionView` bileşeni ile yapılır:

`RemainingItemsThreshold`: Kullanıcı listenin sonuna ne kadar yaklaştığında yeni sayfanın yükleneceğini belirler.
`RemainingItemsThresholdReachedCommand`: Eşik değere ulaşıldığında ViewModel üzerindeki komutu tetikler ve API'den sonraki veri sayfasını çeker.

XAML Örneği:


<CollectionView ItemsSource="{Binding Products}"
                RemainingItemsThreshold="5"
                RemainingItemsThresholdReachedCommand="{Binding LoadMoreProductsCommand}">
    <CollectionView.ItemTemplate>
        <DataTemplate x:DataType="models:Product">
            <Label Text="{Binding Name}" />
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>

```

ViewModel Mantığı:

[RelayCommand]
private async Task LoadMoreProductsAsync()
{
    if (IsLoading || !HasMoreItems) return;

    IsLoading = true;
    currentPage++;
    
    var newItems = await _apiService.GetProductsAsync(page: currentPage, pageSize: 20);
    
    foreach (var item in newItems)
    {
        Products.Add(item); // ObservableCollection'a eklenir
    }

    IsLoading = false;
}


Özetle

Ekran Sayfalama 
Kullanıcının uygulamadaki ekranlar arası akışı | `Shell`, `NavigationPage`, `ContentPage`, `GoToAsync` 
-----
Veri Sayfalama | Bellek ve API performansını optimize etmek | `CollectionView`, `RemainingItemsThreshold`, `ObservableCollection` |