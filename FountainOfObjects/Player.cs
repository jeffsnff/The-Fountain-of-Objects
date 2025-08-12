using System;
using System.Drawing;

namespace FountainOfObjects
{
  public class Player
  {
    private Point Location = new Point(0, 0); // x,y
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
      }
    }
  }
}