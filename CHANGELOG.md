# Changelog

All notable changes to **Megingjord Reforged: Enhanced Belt Variants** will be documented in this file.

This project follows a structured release history using semantic versioning.

---

# [1.1.0] - Hidden Attributes Configurabiliy Update

## Added

### Configurable Skill Level Bonuses

* Added configurable skill level increases for all Legendary Belt variants.
* Skill bonuses can now be adjusted through the configuration file instead of being hard-coded.

Added configurable bonuses for:

| Belt           | Skill           | Default Bonus |
| -------------- | --------------- | ------------- |
| Aedigjord      | Clubs           | +30           |
| Aedigjord      | Swords          | +20           |
| Seidgjord      | Elemental Magic | +30           |
| Seidgjord      | Blood Magic     | +20           |
| Skadigjord     | Bows            | +20           |
| Skadigjord     | Crossbows       | +35           |
| Alagjord       | Swimming        | +35           |
| Alagjord       | Fishing         | +20           |
| Fornmegingjord | Woodcutting     | +20           |
| Fornmegingjord | Pickaxes        | +20           |

### Configurable Adrenaline Gain

* Added configurable Adrenaline gain modifier for Aedigjord.
* Default value preserves the previous behavior.

## Changed

* Updated belt effect configuration handling to support skill-based modifiers.
* Updated status effects to retrieve skill bonuses from configuration values.
* Expanded configuration schema support for new belt effect options.
* Improved future customization support by moving additional belt bonuses away from hard-coded values.

## Fixed

* Resolved missing configuration support for skill bonuses added to belt status effects.
* Ensured new skill modifiers follow the same configuration pattern as existing belt effects.

## Internal

* Updated configuration loading logic for new effect properties.
* Updated synchronization planning to support future server-controlled belt skill values.

---

# [1.0.0] - Initial Release

## Added

### Belt Variants

* Added **Aedigjord** (Rage Belt)
* Added **Seidgjord** (Seidr Belt)
* Added **Skadigjord** (Agility Belt)
* Added **Alagjord** (Aquatic Belt)
* Added **Fornmegingjord** (Ancient Gatherer Belt)

---

### Belt Systems

* Added custom belt definitions.
* Added cloned belt prefabs using the vanilla Megingjord as a base.
* Added custom status effects for every belt variant.
* Added custom tooltips for all belts.
* Added configurable crafting stations.
* Added configurable crafting station levels.
* Added configurable recipes.
* Added custom belt texture colors
* Added custom belt icon colors
* Added custom status effect icons

---

### Configuration

* Added structured configuration management.
* Added belt-specific configuration categories.
* Added configurable belt effect values.
* Added advanced configuration category.
* Added automatic configuration formatting system.
* Added configuration format version tracking.

---

### Multiplayer

* Added server-authoritative ServerSync framework.
* Added runtime configuration overrides.
* Added synchronized crafting configuration.
* Added synchronized recipe configuration.
* Added synchronized belt effect configuration.
* Added ServerSync schema version validation.
* Added multiplayer version compatibility verification.

---

### Internal Systems

* Added Belt Registry.
* Added Status Effect Registry.
* Added ServerSync Registry.
* Added Runtime Configuration Override system.
* Added ServerSync serialization system.
* Added ServerSync package validation.
* Added Version Manager.
* Added Config Formatter.
* Added centralized logging system.

---

### Compatibility

* Added BepInEx support.
* Added Jötunn integration.
* Added Harmony patching framework.

---

## Notes

This is the first public release of **Megingjord Reforged**.

The project introduces multiple specialized Megingjord variants while maintaining compatibility with dedicated servers and multiplayer gameplay through a server-authoritative synchronization system.

