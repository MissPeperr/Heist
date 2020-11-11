using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace adams_exercise
{
    class Program
    {
        // A bunch of dots and thread.sleep() to simulate the app loading
        static void Loading()
        {
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(1000);
            Console.WriteLine();
        }
        // Collects user input for whether or not they want to create a new operative
        static ConsoleKeyInfo CollectUserInput(List<IRobber> memberList)
        {
            Console.WriteLine($"There are currently {memberList.Count()} operatives ready for a heist.");
            Console.WriteLine();
            Console.WriteLine("Add more operatives?");
            Console.WriteLine("[Y] [N]");
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            return keyInfo;
        }

        // Checks if user wants to create a new operative & creates it
        static bool UserCreatingOperatives(List<IRobber> rolodex, ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Y)
            {
                IRobber newOperative = CreateOperative();
                rolodex.Add(newOperative);
                Console.WriteLine("Operative Created.");
                Console.WriteLine();
                Console.WriteLine($"New Operative, {newOperative.Name}:");
                Console.WriteLine($"Skill Level: {newOperative.SkillLevel}");
                Console.WriteLine($"Percentage of Heist: {newOperative.PercentageCut}%");
                return true;

            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                Console.WriteLine();
                Console.Write("Starting the Heist");
                Loading();
                Console.Write("Configuring Bank");
                Loading();
                Thread.Sleep(1000);
                return false;
            }
            return false;
        }

        // Creates a new operative
        static IRobber CreateOperative()
        {
            Console.Clear();
            Console.WriteLine("Please enter a name:");
            Console.Write("> ");

            string name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Your operative's name: {name}");
            Console.WriteLine();
            Console.WriteLine("Select a specialty:");
            Console.WriteLine("1. Hacker (disables alarms)");
            Console.WriteLine("2. Muscle (takes out security guards)");
            Console.WriteLine("3. Lock Specialist (cracks vaults)");
            Console.Write("> ");

            string option = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"{option} selected.");
            Console.WriteLine();
            Console.WriteLine("Enter a skill level (1-100):");
            Console.Write("> ");

            string level = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Skill level set to {level}.");
            Console.WriteLine();
            Console.WriteLine("Enter the percentage of this operative's cut:");
            Console.Write("> ");

            string percentageAmount = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Percentage of cut: {percentageAmount}.");
            Console.WriteLine();

            Console.Clear();
            Console.Write("Creating new operative");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(1000);

            switch (option)
            {
                case "1":
                    return new Hacker()
                    {
                        Name = name,
                        SkillLevel = Convert.ToInt32(level),
                        PercentageCut = Convert.ToInt32(percentageAmount)
                    };
                case "2":
                    return new Muscle()
                    {
                        Name = name,
                        SkillLevel = Convert.ToInt32(level),
                        PercentageCut = Convert.ToInt32(percentageAmount)
                    };
                case "3":
                    return new LockSpecialist()
                    {
                        Name = name,
                        SkillLevel = Convert.ToInt32(level),
                        PercentageCut = Convert.ToInt32(percentageAmount)
                    };
                default:
                    Console.WriteLine("you suck");
                    break;
            }
            return null;
        }

        // Prints a report of each operative in the rolodex
        static void PrintOpReport(List<IRobber> rolodex)
        {
            Console.Write("Preparing Operatives");
            Loading();
            Console.WriteLine("Please choose an operative for the heist:");
            int counter = 1;
            foreach (var op in rolodex)
            {
                Console.WriteLine($"{counter}. {op.GetType().Name} {op.Name}");
                Console.WriteLine($"        Skill Level: {op.SkillLevel}");
                Console.WriteLine($"        Percentage Cut: {op.PercentageCut}%");
                counter++;
            }
            Console.Write("> ");
        }
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>();
            Hacker Bob = new Hacker()
            {
                Name = "Bob",
                SkillLevel = 10,
                PercentageCut = 10
            };
            Hacker Mike = new Hacker()
            {
                Name = "Mike",
                SkillLevel = 30,
                PercentageCut = 10
            };
            Muscle Gina = new Muscle()
            {
                Name = "Gina",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialist Job = new LockSpecialist()
            {
                Name = "Job",
                SkillLevel = 45,
                PercentageCut = 15
            };
            Muscle Frank = new Muscle()
            {
                Name = "Frank",
                SkillLevel = 32,
                PercentageCut = 10
            };
            Hacker Jenny = new Hacker()
            {
                Name = "Jenny",
                SkillLevel = 50,
                PercentageCut = 25
            };
            rolodex.Add(Jenny);
            rolodex.Add(Frank);
            rolodex.Add(Job);
            rolodex.Add(Gina);
            rolodex.Add(Mike);
            rolodex.Add(Bob);

            bool isCreatingOperatives = true;
            do
            {
                // collect input from user on whether or not they want to create a new operative
                ConsoleKeyInfo keyInfo = CollectUserInput(rolodex);
                // returns whether or not they're creating a new operative
                isCreatingOperatives = UserCreatingOperatives(rolodex, keyInfo);
            } while (isCreatingOperatives);

            // Create a new bank to rob with random score values between 0-100
            Random randomNum = new Random();
            Bank RobThisBank = new Bank()
            {
                AlarmScore = randomNum.Next(0, 100),
                VaultScore = randomNum.Next(0, 100),
                SecurityGuardScore = randomNum.Next(0, 100)
            };

            // Store all of the scores in a dictionary. Key = name of the score, Value = value of the score
            Dictionary<string, int> AllScores = new Dictionary<string, int>();
            AllScores.Add("Alarm", RobThisBank.AlarmScore);
            AllScores.Add("Vault", RobThisBank.VaultScore);
            AllScores.Add("Security Guards", RobThisBank.SecurityGuardScore);

            // Sort the dictionary from lowest score to highest score
            var sortedScores = from pair in AllScores
                               orderby pair.Value ascending
                               select pair;

            Console.WriteLine();
            Console.WriteLine("Bank Configured.");
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Bank Stats:");
            Console.WriteLine($"Most Secure: {sortedScores.Last().Key}");
            Console.WriteLine($"Least Secure: {sortedScores.First().Key}");
            Console.WriteLine();

            PrintOpReport(rolodex);

            var option = Console.ReadLine();
            bool isCreatingCrew = true;
            List<IRobber> crew = new List<IRobber>();

            do
            {
                // starting at 1 because our options don't start at 0 (and Count is how many items)
                for (int i = 1; i <= rolodex.Count(); i++)
                {
                    if (option == i.ToString())
                    {
                        crew.Add(rolodex[i - 1]);
                    }
                }

            } while (isCreatingCrew);

        }
    }
}
