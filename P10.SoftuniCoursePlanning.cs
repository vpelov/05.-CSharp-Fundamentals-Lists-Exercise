using System;
using System.Collections.Generic;
using System.Linq;

namespace P10.SoftuniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string inputCommand = Console.ReadLine();

            while (inputCommand != "course start")
            {
                string[] commandArray = inputCommand.Split(":");
                string command = commandArray[0];
                string lessonTitle = commandArray[1];

                switch (command)
                {
                    case "Add":
                        DoAdd(inputData, lessonTitle);
                        break;

                    case "Insert":
                        int index = int.Parse(commandArray[2]);
                        DoInsert(inputData, lessonTitle, index);
                        break;

                    case "Remove":

                        break;

                    case "Swap":

                        break;

                    case "Exercise":

                        break;
                }


                inputCommand = Console.ReadLine();
            }




        }

        static void DoAdd(List<string> inputData, string lessonTitle) 
        {
            if (!inputData.Contains(lessonTitle))
            {
                inputData.Add(lessonTitle);
            }        
        }

        static void DoInsert(List<string> inputData, string lessonTitle, int index)
        {
            if (index < 0 || index > inputData.Count - 1)
            {
                return;
            }

            if (!inputData.Contains(lessonTitle))
            {
                inputData.Insert(index, lessonTitle);
            }
        
        
        }

    }
}
