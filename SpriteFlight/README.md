# ✈️ Sprite Flight

A 2D arcade style flight game built on top of a Unity Learn project. You steer toward the mouse cursor with thrust based movement, dodging obstacles that spawn with randomized size, speed, and spin.

▶️ [Play Sprite Flight](https://play.unity.com/en/games/28d8db36-f336-4172-9c65-0c1b41410e08/sprite-flight)

## 📄 Scripts

- **PlayerController.cs**: Thrust based movement toward the mouse position using Unity's Input System, a booster flame effect while thrusting, a live score tied to survival time, and a persistent high score saved with `PlayerPrefs`. The HUD is built with UI Toolkit, and a flashing background/scale animation plays when a new high score is set.
- **Obstacle.cs**: Spawns obstacles with randomized size, speed, direction, and spin, and instantiates a bounce effect at the exact collision contact point.

## 🛠️ Tech

- Unity, C#
- Unity Input System
- UI Toolkit for the HUD
- Rigidbody2D physics
