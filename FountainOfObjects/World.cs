using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  public class World
  {                                    // X    0          1          2            Y
    private string[,] Board { get; } = {  {"Entrance" , "Drip" , "Fountain" },//  0
                                          {"Empty"    , "Empty"  , "Drip"   },//  1
                                          {"Empty"    , "Empty" , "Empty"   } //  2
                                    };
    public int Location { get; set; }
    public World() { }

    public void PlayerLocation(Player player)
    {
      Point playerLocation = player.Position;
      for (int y = 0; y < Board.GetLength(0); y++)
      {
        for (int x = 0; x < Board.GetLength(1); x++)
        {
          if (y == playerLocation.Y && x == playerLocation.X)
          {
            switch (Board[y, x])
            {
              case "Entrance":
                Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
                break;
              case "Empty":
                Console.WriteLine("You hear nothing");
                break;
              case "Drip":
                Console.WriteLine("You hear a dripping noise. The Fountain of Objects is close");
                break;
              case "Fountain":
                  Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is near!");
                break;
              default:
                Console.WriteLine("You do nothing");
                break;
            }
          }
        }
      }
    }
    public void PrintBoardString()
    {
      for (int i = 0; i < Board.GetLength(0); i++)
      {
        for (int j = 0; j < Board.GetLength(1); j++)
        {
          Console.WriteLine($"Coords: ({i},{j}) : {Board[i,j]}");
        }
        Console.WriteLine();
      }
    }
  }
}