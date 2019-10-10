using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public Room(string name, string description)
    // , List<Item> items, Dictionary<string, IRoom> exits
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public void AddConnection(IRoom room, string direction)
    {
      Exits.Add(direction, room);
    }

    public IRoom Go(string direction)
    {
      if (Exits.ContainsKey(direction))
      {
        return Exits[direction];
      }
      return this;
    }

    public string GetTemplate()
    {
      string templateExit = $@"
      Directions:
        You see a door to your 
";
      // string RoomTemplate = $"In the {Name} you see \n {Description} \n";

      System.Console.WriteLine(Environment.NewLine);
      foreach (var e in Exits)
      {
        templateExit += "         " + e.Key + Environment.NewLine; // + RoomTemplate;
      }
      return templateExit;
    }



    public string GetCurrentRoom()
    {
      string roomTemplate = @"
      Room Details: 
      ";
      System.Console.WriteLine(Environment.NewLine);
      foreach (var r in Exits)
      {
        roomTemplate = $@"
        In the {Name} you see: 
         {Description}";

      }
      // You see an Item in the Room:
      //  {Items}";
      return roomTemplate;
    }
    public string GetItem()
    {
      string itemTemplate = @"
        *No Items in this Room:
      ";
      System.Console.WriteLine(Environment.NewLine);
      foreach (var i in Items)
      {
        itemTemplate = $@"
        You see an item in the Room:
          *{i.Name}
            -{i.Description}
        ";
      }
      return itemTemplate;
    }

    // public TakeItem(string item)
    // {

    // }
  }
}