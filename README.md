# UnityFpsShooter

A fast-paced Unity3D survival game where enemies spawn in waves until the player is defeated. Your mission: **survive as long as possible** and **kill as many enemies as you can**.

---

> **Note:** This game is currently in an early development stage. Some features may be incomplete, and bugs are expected. Contributions, feedback, and suggestions are welcome!

## Gameplay Overview

- You control a player equipped with ranged weapons.
- Enemies spawn endlessly and attack using projectiles.
- Health bars for both player and enemies.
- The game ends when the player dies. Restart automatically.
- Enemy AI uses NavMesh for smart pathfinding.
- Objective: Get the **highest kill count** before dying.

---

## Features

- Endless enemy wave spawner (10 enemies max at a time)
- Kill counter with UI
- Player & enemy health systems with dynamic health bars
- Enemy projectile system with muzzle flash
- Object pooling for enemies (performance optimized)
- Main menu, pause menu, and game over screen *(optional addition)*

---

## Key Concepts & Math

- **NavMesh Navigation**: Enemy movement using Unity’s AI pathfinding.
- **Vector3 Math**: Used for rotation, distance checking, and projectile trajectory.
- **Coroutines**: For timing-based spawning and restarts.
- **Health Calculation**: `currentHealth -= damage`, clamped and visualized with sliders.

---

## Main Scripts

| Script              | Description                                   |
|---------------------|-----------------------------------------------|
| `PlayerHealth.cs`   | Manages player health and restart logic       |
| `EnemyAI.cs`        | Handles enemy movement, attack, and rotation  |
| `EnemySpawner.cs`   | Controls timed enemy spawning and pooling     |
| `EnemyProjectile.cs`| Enemy projectile logic                        |
| `EnemyPool.cs`      | Object pooling for enemy reuse                |
| `EnemyHealthBar.cs` | Updates enemy health UI                       |
| `PlayerHealthUI.cs` | Updates player health UI                      |

---

## Requirements

- Unity 2021.3 or newer
- NavMesh system (built-in AI Navigation)
- Input system (legacy or new)
- UI toolkit (for health bars, counters, etc.)

---

## Getting Started

1. Clone this repo:
   ```bash
   git clone https://github.com/yourusername/endless-survival-arena.git

2. Open the project in Unity.

3. Press Play to test in the editor.
