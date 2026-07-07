# 🟢 Roll a Ball

Built on top of Unity's classic Roll a Ball tutorial, a starting point for 3D physics based player control. Extended past the base tutorial with an enemy that actively hunts the player.

Not published anywhere, local project only.

## 📄 Scripts

- **PlayerController.cs**: Physics based ball movement using Unity's Input System, pickup collection with a win condition once all items are collected, and a loss condition on enemy collision.
- **CameraController.cs**: Follow camera that maintains a fixed offset from the player, updated in `LateUpdate` so it tracks after physics moves the player each frame.
- **Rotator.cs**: Spins collectible pickups for visual polish.
- **EnemyMovement.cs**: Not part of the base tutorial. Uses a NavMeshAgent to actively path toward and chase the player, turning the original tutorial into an actual game with a real threat instead of just collection.

## 🛠️ Tech

- Unity, C#
- Unity Input System
- NavMesh pathfinding
- TextMeshPro
