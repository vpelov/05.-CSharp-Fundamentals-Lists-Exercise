using System;
using System.Linq;
using System.Collections.Generic;

namespace P04.ListOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();


            while (command != "End")
            {
                string[] commandArray = command.Split();

                switch (commandArray[0])
                {
                    case "Add":
                        numberList.Add(int.Parse(commandArray[1]));
                        break;

                    case "Insert":
                        if (int.Parse(commandArray[2]) < 0 || int.Parse(commandArray[2]) >= numberList.Count)  
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            numberList.Insert(int.Parse(commandArray[2]), int.Parse(commandArray[1]));
                        }
                        break;
                    case "Remove":
                        if (int.Parse(commandArray[1]) < 0 || int.Parse(commandArray[1]) >= numberList.Count )
                        { 
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                        numberList.RemoveAt(int.Parse(commandArray[1]));
                        }
                        break;
                    case "Shift":
                        string leftOrRight = commandArray[1];
                        int rotate = int.Parse(commandArray[2]);

                        numberList = GetRotate(numberList, leftOrRight, rotate);
                        break;
                }
               
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numberList));

        }

        static List<int> GetRotate(List<int> numberList, string rightLeft, int numberRotate)
        {
            int lenght = numberList.Count;

            if (rightLeft == "right")
            {
                for (int i = 0; i < numberRotate; i++)
                {
                    int lastElement = numberList[lenght - 1];
                    numberList.Insert(0, lastElement);
                    numberList.RemoveAt(lenght);
                }
            }
            else if (rightLeft == "left")
            {
                for (int i = 0; i < numberRotate; i++)
                {
                    int firstElement = numberList[0];
                    numberList.Add(firstElement);
                    numberList.RemoveAt(0);
                }
            }

            return numberList;
        }

    }
}
