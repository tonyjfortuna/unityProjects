# 🤖 Get Started With Unity

A 3D collectible game built on top of Unity's Get Started tutorial. The player collects items scattered around the environment while dynamic audio responds to movement.

▶️ [Play Get Started With Unity](https://play.unity.com/en/games/bd218536-3f18-4f32-adaa-34920fc09af5/get-started-with-unity)

## 📄 Scripts

- **Pickup.cs**: Gives each collectible a rotating and bobbing idle animation, and plays a particle effect on pickup before destroying the object.
- **UpdateCollectibleCount.cs**: Tracks and displays the number of remaining collectibles in the scene using TextMeshPro, counting active objects by type.
- **MotionAudioController.cs**: Plays movement audio only while the character is actually moving, with a smooth volume fade out when movement stops, driven by a coroutine rather than an abrupt cut.
- **RespawnPlayer.cs**: Detects if the player falls below a set height and respawns them at their starting position and rotation, resetting the CharacterController and camera state cleanly so the player doesn't keep falling after respawn.

## 🛠️ Tech

- Unity, C#
- TextMeshPro
- Cinemachine
