using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace FountainOfObjects
{
  public class World
  {
    private string[,] Board { get; } = {  {"Drip"    , "Nothing"  , "Nothing"},
                                          {"Fountain", "Drip"     , "Nothing"},
                                          {"Drip"    , "Nothing"  , "Entrance"}
                                    };
    public int Location { get; set; }

    public World() { }

    public string[,] GetBoard
    {
      get
      {
        return this.Board;
      }
    }

    public void PlayerLocation(Point playerLocation)
    {
      for (int y = 0; y < Board.GetLength(0); y++)
      {
        for (int x = 0; x < Board.GetLength(1); x++)
        {
          // Console.WriteLine($"y = {y} : x = {x}");
          if (y == playerLocation.Y && x == playerLocation.X)
          {
            switch (Board[y, x])
            {
              case "Entrance":
                Console.WriteLine("You are at the Entrance");
                break;
              case "Nothing":
                Console.WriteLine("You hear nothing");
                break;
              case "Drip":
                Console.WriteLine("You hear a dripping noise. The Fountain of Objects is close");
                break;
              case "Fountain":
                Console.WriteLine("You found the Fountain of Objects!");
                break;
              default:
                Console.WriteLine("You do nothing");
                break;
            }
          }
        }
      }
    }














    public void PrintBoardIndex()
    {
      for (int i = 0; i < Board.GetLength(0); i++)
      {
        Console.Write($"Row {i} : ");
        for (int j = 0; j < Board.GetLength(1); j++)
        {
          Console.Write($"{j} ");
        }
        Console.WriteLine();
      }
    }
    public void PrintBoardString()
    {
      for (int i = 0; i < Board.GetLength(0); i++)
      {
        Console.Write($"Row {i} : ");
        for (int j = 0; j < Board.GetLength(1); j++)
        {
          Console.Write($"\n  Column {j} : {Board[i,j]}");
        }
        Console.WriteLine();
      }
    }
  }
}

enum Position {Fountain, Drip, Nothing, Entrance}