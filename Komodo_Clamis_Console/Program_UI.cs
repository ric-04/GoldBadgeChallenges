using Komodo_Claims_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    public class Program_UI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }

        private void Menu()
        {
            bool hasStarted = true;
            while (hasStarted)
            {
                Console.WriteLine("Welcome to the Komodo Claims Application. \n" +
                    "What would you like to do?\n" +
                    "\n" +
                    "1] See All Claims\n" +
                    "2] Take Care of Next Claim\n" +
                    "3] Enter New Claim\n" +               "-------------------------------------------------------\n" +
                    "0] Exit Application\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "0":
                        hasStarted = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _claimRepo.GetAllClaims();
            foreach (var claim in claims)
            {
                DisplayClaimInfo(claim);
            }
        }

        private void DisplayClaimInfo(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID}\n" +
                $"{claim.ClaimType}\n" +
                $"{claim.Description}\n" +
                $"{claim.ClaimAmount}\n" +
                $"{claim.DateOfIncident}\n" +
                $"{claim.DateOfClaim}\n" +
                $"{claim.IsValid}" +
                $"---------------------------------\n");
        }

        private void TakeCareNextClaim()
        {
            Console.Clear();
            Claim claim = _claimRepo.ViewCurrentClaim();
            DisplayClaimInfo(claim);
            Console.WriteLine("\n");
            Console.WriteLine("Do you want to deal with this claim now? :Y/N");
            string inputClaimYorN = Console.ReadLine().ToLower();

            if (inputClaimYorN == "y")
            {
                bool isSuccessful = _claimRepo.DequeueClaim();
                if (isSuccessful)
                {
                    Console.WriteLine("Claim Handled.");
                }
                else
                {
                    Console.WriteLine("Claim not handled.");
                }
            }
            if (inputClaimYorN == "n")
            {
                Menu();
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Input claim ID.");
            int inputClaimID = int.Parse(Console.ReadLine());
            claim.ClaimID = inputClaimID;

            Console.WriteLine("\nInput claim TYPE.\n" +
                              "1] Car\n" +
                              "2] Home\n" +
                              "3] Theft\n");

            int inputClaimType = int.Parse(Console.ReadLine());
            ClaimType claimType = (ClaimType)inputClaimType;

            switch (claimType)
            {
                case ClaimType.Car:
                    claim.ClaimType = ClaimType.Car;
                    break;
                case ClaimType.Home:
                    claim.ClaimType = ClaimType.Home;
                    break;
                case ClaimType.Theft:
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Invalid Selection.");
                    break;
            }

            Console.WriteLine("\nInput claim DESCRIPTION.");
            string inputClaimDescription = Console.ReadLine();
            claim.Description = inputClaimDescription;

            Console.WriteLine("\nInput claim AMOUNT.");
            decimal inputClaimAmount = decimal.Parse(Console.ReadLine());
            claim.ClaimAmount = inputClaimAmount;

            DateTime inputDateofIncident = GetDateTimeValues("\nDATE OF INCIDENT");
            claim.DateOfIncident = inputDateofIncident;

            DateTime inputDateofClaim = GetDateTimeValues("\nDATE OF CLAIM");
            claim.DateOfClaim = inputDateofClaim;

            bool isSuccessful = _claimRepo.IsClaimValid(inputDateofClaim, inputDateofIncident, 30);
            if (isSuccessful)
            {
                Console.WriteLine("This is a VALID claim.");
                claim.IsValid=true;
            }
            else
            {
                Console.WriteLine("This is a INVALID Claim.");
            }
            _claimRepo.EnqueueToDatabase(claim);
        }

        private void SeedClaims()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Accident on 465.", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);

            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes!", 4.00m, new DateTime(2018, 04, 27), new DateTime(2018, 06, 11), false);

            // Add claims to repo
            _claimRepo.EnqueueToDatabase(claim1);
            _claimRepo.EnqueueToDatabase(claim2);
            _claimRepo.EnqueueToDatabase(claim3);
        }

        // Helper Method for DateTime
        private DateTime GetDateTimeValues(string claimTypeTitle)
        {
            Console.WriteLine(claimTypeTitle);
            Console.WriteLine("Year");
            int inputYearofIncident = int.Parse(Console.ReadLine());

            Console.WriteLine("\nMonth");
            int inputMonthofIncident = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDate of Month");
            int inputDayofIncident = int.Parse(Console.ReadLine());

            // Need to return DateTime
            DateTime dateTime = new DateTime(inputYearofIncident, inputMonthofIncident, inputDayofIncident);
            return dateTime;
        }
    }
}