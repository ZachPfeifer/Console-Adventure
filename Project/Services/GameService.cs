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

Type (Go) then (Direction) to enter another Room. 

Type (L)ook to see content in the Room.

Type (P)ickup to put items in your Inventory.

Type (I)nventory to veiw your picked up Items.

Type (Q)uit to Exit Game.

Type (R)eset to Restart Game.

Type (B)ack to return to the previous Room.
");
      }
    }

    public void Inventory()
    {
      Messages.Add(_game.CurrentPlayer.GetInventory());
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
      Messages.Add(_game.CurrentRoom.GetCurrentRoom());
      Messages.Add(_game.CurrentRoom.GetItem());

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
      // System.Diagnostics.Process.Start(Environment.);
      // System.Windows.Forms.Application.Restart();
      // Environment.Exit(0);
      // var info = new System.Diagnostics.ProcessStartInfo(Environment.GetCommandLineArgs()[0]);// System.Diagnostics.Process.Start(info);
      _game.CurrentPlayer.Inventory.Clear();
      _game.Setup();
      Messages.Add("New Game+");
    }

    // //Setting up a Player(Name)
    public void Setup(string playerName)
    {
      _game.CurrentPlayer.Name = playerName;
    }

    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName) //TODO making item
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("*No items to Pickup*");
        return;
      }
      // else (_game.CurrentRoom.Items.Name.ToLower() == itemName) 
      //   {
      //     Messages.Add($"Picking up {_game.CurrentRoom.Items}");
      //     _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      //     Messages.Add($"Successfully Picked up {_game.CurrentRoom.Items}");
      //     _game.CurrentRoom.Items.Clear();
      //     return;
      //   }
      else
      {
        for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
        {
          var prop = _game.CurrentRoom.Items[i];
          if (prop.Name.ToLower() == itemName)
          {
            Messages.Add($"Picking up {prop.Name}");
            _game.CurrentPlayer.Inventory.Add(prop);
            Messages.Add($"Successfully Picked up {prop.Name}");
            _game.CurrentRoom.Items.Clear();
            return;
          }
        }
      }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      IRoom room = _game.CurrentRoom;

      // if (room.Name == "Garage")// && _game.CurrentPlayer.Inventory == "passcode") //FIXME trash this??  do i need?
      // {



      for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      {
        var playeritem = _game.CurrentPlayer.Inventory[i];
        // var room = _game.CurrentRoom.Name;
        if (playeritem.Name.ToLower() == itemName && itemName == "passcode" && room.Name != "Garage")
        {
          // _game.CurrentRoom != room.Name;
          if (_game.CurrentRoom != playeritem.UseItem)
            Messages.Add("Cannot use Passcode here.Try again in another Room.");
          return;
        }
        else if (playeritem.Name.ToLower() == itemName && itemName == "passcode" && room.Name == "Garage")
        {
          _game.CurrentRoom.Name = "Garage";
          _game.CurrentRoom = playeritem.UseItem;
          _game.CurrentPlayer.Inventory.Remove(playeritem);
          System.Console.Clear();
          Messages.Add($@" Used Passcode to unlock {room.Name} to the outside world! 
          You WIN
           Type (R)estart or (Q)uit");
          return;
        }
      }
      {
        Messages.Add("Unkown Command");
      }
      // }
      // }
      // else if (room.Name == "Living Room") //FIXME Trash this??
      // {
      //   for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      //   {
      //     var playeritem = _game.CurrentPlayer.Inventory[i];
      //     if (playeritem.Name.ToLower() == itemName && itemName == "gun")// && room == "Garage")
      //     {
      //       _game.CurrentRoom.Name = "Living Room";
      //       _game.CurrentRoom = playeritem.UseItem;
      //       // _game.CurrentPlayer.Inventory.Remove(playeritem);
      //       Messages.Add($@"You used {playeritem.Name} in {_game.CurrentRoom.Name}");
      //       return;
      //     }
      //     else
      //     {

      //       Messages.Add("Unkown Command");
      //       return;
      //     }
      //   }

      // }
    }
    // private void UnloadCargo()
    // {
    //   int deliveries = 0;
    //   int profits = 0;
    //   _game.Plane.Cargo.RemoveAll(cargo =>
    //   {
    //     if (cargo.Destination == _game.CurrentAirport)
    //     {
    //       _game.Plane.AccountBalance += cargo.Reward;
    //       deliveries++;
    //       profits += cargo.Reward;
    //       return true;
    //     }
    //     return false;
    //   });
    //   if (deliveries == 0)
    //   {
    //     Messages.Add("No Packages to Deliver");
    //     return;
    //   }
    //   Messages.Add($"{deliveries} package(s) delivered, for a profit of {profits}");
    // }


    public string GetTitle()
    {
      return _GameModel.GetTitle();
    }
  }
}