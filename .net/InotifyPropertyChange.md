INotifyPropertyChanged

.NET'in hazır bir arayüzü (interface). System.ComponentModel adresinde tanımlı çok kısa bir sözleşmedir:

public interface INotifyPropertyChanged
{
    event PropertyChangedEventHandler? PropertyChanged;
}
Sözleşme tek bir şey istiyor: "İçinde PropertyChanged adında bir olay (event) olsun." Bu arayüzü uygulayan her sınıf, MAUI'nin binding sistemi tarafından tanınır ve dinlenir.


---------------------------------------------------------
ObservableCollection

System.Collections.ObjectModel adresinde tanımlı, .NET'in hazır bir liste sınıfı. List<T> gibi kullanılır, ama farkı şu: içine eleman eklendiğinde, çıkarıldığında ya da liste temizlendiğinde haber verir.
Bunu INotifyCollectionChanged adlı başka bir arayüz sayesinde yapar. Bu arayüzün olayı CollectionChanged. INotifyPropertyChanged'deki PropertyChanged'in liste versiyonu gibi düşünebilirsin. DataGrid, CollectionView, Picker gibi liste kontrolleri ItemsSource'a verilen nesne bu olaya sahipse ona abone olur.
--------------------------------
Ekrana bağlı bir ObservableCollection'a eleman eklemek ya da bağlı bir özelliği değiştirmek ana iş parçacığında (UI thread) yapılmalıdır. Arka plandaki bir iş parçacığından yapılırsa uygulama hata verebilir ya da ekran güncellenmeyebilir, özellikle Android'de.

onappearing içinde await--- güvenli
Run.Task--- güvenli değil
DevExpress demosundaki OutlookDataRepository'deki Application.Current.Dispatcher.Dispatch(...) da aynı işi yapıyor. 