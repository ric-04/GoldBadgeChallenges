using Komodo_Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Console
{
    public class Program_UI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
         // SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool hasStarted = true;
            while (hasStarted)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do\n" +
                    "1] Add Badge\n" +
                    "2] Edit Badge\n" +
                    "3] List All Badges\n" +
                    "-------------------------------------------------------------\n" +
                    "0] Exit Application");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;

                    case "2":
                        EditBadge();
                        break;

                    case "3":
                        ListAllBadges();
                        break;

                    case "0":
                        hasStarted = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Selection.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ListAllBadges()
        {
            Console.Clear();
        }
        private void AddBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            // Have to have this to add to list of doors
           // List<string> doors = new List<string>();
            
            Console.WriteLine("\nInput badge ID to ADD");
            int inputBadgeID = int.Parse(Console.ReadLine());
            badge.BadgeID = inputBadgeID;

            bool hasEnteredAllDoorNames = false;
            while (hasEnteredAllDoorNames==false)
            {
                Console.WriteLine("Does this badge have any access to any doors? y/n");
                string userinput = Console.ReadLine();
                if (userinput=="y")
                {
                    Console.WriteLine("Input the door name the Badge needs access to.");
                    string inputDoorAccess = Console.ReadLine();
                    badge.Doors.Add(inputDoorAccess); // <- Adding to doors List
                }
                if (userinput=="n")
                {
                    hasEnteredAllDoorNames = true;
                }
            }


            // <- Parameters needed to create new Badge
            _badgeRepo.AddToDatabase(badge); // <- Adding ^ Badge to _badgeRepo
        }

        private void EditBadge()
        {
            //Console.Clear();
            //Console.WriteLine("Input Dictionary Key to EDIT");
            //int inputDictKey = int.Parse(Console.ReadLine());

            //Console.WriteLine("\nWhat would you like to do?\n" +
            //    "1] REMOVE Door\n" +
            //    "2] ADD Door");
            //string inputEditSelection = Console.ReadLine();
            //switch (inputEditSelection)
            //{
            //    case "1":
            //        RemoveDoor();
            //        break;

            //    case "2":
            //        AddDoor();
            //        break;

            //    default:
            //        Console.WriteLine("Invalid Selection");
            //        break;

                   // Badge newBadge = new Badge(inputBadgeID, doors);
                   // _badgeRepo.AddToDatabase()
            }
        }

    //void AddDoor()
    //{
    //    throw new NotImplementedException();
    //}

    //void RemoveDoor()
    //{
    //    throw new NotImplementedException();
    //}
    // }

    private void Seed()
    {
        Badge badge1 = new Badge(1, new List<string> { "!!!A", "A2" });
        Badge badge2 = new Badge(1, new List<string> { "0A7", "A2" });
        Badge badge3 = new Badge(1, new List<string> { "B", "A2" });
        _badgeRepo.
    }
}