<div align="center">

# 👑 The Queen's Dead *Bruh!*

### *Dynamic world progression: clear Mistlands mist upon defeating The Queen in Valheim.*

[![GitHub Release](https://img.shields.io/github/v/release/Vapok/TheQueensDeadBruh?include_prereleases&logo=github&style=for-the-badge)](https://github.com/Vapok/TheQueensDeadBruh/releases)
[![Thunderstore Version](https://img.shields.io/thunderstore/v/Vapok/TheQueensDeadBruh?logo=thunderstore&style=for-the-badge)](https://thunderstore.io/c/valheim/p/Vapok/TheQueensDeadBruh/)
[![Nexus Mods](https://img.shields.io/badge/Nexus_Mods-Available-da8e35?logo=nexusmods&style=for-the-badge)](https://www.nexusmods.com/valheim/mods/3157)
[![Discord](https://img.shields.io/badge/Discord-Join%20Community-7289da?logo=discord&logoColor=white&style=for-the-badge)](https://discord.gg/5YAJkRFBXt)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

---

</div>

You braved the infested mines, climbed the ancient citadel, and drove your blade through the heart of the Seeker Queen. Shouldn't the suffocating mist of the Mistlands finally lift? **The Queen's Dead Bruh!** ties world progression directly to your triumph—clearing away the blinding mist once The Queen has been defeated!

---

## 👑 How It Works

* ⚔️ **Boss Defeat Progression**: Once The Queen boss is slain for the first time on a world or dedicated server, the mod detects the global world key and dissipates the thick Mistlands mist.
* 🌫️ **Configurable Mist Scaling**: Server admins and players can programmatically configure mist density anywhere from 0% (fully clear vistas) to 100% (vanilla mist).
* 🏰 **Rewarding End-Game Exploration**: Turn the jagged peaks, glowing ancient roots, and Dvergr fortresses into breathtaking, unobstructed vistas for base building and exploration.

---

## ⚙️ Configuration & Settings

Configure via the in-game [BepInEx Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager) (<kbd>F1</kbd>) or in `TheQueensDeadBruh.cfg`:

| Setting | Default | Description |
| :--- | :--- | :--- |
| **Enable Mod** | `true` | Globally toggles the mist clearing mechanics. |
| **Mist Density Factor** | `0.0` *(Fully Clear)* | Target mist transparency after The Queen's defeat (`0.0` = completely clear, `1.0` = full vanilla mist). |

---

## 🛡️ Advanced Safeguards

* ⚡ **Zero Performance Impact**: Completely eliminates per-frame scene searches in favor of direct world-state event triggers.
* 🌐 **ServerSync Enforced**: On dedicated servers, the defeat status and mist scaling factors are locked and synchronized from the server to all connected players.

---

## 🤝 Verified Mod Compatibility

<div align="center">

| Mod | Compatibility Status |
| :--- | :--- |
| **AdventureBackpacks** | 🟢 Fully Supported (Wisppack & Demister effects continue functioning normally) |
| **NoFogBruh** | 🟢 Fully Supported |
| **BetterSleepBruh** | 🟢 Fully Supported |
| **CreatureLevelControl / Boss Scaling Mods** | 🟢 Fully Supported |

</div>

---

## 🌐 Available Translations

<div align="center">

🇺🇸 **English** (Default)

</div>

*Want to help translate The Queen's Dead Bruh? Community translations are welcome! Please submit a PR on [GitHub](https://github.com/Vapok/TheQueensDeadBruh) or stop by our [Discord](https://discord.gg/5YAJkRFBXt).*

---

## 📥 Installation & Server Setup

### Mod Manager (Recommended)
1. Install via **R2ModMan** or **Thunderstore Mod Manager**.
2. Dependencies (`BepInExPack`, `Jotunn (JVL)`) are installed automatically.

### Dedicated Servers
* **Client & Server Required**: The mod should be installed on both the server and clients to ensure synchronized world progression across all players.

---

<div align="center">

### 👨‍💻 Created by Vapok Gaming

[![Vapok Gaming](https://avatars.githubusercontent.com/u/1264136?s=120&v=4)](https://github.com/Vapok)

**Author**: [Vapok](https://github.com/Vapok)  
**Source Code**: [GitHub Repository](https://github.com/Vapok/TheQueensDeadBruh)  
**Community & Support**: [Discord Server](https://discord.gg/5YAJkRFBXt)  
**Changelog**: [Release Notes](https://github.com/Vapok/TheQueensDeadBruh/blob/main/CHANGELOG.md)

</div>
