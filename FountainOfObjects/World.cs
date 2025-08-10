using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  public class World
  {
    private string[,] Board { get; } ={
      { "Entrance" , "Empty"   , "Empty"   },
      {"Drip"      , "Empty"   , "Empty"   },
      {"Fountain"  , "Drip"    , "Empty"   }
    };

    /* What this looks like on a x and y grid
      2 {"Fountain"  , "Drip"    , "Empty"   }
      1 {"Drip"      , "Empty"   , "Empty"   }
      0 { "Entrance" , "Empty"   , "Empty"   }
              0           1           2
    */
    public int Location { get; set; }
    private bool Fountain_On { get; set; } = false;
    private bool PlayerExit { get; set; } = false;
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
                if (Fountain_On)
                {
                  Console.WriteLine("The Fountain of Objects have been reactivated, and you have scaped with your life!");
                  PlayerExit = true;
                  return;
                }
                Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
                break;
              case "Empty":
                if (Fountain_On)
                {
                  break;
                }
                Console.WriteLine("You hear nothing");
                break;
              case "Drip":
                if (Fountain_On)
                {
                  break;
                }
                Console.WriteLine("You hear a dripping noise. The Fountain of Objects is close");
                break;
              case "Fountain":
                if (Fountain_On)
                {
                  Console.WriteLine("You hear the rishing waters from the Fountain of Objects. It has been reactivated!");
                }
                else
                {
                  Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is near!");
                }
                break;
              default:
                Console.WriteLine("You do nothing");
                break;
            }
          }
        }
      }
    }

    public bool PlayerFountain(Point playerLocation)
    {
      if (Board[playerLocation.Y, playerLocation.X] == "Fountain")
      {
        return true;
      }
      return false;
    }
    public bool EnableFountain
    {
      get
      {
        return Fountain_On;
      }
      set
      {
        Fountain_On = value;
      }
    }

    public bool GameStatus()
    {
      if (!Fountain_On || !PlayerExit)
      {
        return false;
      }
      return true;
    }
    public void PrintBoardString()
    {
      for (int i = 0; i < Board.GetLength(0); i++)
      {
        for (int j = 0; j < Board.GetLength(1); j++)
        {
          Console.WriteLine($"Coords: ({i},{j}) : {Board[i, j]}");
        }
        Console.WriteLine();
      }
    }
  }
}