using System;
using System.Drawing;

namespace FountainOfObjects
{
  public class Player
  {
    private Point Location = new Point(0, 0); // x,y
    private bool Alive { get; set; } = true;
    public Player() { }
    public Point Position
    {
      get { return Location; }
    }
    /// <summary>
    /// Moves player one tile North, South, East or West.
    /// Confirms that movement will not be off board.
    /// </summary>
    /// <param name="movement"></param>
    /// <param name="world"></param>
    public void PlayerMove(string movement, World world)
    {
      Point playerlocation = Location;
      switch (movement)
      {
        case "move north":
          if (world.MaxBoardRows() <= playerlocation.Y++)
          {
            Console.Write("You run into a wall.");
            Console.ReadKey();
            break;
          }
          Location.Y++;
          break;
        case "move south":
          if (0 >= playerlocation.Y--)
          {
            Console.Write("You run into a wall.");
            Console.ReadKey();
            break;
          }
          Location.Y--;
          break;
        case "move east":
          if (world.MaxBoardColumns() <= playerlocation.X++)
          {
            Console.Write("You run into a wall.");
            Console.ReadKey();
            break;
          }
          Location.X++;
          break;
        case "move west":
          if (0 >= playerlocation.X--)
          {
            Console.Write("You run into a wall.");
            Console.ReadKey();
            break;
          }
          Location.X--;
          break;
        case "enable fountain":
          if (world.PlayerFountain(Location))
          {
            world.EnableFountain = true;
          }
          else
          {
            Console.Write("You are not near the fountain.");
            Console.ReadKey();
          }
          break;
        case "help":
          Help();
          break;
      }
    }

    public bool Living
    {
      get
      {
        return Alive;
      }
      set
      {
        Alive = false;
      }
    }
    private static void Help()
    {
      Console.ResetColor();
      Console.Clear();
      string[] commands = new string[] { "north", "south", "east", "west", "help", "enable" };
      foreach (string command in commands)
      {
        if (command != "help" && command != "enable")
        {
          Console.WriteLine($"move {command} - Moves you {command} of your current position");
        }
        else if (command == "help")
        {
          Console.WriteLine("help - Displays the movements");
        }
        else if (command == "enable")
        {
          Console.WriteLine("enable fountain - Enables the fountain");
        }
      }
      Console.ReadKey();
    }
  }
}