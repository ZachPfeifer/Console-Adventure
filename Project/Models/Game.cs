using System;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public Game()
    {
      CurrentPlayer = new Player();
      Setup();
    }

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...

    public void Setup()
    {
      //Rooms
      IRoom start = new Room("Living Room", "Seems to be a Living Room (Starting Room)");
      IRoom r1 = new Room("Kitchen", "Seems to be the Kitchen");
      IRoom r2 = new Room("Dining Room", "Seems to be the Dining Room");
      IRoom end = new Room("Garage", "Seems to be the Garage and the Way out is Locked (Final Room)");

      //Linked Rooms
      //Starts Connects
      start.AddConnection(r1, "north");
      r1.AddConnection(start, "south");
      start.AddConnection(r2, "east");
      r2.AddConnection(start, "west");
      // //End Connects
      end.AddConnection(r1, "west");
      r1.AddConnection(end, "east");
      end.AddConnection(r2, "south");
      r2.AddConnection(end, "north");

      //NPCs
      //   NPC npc1 = new NPC("NAME", "DISC");

      //Create Items
      Item i1 = new Item("Gun", "Use to Shoot things");

      //Add Items to Room
      start.Items.Add(i1);

      //Staring Room
      CurrentRoom = start;
    }



    public string GetTitle()
    {
      string templateTitle = $@"
      
                                                                                                                                                                                             
 _________________       _____   _________________       ____    ____                               _____    ____       _____    ____    ____         ____    ____         ____              
/                 \ ____|\    \ /                 \ ____|\   \  |    |                          ___|\    \  |    |  ___|\    \  |    |  |    |   ____|\   \  |    |       |    |             
\______     ______//     /\    \\______     ______//    /\    \ |    |                         |    |\    \ |    | /    /\    \ |    |  |    |  /    /\    \ |    |       |    |             
   \( /    /  )/  /     /  \    \  \( /    /  )/  |    |  |    ||    |                         |    | |    ||    ||    |  |    ||    | /    // |    |  |    ||    |       |    |             
    ' |   |   '  |     |    |    |  ' |   |   '   |    |__|    ||    |  ____                   |    |/____/ |    ||    |  |____||    |/ _ _//  |    |__|    ||    |  ____ |    |  ____       
      |   |      |     |    |    |    |   |       |    .--.    ||    | |    |                  |    |\    \ |    ||    |   ____ |    |\    \'  |    .--.    ||    | |    ||    | |    |      
     /   //      |\     \  /    /|   /   //       |    |  |    ||    | |    |                  |    | |    ||    ||    |  |    ||    | \    \  |    |  |    ||    | |    ||    | |    |      
    /___//       | \_____\/____/ |  /___//        |____|  |____||____|/____/|                  |____| |____||____||\ ___\/    /||____|  \____\ |____|  |____||____|/____/||____|/____/|      
   |`   |         \ |    ||    | / |`   |         |    |  |    ||    |     ||                  |    | |    ||    || |   /____/ ||    |   |    ||    |  |    ||    |     |||    |     ||      
   |____|          \|____||____|/  |____|         |____|  |____||____|_____|/                  |____| |____||____| \|___|    | /|____|   |____||____|  |____||____|_____|/|____|_____|/      
     \(               \(    )/       \(             \(      )/    \(    )/                       \(     )/    \(     \( |____|/   \(       )/    \(      )/    \(    )/     \(    )/         
      '                '    '         '              '      '      '    '                         '     '      '      '   )/       '       '      '      '      '    '       '    '          
                                                                                                                          '                                                                  
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             
                                                                                                                                                                                             

      
      ";


      return templateTitle;

    }

  }
}