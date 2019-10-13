using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Player : IPlayer
  {
    // public Player(string name, List<Item> inventory)
    // {
    //   Name = name;
    //   Inventory = new List<Item>();
    // }

    public string Name { get; set; }
    public List<Item> Inventory { get; set; } = new List<Item>();

    public string GetInventory()
    {
      string itemTemplate = @"
      *No Items in Inventory*
    ";
      System.Console.WriteLine(Environment.NewLine);
      foreach (var i in Inventory)
      {
        itemTemplate = $@"
      Items in your Inventory:
        *{i.Name}
          -{i.Description}
      ";
      }
      return itemTemplate;
    }

  }
}