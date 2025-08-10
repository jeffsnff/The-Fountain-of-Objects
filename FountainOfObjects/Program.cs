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
        Point playerCoords = player.Position;
        Console.WriteLine($"You are in the room at (Row: {playerCoords.X}, Column: {playerCoords.Y}).");
        world.PlayerLocation(player);
        if (!!world.GameStatus())
        {
          break;
        }
        Console.Write("What do you want to do? ");
        string movement = Console.ReadLine();
        player.PlayerMove(movement, world);
      }
      Console.WriteLine("You win!");
    }

    public static void PrintBoard(World world)
    {
      Console.Clear();
      world.PrintBoardString();
    }
  }
}