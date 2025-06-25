## What is CleanTrail?

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
---
