using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  public class World
  {
    private string[,] Board { get; }
    public int Location { get; set; }
    private bool Fountain_On { get; set; } = false;
    private bool PlayerExit { get; set; } = false;
    public World(string worldSize)
    {

      this.Board = InitalizeBoard(worldSize);
    }

    /// <summary>
    /// Displays player location description based on tile
    /// </summary>
    /// <param name="player"></param>
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
              case "Pit":
                Console.WriteLine("As you step into the next room, your foot falls onto nothing");
                Console.WriteLine("As you start to fall forward, you quickly turn around to grab onto something.");
                Console.WriteLine("However, there is nothing to grab and you tumble to your death.");
                player.Living = false;
                Console.ReadKey();
                break;
              case "Fountain":
                if (Fountain_On)
                {
                  Console.WriteLine("You hear the rishing waters from the Fountain of Objects. It has been reactivated!");
                }
                else
                {
                  Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
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
/// <summary>
/// Initializes board based on users choise. If Small, Medium or Large is not chosen, defaults to large.
/// </summary>
/// <param name="boardSize"></param>
/// <returns></returns>
    private string[,] InitalizeBoard(string boardSize)
    {
      if (boardSize.Equals("small"))
      {
        return new string[,] {
          { "Entrance" , "Empty"   , "Pit"    , "Empty" },
          { "Pit"      , "Empty"   , "Empty"  , "Empty" },
          { "Drip"     , "Empty"   , "Pit"    , "Empty" },
          { "Fountain" , "Drip"    , "Empty"  , "Empty" },
        };
      }
      else if (boardSize.Equals("medium"))
      {
        return new string[,]{
          { "Entrance"  , "Empty"   , "Empty"   ,  "Pit"    },
          { "Empty"     , "Empty"   , "Empty"   ,  "Empty"  },
          { "Empty"     , "Pit"     , "Empty"   ,  "Empty"  },
          { "Empty"     , "Empty"   , "Pit"     ,  "Empty"  },
          { "Drip"      , "Empty"   , "Empty"   ,  "Empty"  },
          { "Fountain"  , "Drip"    , "Empty"   ,  "Pit"    },
        };
      }
      else
      {
        return new string[,]{
          { "Entrance"  , "Empty"   , "Empty"   ,"Empty"  },
          { "Empty"     , "Pit"     , "Empty"   ,"Pit"    },
          { "Empty"     , "Empty"   , "Empty"   ,"Empty"  },
          { "Pit"       , "Empty"   , "Empty"   ,"Empty"  },
          { "Empty"     , "Empty"   , "Pit"     ,"Empty"  },
          { "Empty"     , "Empty"   , "Empty"   ,"Pit"    },
          { "Drip"      , "Pit"     , "Empty"   ,"Empty"  },
          { "Fountain"  , "Drip"    , "Empty"   ,"Pit"    },
        };
      }
      /* What this looks like on a x and y grid
      2 { "Entrance" , "Empty"   , "Empty", "Empty" },
      1 {"Drip"      , "Empty"   , "Empty", "Empty" },
      0 {"Fountain"  , "Drip"    , "Empty", "Empty" },
              0           1           2        3
    */
    }

    /// <summary>
    /// Determins if player is on fountain tile when trying to turn enable fountain
    /// </summary>
    /// <param name="playerLocation"></param>
    /// <returns></returns>
    public bool PlayerFountain(Point playerLocation)
    {
      if (Board[playerLocation.Y, playerLocation.X] == "Fountain")
      {
        return true;
      }
      return false;
    }
    /// <summary>
    /// Ability to turn on fountain and return value of Fountain_On
    /// </summary>
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

    /// <summary>
    /// Ends game when Fountain is enabled and when player is on Exit tile
    /// </summary>
    /// <returns></returns>
    public bool GameStatus()
    {
      if (Fountain_On && PlayerExit)
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Prints row and column of tile.
    /// Good for visualizing board layout.
    /// </summary>
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

    /// <summary>
    /// Returns Max rows in board
    /// </summary>
    /// <returns></returns>
    public int MaxBoardRows()
    {
      return Board.GetLength(0) - 1;
    }
    /// <summary>
    /// Returns Max columns in board
    /// </summary>
    /// <returns></returns>
    public int MaxBoardColumns()
    {
      return Board.GetLength(1) - 1;
    }
/// <summary>
/// Story
/// </summary>
    public void Intro()
    {
      Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.");
      Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
      Console.WriteLine("You must navigate the Caverns with your other senses.");
      Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
    }
  }
}