using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArray = command.Split();

                int num = CheckStringOrNumber(commandArray[0]);

                if (num == 0)
                {
                    int wagonPeople = int.Parse(commandArray[1]);
                    train.Add(wagonPeople);
                }
                else if (num != 0)
                {
                    for (int i = 0; i < train.Count; i++)
                    {
                        int currentpeople = int.Parse(commandArray[0]);
                        if (train[i] + currentpeople <= maxCapacity)
                        {
                            train[i] += currentpeople;
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", train));


            static int CheckStringOrNumber(string someText) 
            {
                int number;
                bool isNum = int.TryParse(someText, out number);
                return number;
            
            
            }
        }
    }
}
