

## 🇹🇷 CleanTrail Nedir?

CleanTrail, Windows kullanıcılarının gizliliğini korumak ve izlerini silmek için geliştirilmiş açık kaynak kodlu bir temizlik/gizlilik uygulamasıdır.

### Özellikler
- Son açılan dosyalar (Recent Files) temizliği
- Hızlı Erişim (Quick Access) geçmişi temizliği
- Thumbnail cache (küçük resim önbelleği) temizliği
- Chrome, Edge, Firefox ve Opera tarayıcılarının geçmişini silme
- Seçtiğiniz klasörleri izleyip erişim olduğunda otomatik temizlik yapabilme
- Sistem tepsisinde (tray) çalışabilme ve bildirim desteği
- Otomatik başlatma desteği
- Açık/Koyu tema (Light/Dark) ve Türkçe/İngilizce dil desteği
- Temizlik işlemlerini log dosyasına kaydetme

### Nasıl Kullanılır?
1. **EXE dosyasını indirin:**  
   Sağ üstteki [Releases](https://github.com/PartineS/CleanTrail/releases) sekmesine gidin ve son sürümü indirip kullanın.  
   (Henüz EXE dosyası eklenmediyse, bilgisayarınızda .NET 6.0+ yüklü ise aşağıdaki adımları izleyebilirsiniz.)

2. **EXE Dosyası Yoksa Kendiniz Derleyin:**
   ```sh
   git clone https://github.com/PartineS/CleanTrail.git
   cd CleanTrail
   dotnet publish -c Release -r win-x64 --self-contained=true
   ```
   Çıktı klasörü:  
   `bin\Release\net6.0-windows\win-x64\publish\CleanTrail.exe`

### Katkı Sağlamak
Pull request ve issue göndermekten çekinmeyin!

---

## 🇬🇧 What is CleanTrail?

CleanTrail is an open-source privacy and cleaning app for Windows, designed to erase usage traces and protect your privacy.

### Features
- Cleans Recent Files list
- Cleans Quick Access (AutomaticDestinations & CustomDestinations)
- Cleans Windows thumbnail cache
- Deletes browsing history (Chrome, Edge, Firefox, Opera)
- Watches selected folders and auto-cleans on access
- Works in the system tray with notifications
- Supports autostart on Windows login
- Light/Dark theme and Turkish/English language support
- Logs cleaning actions

### How to Use?
1. **Download the EXE:**  
   Go to the [Releases](https://github.com/PartineS/CleanTrail/releases) tab (top right) and download the latest version.  
   (If no EXE is available yet, see the steps below to build your own.)

2. **How to Build Manually:**
   ```sh
   git clone https://github.com/PartineS/CleanTrail.git
   cd CleanTrail
   dotnet publish -c Release -r win-x64 --self-contained=true
   ```
   Output directory:  
   `bin\Release\net6.0-windows\win-x64\publish\CleanTrail.exe`

### Contributing
Feel free to open pull requests and issues!

---

**[Releases (EXE Download)](https://github.com/PartineS/CleanTrail/releases)**  
**Licensed under MIT**
