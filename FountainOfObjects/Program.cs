using System;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Player player = new Player();
      World world = new World();

      while (true)
      {
        Console.Clear();
        PlayerLocation(player, world);
        if (!!world.GameStatus()) { break; }
        PlayerMovement(player, world);
      }
      Console.WriteLine("You win!");
    }

    private static void PlayerLocation(Player player, World world)
    {
      Point playerCoords = player.Position;
      Console.WriteLine($"You are in the room at (Row: {playerCoords.X}, Column: {playerCoords.Y}).");
      world.PlayerLocation(player);
    }
    private static void PlayerMovement(Player player, World world)
    {
      Console.Write("What do you want to do? ");
      string movement = Console.ReadLine();
      player.PlayerMove(movement, world);
    }
  }
}