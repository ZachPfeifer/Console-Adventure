using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {
    public Item(string name, string description, IRoom useItem)
    {
      Name = name;
      Description = description;
      UseItem = useItem;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public IRoom UseItem { set; get; }
  }
}