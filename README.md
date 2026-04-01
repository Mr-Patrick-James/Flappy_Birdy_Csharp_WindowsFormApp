# 🐦 Flappy Birdy

A Flappy Bird clone built with C# and Windows Forms (.NET Framework 4.7.2).

---

## Gameplay

Guide your bird through an endless stream of pipes without crashing. The longer you survive, the faster it gets.

- Press `Space` to flap and gain lift
- Release `Space` to fall with gravity
- Dodge the pipes and don't hit the ground
- Press any key to restart after a game over

## Difficulty Scaling

The game ramps up as your score climbs:

| Score | Pipe Speed |
|-------|------------|
| 0+    | 8          |
| 5+    | 10         |
| 10+   | 12         |
| 20+   | 14         |
| 30+   | 16         |
| 50+   | 18         |

Pipes also spawn more frequently as your score increases.

---

## Getting Started

### Requirements

- Windows
- Visual Studio 2019 or later
- .NET Framework 4.7.2

### Run It

1. Clone or download the repo
2. Open `Flappy Birdy.sln` in Visual Studio
3. Hit `F5` to build and run

---

## Project Structure

```
Flappy Birdy/
├── Form1.cs              # Main game loop, input handling, collision detection
├── Pipe.cs               # Pipe class (top/bottom pair logic)
├── Program.cs            # Entry point
├── Resources/
│   ├── bird.png          # Bird sprite
│   ├── pipe.png          # Bottom pipe image
│   ├── pipedown.png      # Top pipe image
│   └── ground.png        # Ground image
```

---

## Controls

| Key       | Action         |
|-----------|----------------|
| `Space`   | Flap / Jump    |
| Any key   | Restart (on game over) |

---

Made with C# and Windows Forms.
