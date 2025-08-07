using System;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Player player = new Player();
      World world = new World();

      // world.PrintBoardString();


      Console.Clear();
      Console.WriteLine($"Starting Position: {player.Position}");
      world.PlayerLocation(player.Position); // Entrance
      Console.ReadKey();

      player.PlayerMove(nameof(Move.North));
      Console.WriteLine($"Current Position: {player.Position}");
      world.PlayerLocation(player.Position); // Hear Nothing
      Console.ReadKey();

      player.PlayerMove(nameof(Move.West));
      Console.WriteLine($"Current Position: {player.Position}");
      world.PlayerLocation(player.Position); // Hear Drip
      Console.ReadKey();

      player.PlayerMove(nameof(Move.West));
      Console.WriteLine($"Current Position: {player.Position}");
      world.PlayerLocation(player.Position); // Found Fountain
      Console.ReadKey();
    }
  }
}