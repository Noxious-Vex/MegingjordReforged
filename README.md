# Megingjord Reforged: Enhanced Belt Variants

![Version](https://img.shields.io/badge/version-1.0.0-blue)
![Game](https://img.shields.io/badge/game-Valheim-orange)
![Framework](https://img.shields.io/badge/framework-BepInEx-purple)
![Dependency](https://img.shields.io/badge/dependency-J%C3%B6tunn-green)

## Overview

**Megingjord Reforged: Enhanced Belt Variants** expands the legendary Megingjord belt by introducing multiple specialized belt variants designed around different playstyles without replacing the vanilla Megingjord Belt from Haldor..

Each belt represents a different aspect of Viking power, offering unique bonuses while requiring the Megingjord belt in its default crafting recipe maintaining compatibility with server-authoritative serversync configuration and multiplayer gameplay.

The goal of this project is to provide meaningful progression choices without replacing Valheim's existing systems.


## Why Megingjord Reforged?

Rather than replacing Valheim's original Megingjord utility belt, this mod expands it into multiple legendary belt end-game variants that encourage specialized playstyles while preserving the spirit of vanilla progression.

---

# Features

## Legendary Belt Variants

Megingjord Reforged introduces several unique belt variants:

Developer Note:
> Will be evaluating balance comparison between belts, open to feedback. available to reach me on discord: `noxiousvex`.

### Aedigjord

**The Rage Belt**

A combat-focused belt designed for warriors seeking increased strength and endurance.

Features:

* Increased carry capacity
* Increased armor
* Improved health regeneration
* Increased Club skill effectiveness
* Increased Sword skill effectiveness
* Increased adrenaline gain

---

### Seidgjord

**The Seidr Belt**

A mystical belt designed for magic users and Eitr-based builds.

Features:

* Improved Eitr regeneration
* Increased ElementalMagic skill effectiveness
* Increased BloodMagic skill effectiveness

---

### Skadigjord

**The Agility Belt**

A mobility-focused belt designed around speed, stamina efficiency, and exploration.

Features:

* Improved stamina regeneration
* Reduced stamina costs for movement-related actions
* Increased Bow skill effectiveness
* Increased Crossbow skill effectiveness

---

### Alagjord

**The Aquatic Belt**

A water-focused belt designed for sailors and explorers.

Features:

* Improved stamina regeneration
* Reduced stamina costs to swimming
* Swimming bonuses
* Fishing bonuses
* Increased Swimming skill effectiveness

---

### Fornmegingjord

**The Ancient Gatherer Belt**

A legendary version of the original Megingjord focused on Gathering resources.

Features:

* Enhanced carry capacity
* Improved woodcutting efficiency
* Improved mining efficiency

---

# Configuration

Megingjord Reforged uses a server-authoritative ServerSync configuration system.

## ServerSync

When connected to a server:
• Server configuration overrides compatible client settings.
• Client configuration files are never permanently modified.
• Original client settings are restored after disconnecting.
• Version compatibility is verified during connection.

Config Synchronization includes:

* Belt recipe settings
* Crafting station settings
* Crafting station levels
* Belt effect modifiers

Developer Note:
> Version tracking is `Major.Minor.Patch` - Server and Client must be on the same version.

---

## Compatibility

### Dependencies

* [BepInEx](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/)
* [Jötunn](https://thunderstore.io/c/valheim/p/ValheimModding/Jotunn/)

### Confirmed Compatible:

* [AzuExtendedPlayerInventory](https://thunderstore.io/c/valheim/p/Azumatt/AzuExtendedPlayerInventory/) by Azumatt
* [TradersExtended](https://thunderstore.io/c/valheim/p/shudnal/TradersExtended/) by shudnal
* [ExtraSlots](https://thunderstore.io/c/valheim/p/shudnal/ExtraSlots/) by shudnal

### UnCompatible Mods:

* No confirmed incompatiblities yet.
* Caution with mods that modify/remove the vanilla Megingjord belt

---

# Installation

## Manual Installation

1. Install BepInEx for Valheim.
2. Install Jötunn.
3. Place `MegingjordReforged.dll` into:

```
BepInEx/plugins/
```

4. Launch Valheim.

---

# Multiplayer

Megingjord Reforged supports multiplayer environments.

The server controls synchronized gameplay configuration.

Requirements:

* Install the mod on the server.
* Ensure all players have matching mod versions.

---

# Configuration Options

Available configuration categories:

## General

* Enable Mod
* Enable Server Sync

## Belts

* Crafting station configuration
* Crafting level configuration
* Recipe configuration

## Belts - Effects

* Most belt effect values are configurable.
* Certain core effects remain fixed to preserve each belt's intended identity.
> May see an update down the line that makes all effects completely configurable.

---

# Versioning

## Current Release - v1.0.0
Initial public release.

Includes:
* 5 themed variant Belts
* Configurable Crafting Station + Crafting Station Level
* Configurable Recipe
* Visual Status effect while belt is equipped
* Visual Tooltip on Belts
* Multiplayer Version verification management system
* ServerSync framework with server authoritative Runtime configuration overrides


---

# Future Plans

* Additional belt variants
* Progression-based upgrade paths
* Additional configuration options
* Expanded advanced features

---

# Credits

Created by:
**Noxious Vex**

Built using:
• [BepInEx](https://thunderstore.io/c/valheim/p/denikson/BepInExPack_Valheim/)
• [Jötunn](https://thunderstore.io/c/valheim/p/ValheimModding/Jotunn/)
• Harmony

---

# License

Megingjord Reforged uses a custom license designed to allow gameplay use,
server hosting, and modpack inclusion while protecting original work.

See the LICENSE file included with this project for full terms.

---

# Support

For issues, bug reports, and suggestions:
Feature requests are welcome.
Bug reports should include:
• Mod version
• Game version
• BepInEx version
• Player.log (Ideally with Debug Logging enabled from Config)

Discord Username:
> `noxiousvex`

GitHub:
> [MegingjordReforged](https://github.com/Noxious-Vex/MegingjordReforged)

Thunderstore:
> Add release URL
