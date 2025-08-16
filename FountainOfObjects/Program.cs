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
      string worldSize = WorldChooser();
      World world = new World(worldSize);

      GameIntro(world);
      while (true)
      {
        Console.Clear();
        PlayerLocation(player, world);
        if (world.GameStatus()) { break; }
        if(!player.Living){ break; }
        PlayerMovement(player, world);
      }
      GameOver(player);
    }

    private static void PlayerLocation(Player player, World world)
    {
      Point playerCoords = player.Position;
      Console.Write($"You are in the room at (Row:");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write($" {playerCoords.X}");
      Console.ResetColor();
      Console.Write(", Column: ");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write($"{playerCoords.Y}). Type 'help' for commands.\n");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Magenta;
      world.PlayerLocation(player);
      Console.ResetColor();
    }
    private static void PlayerMovement(Player player, World world)
    {
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.Write("What do you want to do? ");
      Console.ForegroundColor = ConsoleColor.Blue;
      string movement = Console.ReadLine();
      Console.ForegroundColor = ConsoleColor.Magenta;
      player.PlayerMove(movement, world);
      Console.ResetColor();
    }
    private static void GameOver(Player player)
    {
      if (player.Living)
      {
        string winningText = "You win!";
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (winningText.Length / 2)) + "}", winningText));
        Console.ReadKey();
      }
      else
      {
        string winningText = "You Died";
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (winningText.Length / 2)) + "}", winningText));
        Console.ReadKey();
      }
    }
    private static void GameIntro(World world)
    {
      Console.Clear();
      world.Intro();
      Console.ReadKey();
    }
    private static string WorldChooser()
    {
      Console.Clear();
      Console.WriteLine("What size world would you like?");
      Console.WriteLine("Small\nMedium\nLarge");
      string worldSize = Console.ReadLine().ToLower();
      return worldSize;
    }
  }
}