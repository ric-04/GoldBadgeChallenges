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
            Seed();
            Menu();
        }

        private void Menu()
        {
            bool hasStarted = true;
            while (hasStarted)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
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
            //Need container of dictionary<int,Badge> badges
            //Will store inside it (=) _badgeRepo.GetAllBadges
            Dictionary<int, Badge> badges = _badgeRepo.GetAllBadges();

            //This is a collection, so we have to use a loop.
            foreach (var badge in badges)
            {
                Console.WriteLine(badge.Key);
                DisplayBadgeInfo(badge.Value);
            }
        }

        private void DisplayBadgeInfo(Badge badge)
        {
            if (badge.Doors != null)
            {
                Console.WriteLine($"Badge ID: {badge.BadgeID}");
                foreach (var door in badge.Doors)
                {
                    Console.WriteLine(door);
                }
            }
            else
            {
                Console.WriteLine("No badges found");
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            // Have to have this to add to list of doors

            Console.WriteLine("\nInput BADGE ID to ADD");
            int inputBadgeID = int.Parse(Console.ReadLine());
            badge.BadgeID = inputBadgeID;

            bool hasEnteredAllDoorNames = false;
            while (hasEnteredAllDoorNames == false)
            {
                Console.WriteLine("\nDo you need assign badge access to doors?: Y/N");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    Console.WriteLine("\nInput DOOR NAME to ASSIGN ACCESS.");
                    string inputDoorAccess = Console.ReadLine();
                    badge.Doors.Add(inputDoorAccess); // <- Adding to doors List
                }
                if (userInput == "n")
                {
                    hasEnteredAllDoorNames = true;
                }
            }

            // <- Parameters needed to create new Badge
            _badgeRepo.AddToDatabase(badge); // <- Adding ^ Badge to _badgeRepo
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("\nWhat would you like to do?\n" +
                "1] REMOVE Door\n" +
                "2] ADD Door");
            string inputEditSelection = Console.ReadLine();
            switch (inputEditSelection)
            {
                case "1":
                    RemoveDoor();
                    break;

                case "2":
                    AddDoor();
                    break;

                default:
                    Console.WriteLine("Invalid Selection");
                    break;
            }
        }

        void AddDoor()
        {
            Console.Clear();
            Console.WriteLine("\nInput BADGE ID to retrieve a Badge");
            int inputDictKey = int.Parse(Console.ReadLine());

            Badge badge = _badgeRepo.GetBadgeByKey(inputDictKey);
            
            bool hasAssignedAllDoors = false;
            while (hasAssignedAllDoors == false)
            {
                Console.WriteLine("\nDo you need assign badge access to doors?: Y/N");
                string userinput = Console.ReadLine().ToLower();
                if (userinput == "y")
                {
                    Console.WriteLine("\nInput DOOR NAME to ASSIGN ACCESS.");
                    string inputDoorAccess = Console.ReadLine();
                    badge.Doors.Add(inputDoorAccess); // <- Adding to doors List
                }
                if (userinput == "n")
                {
                    hasAssignedAllDoors = true;
                }
            }           
        }

        void RemoveDoor()
        {
            Console.WriteLine("\nInput DICTIONARY KEY to REMOVE.");
            int inputDictKey = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInput DOOR NAME to REMOVE.");
            string inputDoorName = Console.ReadLine();

            bool isSuccessful = _badgeRepo.RemoveDoor(inputDictKey, inputDoorName);
            if (isSuccessful)
            {
                Console.WriteLine("Successully Removed");
            }
            else
            {
                Console.WriteLine("Failure to Remove");
            }
        }

    private void Seed()
        {
            Badge badge1 = new Badge(1, new List<string> { "B001", "A1" });
            Badge badge2 = new Badge(2, new List<string> { "B002", "A2" });
            Badge badge3 = new Badge(15, new List<string> { "B003", "A3" });

            _badgeRepo.AddToDatabase(badge1);
            _badgeRepo.AddToDatabase(badge2);
            _badgeRepo.AddToDatabase(badge3);
        }
    }
}