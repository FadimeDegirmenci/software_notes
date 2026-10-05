<ContentPage ...
             xmlns:dx="http://schemas.devexpress.com/maui">
    <dx:DXPopup x:Name="Popup" ...>
        <!--...-->
    </dx:DXPopup>
</ContentPage>


private void Button_Clicked(object sender, EventArgs e) {
    Popup.IsOpen = true;
}