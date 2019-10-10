using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }
    private Game _GameModel { get; set; }
    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
      _GameModel = new Game();

    }
    public void Go(string direction)
    {
      //Change Rooms
      string from = _game.CurrentRoom.Name;
      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      System.Console.WriteLine("hi from go service");

      //NOTE if failed to go anywhere, stop code execution
      if (from == to)
      {
        Messages.Add("Cannot go that Way");
        return;
      }
      Messages.Add($"Moved from {from} to {to}");
    }
    public void Help()
    {
      {
        // string HelpTemplate = 
        Console.Clear();
        Messages.Add(@"

        Welcome to the Help Menu:

Type (N)ext Room to enter the next Room.

Type (B)ack to return to the previous Room.

Type (Q)uit to Exit Game.

Type (R)eset to Restart Game.

Type (L)ook to return back to Current Room.
");
      }
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
      Messages.Add(_game.CurrentRoom.GetCurrentRoom());
    }

    public void Quit()
    {
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }


    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      throw new System.NotImplementedException();
    }

    public string GetTitle()
    {
      return _GameModel.GetTitle();
    }
  }
}