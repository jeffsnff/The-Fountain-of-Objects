using System;
using System.Drawing;

namespace FountainOfObjects
{
  public class Player
  {
    private Point Location = new Point(2,2); // x,y
    private bool HaveFountainObject { get; set; }
    private bool AtExit { get; set; }
    public Player()
    {
      HaveFountainObject = false;
      AtExit = true;
    }

    public Point Position
    {
      get { return Location; }
    }

    public void PlayerMove(string movement)
    {
      switch (movement)
      {
        case nameof(Move.North):
          if (CheckMovement())
          {
            break;
          }
          Location.Y--;
          break;
        case nameof(Move.South):
          Location.Y++;
          break;
        case nameof(Move.East):
          Location.X++;
          break;
        case nameof(Move.West):
          Location.X--;
          break;
      }
    }
    private bool CheckMovement()
    {
      Point playerLocation = this.Location;
      if (playerLocation.Y - 1 < 0)
      {
        return true;
      }
      return false;
    }
  }
}

enum Move { North, South, East, West };