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
    public void PlayerMove(string movement, World world)
    {
      switch (movement)
      {
        case "move north":
          Location.Y++;
          break;
        case "move south":
          Location.Y--;
          break;
        case "move east":
          Location.X++;
          break;
        case "move west":
          Location.X--;
          break;
        case "enable fountain":
          world.PlayerFountain(Location);
          break;
      }
    }
  }
}