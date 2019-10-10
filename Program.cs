using System;
using ConsoleAdventure.Project;
using ConsoleAdventure.Project.Controllers;

namespace ConsoleAdventure
{
  public class Program
  {
    public static void Main(string[] args)
    {
      System.Console.WriteLine("Test Test Mic Test");
      new GameController().Run();

    }
  }
}
