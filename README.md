# The Fountain of Objects

**What is this?**  

"The Fountain of Objects" is a text-based maze game inspired by *The C# Player’s Guide* by Jon Skeet (Starbound Software). You explore a 2D grid of dark cavern rooms, navigate by sensing rather than seeing, find and activate the Fountain of Objects, then return safely to the entrance to win.

---

## Gameplay Overview

- You begin in the cavern’s **entrance room**, where faint light hints your starting point.
- The caverns are **completely dark**
- Move through the maze using commands:  

  `move north`, `move south`, `move east`, `move west`.
- Reach the **Fountain room**, and type `enable fountain` to activate it.
- Then make your way back to the **entrance** with the Fountain activated to win the game.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (e.g., .NET 6 or later)
- A C#-capable IDE or editor (Visual Studio, Visual Studio Code, Rider, etc.)

### Installation

1. **Clone the repository**  

   ```bash
   git clone https://github.com/jeffsnff/The-Fountain-of-Objects.git
   cd The-Fountain-of-Objects
   ```
1. Open the project

   ```
   # Locate and open the .sln file (e.g., FountainOfObjects.sln) in your IDE.
   ```
1. Build the solution

   ```bash
   # In your IDE terminal
   dotnet build
   ```
1. Run the game

   ```bash
   # (Replace with the actual project path if different.)
   dotnet run --project FountainOfObjects
   ```

---

## How to Play

After launching, the game may prompt you to choose difficulty (e.g. small, medium, large)—select one.

You’ll receive descriptions of your current room (e.g., you might feel a breeze or smell a monster nearby).

1. Use the following commands to explore:

   - move north
   - move south
   - move east
   - move west
1. In the Fountain room, use:

   - enable fountain
1. Navigate back to the entrance after activation to win the game.

If you enter a dangerous room (pit, monster), your character will die.

---

## Game Structure

Component Description

World -	A grid of rooms—Entrance, Fountain, and others (possibly with dangers)

Player - Has location

Monsters - Include pits

Goal -	Activate the Fountain and safely return to the entrance

---

## Acknowledgements

This game is based on the "Fountain of Objects" challenge from The C# Player’s Guide by RB Whitaker

[C# Players Guide](https://csharpplayersguide.com/)

---

Enjoy exploring the caverns—and may your senses guide you safely to the Fountain... and back!

Have fun playing my game!