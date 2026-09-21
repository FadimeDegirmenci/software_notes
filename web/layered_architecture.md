N-Layered    → türe göre ayırır
Controller / Service / Repository

Vertical Slice → yapılan işe göre ayırır
CreateProduct / DeleteProduct / GetProduct
-------------------------------------------------
Eskiden MediatR kullanılıyordu
Bugün:

Controller/Endpoint
      ↓
    Handler

-----------------------------------------------
Modular Monolith = tek uygulama ama düzenli şekilde modüllere bölünmüş.Örneğin;
E-Ticaret Uygulaması
├── User Module
├── Product Module
├── Order Module
└── Payment Module
Burada modüller ayrı ayrı deploy edilmiyorlar.