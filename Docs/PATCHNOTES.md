# 2.0.6 - Splash Window Updates & Valheim 1.0.14 Alignment
* **Splash Window Updates**:
  * Updated telemetry default to unchecked on first launch (Opt-In).
  * Added Send Error Logs toggle (Opt-Out) to capture anonymous crash diagnostics and error reports.
  * Added in-game scrollable Privacy Policy overlay with responsive mouse wheel support.
  * Added interactive tooltip data disclaimers on checkbox hover.
* **Valheim 1.0.14 Alignment**:
  * Aligned publicized game assembly and UnityEngine references to Valheim 1.0.14.
  * Updated internalized  dependency to 3.12.1014.

# 2.0.5 - Jewelcrafting Font Compatibility
* **Compatibility Fix**: Fixed issue where Jewelcrafting packages its own font which was overriding part of a vanilla font, causing the Splash screen to appear blank.
* **Vapok.Common Dependency Bump**: Updated internalized dependency to `Vapok.Valheim.Common` 3.11.1012.

# 2.0.4 - Updated README with Telemetry Information
* **Documentation Update**: Updated the README.md with Anonymous Telemetry and Privacy section per request of mod stores.
* **Vapok.Common Dependency Bump**: Updated internalized dependency to `Vapok.Valheim.Common` 3.9.1012.

# 2.0.3 - Unified Splash Screen & Telemetry Controls
* **Unified Startup Splash Screen & Telemetry**:
  * Updated `Vapok.Valheim.Common` dependency reference to `v3.5.1012`.
  * Registered mod metadata with centralized `ModSplashManager`.
  * Added `ShowSplashOnStartup` and `Enable Anonymous Telemetry` configuration bindings to `ConfigRegistry`.

# 2.0.1 - Dependency & Compatibility Maintenance
* **Runtime & Dependency Updates**:
  * Synchronized package manifest and project references with Jotunn `2.30.0` and BepInEx `5.4.2350`.
  * Verified build pipeline and ILRepack bundling with `Vapok.Valheim.Common` `3.2.1012`.
* **Compatibility & Documentation**:
  * Validated boss key tracking and Mistlands mist suppression against current Valheim 1.0 builds.
  * Standardized mod documentation, changelog tiers, and release staging.

# 2.0.0 - Valheim 1.0 Release & Performance Optimization
* **Valheim 1.0 Compatibility & Core Updates**:
  * Updated assembly references for Valheim 1.0 (`1.0.12`), BepInEx 5.4.2350, and Jotunn 2.30.0.
  * Rebuilt on .NET Framework 4.8.
  * Bundled `Vapok.Valheim.Common` 3.2.1012 and YamlDotNet 17.0.0 via ILRepack.
* **Performance & Scene Traversal Optimizations**:
  * Completely eliminated expensive per-frame scene graph traversal and `GameObject.Find` invocations during environment update cycles.
  * Replaced dynamic GameObject searches with cached references to Mistlands fog renderers and particle emitters.
  * Optimized particle mist material color update calculations to minimize GC allocation spikes.
* **Boss Event & World State Tracking**:
  * Updated `ZoneSystem.CheckKey` and `ZNet.GlobalKeys` inspection routines to query Queen defeat state directly from server world data.
  * Synchronized mist density configuration states seamlessly across dedicated server clients.

# 1.1.2 - Valheim 0.221.12 Maintenance & Epsilon Fix
* Updated to Valheim 0.221.12 and `Vapok.Valheim.Common` 2.11.22112.
* Updated Jotunn to 2.27.1 and YamlDotNet to 16.3.1.
* Fixed Mistlands "off" state comparison to use float epsilon tolerance instead of strict float equality for configuration transparency handling.

# 1.1.1 - Dependency Maintenance
* Updated runtime dependencies.

# 1.1.0 - Modifiable Mist Parameters
* Added configurable mist density settings allowing players/admins to scale Mistlands mist anywhere from 0% (fully removed) to 100% (vanilla).
* Added dedicated server configuration synchronization via ServerSync.

# 1.0.0 - Initial Release of The Queen's Dead Bruh!
* Initial release of automatic Mistlands mist clearing upon defeating The Queen boss on a world.
