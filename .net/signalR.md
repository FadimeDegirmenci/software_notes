Sunucu tarafında kullanımı;

using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    // İstemcilerden çağrılabilecek metot
    public async Task SendMessage(string user, string message)
    {
        // Bağlı tüm istemcilerin "ReceiveMessage" fonksiyonunu tetikler
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // Kullanıcı bağlandığında çalışan event
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("UserJoined", Context.ConnectionId);
        await base.OnConnectedAsync();
    }
}

İstemci tarafında kullanımı;


// Bağlantının oluşturulması
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect() // Bağlantı koparsa otomatik tekrar bağlanır
    .build();

// Sunucudan gelen bildirimleri dinleme
connection.on("ReceiveMessage", (user, message) => {
    console.log(`${user}: ${message}`);
});

// Bağlantıyı başlatma ve sunucuya mesaj gönderme
async function start() {
    try {
        await connection.start();
        console.log("SignalR Bağlantısı Başarılı!");
        
        // Sunucudaki SendMessage metodunu çağırma
        await connection.invoke("SendMessage", "Ahmet", "Merhaba!");
    } catch (err) {
        console.error("Bağlantı hatası:", err);
    }
}

start();
