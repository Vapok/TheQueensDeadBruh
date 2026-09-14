# The Queen's Dead Bruh! Patchnotes

## 2.0.0 - Valheim 1.0 Release
* Updated for Valheim 1.0 (1.0.12).
* Updated Vapok.Valheim.Common to 3.2.1012.
* Updated Jotunn to 2.30.0.
* Updated YamlDotNet to 17.0.0.
* Performance & Optimization: Eliminated per-frame scene traversal and `GameObject.Find` calls during environment updates.
* Performance & Optimization: Optimized particle mist renderer material color updates.
* Code cleanup and removal of unused frame callbacks.

<details>
<summary><b>Changelog History</b> (<i>click to expand</i>)</summary>

## 1.1.2 - Valheim & Dependency Maintenance
* Updated to Valheim 0.221.12 references.
* Updated Vapok.Valheim.Common to 2.11.22112.
* Updated Jotunn to 2.27.1.
* Updated YamlDotNet to 16.3.1.
* Fixed: Mistlands “off” check now uses an epsilon comparison instead of exact float equality for config-driven transparency.

## 1.1.1 - Updated Dependencies
* Updating with latest dependencies.

## 1.1.0 - Modifiable Mist Parameters
* With a nod to OrianaVenture's MutedMist Mod, you can now programmatically set Mistland's Mist from completely off, completely on, or somewhere in between.
  * Settings are syncable for dedicated servers.

## 1.0.0 - The Queen's Dead Bruh! Initial Release
* Small mod that when used, will disable the Mistland's Mist that covers the lands once the Queen is killed for the first time on a world.
  * Dude.. The Queen's Dead Bruh!
* This mod allows for dedicated server configurations to sync whether it is enabled or disabled to clients.

</details>
