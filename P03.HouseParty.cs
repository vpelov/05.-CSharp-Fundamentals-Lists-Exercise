using System;
using System.Linq;
using System.Collections.Generic;

namespace P03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args) // NOT READY
        {
            List<string> guest = new List<string>();

            int numberCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCommands; i++)
            {
                string command = Console.ReadLine();
                string[] commandArray = command.Split(' ');
                string name = commandArray[0];

                if (commandArray.Count() == 3)
                {
                    if (guest.Contains(name) == false )
                    {
                        guest.Add(name);
                    }
                    else if (guest.Contains(name) == true)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }

                if (commandArray.Count() == 4)
                {
                    if (guest.Contains(name))
                    {
                        guest.Remove(name);
                    }
                    else if (guest.Contains(name) == false)
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }

            }

            foreach (string item in guest)
            {
                Console.WriteLine(item);
            }
                        
        }
    }
}
