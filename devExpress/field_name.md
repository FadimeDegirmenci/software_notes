Bir sütunun satırdaki nesnenin hangi özelliğini göstereceğini belirler. Arka planda bir binding gibi çalışır, ama {Binding} yazılmaz, sadece özellik adı yazılır.
<dxg:TextColumn FieldName="Name" Caption="Ürün Adı" />
Bu, "her satırdaki Product'ın Name özelliğini göster" demek. Caption ise sütun başlığı. ItemTemplate içindeki {Binding Name} ile aynı işi yapıyor.
