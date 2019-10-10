using System;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    // public Game(IRoom currentRoom, IPlayer currentPlayer)
    // {
    //   CurrentRoom = currentRoom;
    //   CurrentPlayer = currentPlayer;
    // }
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
      Room start = new Room("Living Room", "Seems to be a Living Room (Starting Room)");
      Room r1 = new Room("Kitchen", "Seems to be the Kitchen");
      Room r2 = new Room("Dining Room", "Seems to be the Dining Room");
      Room end = new Room("Garage", "Seems to be the Garage and the Way out is Locked (Final Room)");

      //Linked Rooms
      //Starts Connects
      start.AddConnection(r1);
      r1.AddConnection(start);
      start.AddConnection(r2);
      r2.AddConnection(start);
      //End Connects
      end.AddConnection(r1);
      r1.AddConnection(end);
      end.AddConnection(r2);
      r2.AddConnection(end);

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