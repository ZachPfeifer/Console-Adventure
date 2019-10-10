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

    public void AddConnection(IRoom room)
    {
      Exits.Add(room.Name, room);
    }

    public IRoom MovingRooms(string destinationRoom)
    {
      if (Exits.ContainsKey(destinationRoom))
      {
        return Exits[destinationRoom];
      }
      return this;
    }

    public TakeItem(string item)
    {

    }
  }
}