using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      while (true)
      {
        Console.Clear();
        GetTitle();
        Print();
        GetUserInput();
      }
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      System.Console.WriteLine(@"Ooookkay now Morty....
      There is an alien parasite that disguises itself by implanting false memories in people's minds. 
      We need to kill all the Parasites before we can leave the House or they will spread to the rest of the world and destroy it.");
      System.Console.WriteLine(System.Environment.NewLine);
      Console.WriteLine("What would you like to do?");
      System.Console.WriteLine(System.Environment.NewLine);
      System.Console.WriteLine("Type (L)ook to veiw each Room, (H)elp for Commands, (Q)uit to Exit");

      string input = Console.ReadLine().ToLower() + " "; // input
      string command = input.Substring(0, input.IndexOf(" ")); //action
      string option = input.Substring(input.IndexOf(" ") + 1).Trim(); //item
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      switch (command)
      {
        case "q":
        case "quit":
        case "exit":
        case "close":
          _gameService.Quit();
          break;
        case "v":
        case "veiw":
        case "i":
        case "items":
        case "inventory":
          _gameService.Inventory();
          break;
        case "h":
        case "help":
        case "guide":
          _gameService.Help();
          break;
        case "l":
        case "look":
        case "see":
        case "ls":
          _gameService.Look();
          break;
        case "g":
        case "go":
        case "move":
        case "cd":
          _gameService.Go(option);
          break;
        case "t":
        case "take":
        case "p":
        case "pickup":
          _gameService.TakeItem(option);
          break;
        case "u":
        case "use":
          // case "s":
          // case "shoot":
          _gameService.UseItem(option);
          break;

        default:
          System.Console.WriteLine("Invalid Command!");

          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string message in _gameService.Messages)
      {
        System.Console.WriteLine(message);
      }
      _gameService.Messages.Clear();
      System.Console.WriteLine();

    }

    private void GetTitle()
    {
      System.Console.WriteLine(_gameService.GetTitle());
    }
  }
}