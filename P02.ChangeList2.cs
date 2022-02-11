using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArray = command.Split().ToArray();

                if (commandArray[0] == "Delete")
                {
                    int delElement = int.Parse(commandArray[1]);
                    numberList.RemoveAll(x => x == delElement);

                }
                else if (commandArray[0] == "Insert")
                {
                    int element = int.Parse(commandArray[1]);
                    int index = int.Parse(commandArray[2]);

                    numberList.Insert(index, element);

                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numberList));

        }
    }
}