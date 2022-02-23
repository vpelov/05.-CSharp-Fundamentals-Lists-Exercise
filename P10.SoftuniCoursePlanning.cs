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
                        DoRemove(inputData, lessonTitle);
                        break;

                    case "Swap":
                        string lessonTitleTwo = commandArray[2];
                        inputData = DoSwap(inputData, lessonTitle, lessonTitleTwo);
                        break;

                    case "Exercise":
                        DoExercise(inputData, lessonTitle);
                        break;
                }


                for (int i = 0; i < inputData.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{inputData[i]}");
                }




                inputCommand = Console.ReadLine();
            }


            for (int i = 0; i < inputData.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{inputData[i]}");
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

        static void DoRemove(List<string> inputData, string lessonTitle)
        {
            if (inputData.Contains(lessonTitle))
            {
                inputData.Remove(lessonTitle);
                if (inputData.Contains(lessonTitle + "-Exercise"))
                {
                    inputData.Remove(lessonTitle + "-Exercise");
                }
            }


        }

        static List<string> DoSwap(List<string> inputData, string lessonTitleOne, string lessonTitleTwo)
        {
            List<string> newList = new List<string>();

            for (int i = 0; i < inputData.Count; i++)
            {
                newList.Add(inputData[i]);
            }

            if (inputData.Contains(lessonTitleOne) && inputData.Contains(lessonTitleTwo))
            {
                int indexOne = 0;
                int indexTwo = 0;

                for (int i = 0; i < inputData.Count; i++)
                {
                    if (inputData[i] == lessonTitleOne)
                    {
                        indexOne = i;                    
                    }
                    if (inputData[i] == lessonTitleTwo)
                    {
                        indexTwo = i;
                    }
                }

                if (newList[indexOne] == lessonTitleOne)
                {
                    newList[indexOne] = lessonTitleTwo;
                    newList[indexTwo] = lessonTitleOne;
                }
                else
                {
                    newList[indexOne] = lessonTitleOne;
                    newList[indexTwo] = lessonTitleTwo;
                }

                if (indexOne + 1  < inputData.Count && indexTwo + 1 < inputData.Count)
                {
                    if (inputData[indexOne + 1] == lessonTitleOne + "-Exercise" && inputData[indexTwo + 1] == lessonTitleTwo + "-Exercise")
                    {
                        newList.RemoveAt(indexTwo + 1);
                        newList.Insert(indexTwo + 1, lessonTitleOne + "-Exercise");
                        newList.RemoveAt(indexOne + 1);
                        newList.Insert(indexOne + 1, lessonTitleTwo + "-Exercise");
                        return newList;
                    }
                }

                if (indexOne + 1 < inputData.Count && inputData[indexOne + 1] == lessonTitleOne + "-Exercise")
                {
                    newList.RemoveAt(indexOne + 1);
                    newList.Insert(indexTwo + 1, lessonTitleOne + "-Exercise");
                    return newList;
                }

                if (indexTwo + 1 < inputData.Count && inputData[indexTwo + 1] == lessonTitleTwo + "-Exercise")
                {
                    newList.RemoveAt(indexTwo + 1);
                    newList.Insert(indexOne + 1, lessonTitleTwo + "-Exercise");
                    return newList;
                }


            }




            return newList;
        }

        static void DoExercise(List<string> inputData, string lessonTitle)
        {
            if (inputData.Contains(lessonTitle))
            {
                if (inputData.Contains(lessonTitle + "-Exercise"))
                {
                    return;
                }
                else
                {
                    int temp = int.MinValue;

                    for (int i = 0; i < inputData.Count; i++)
                    {
                        if (inputData[i] == lessonTitle)
                        {
                            temp = i;
                        }
                    }

                    inputData.Insert(temp + 1, lessonTitle + "-Exercise");

                }
            }
            else if (!inputData.Contains(lessonTitle))
            {
                inputData.Add(lessonTitle);
                inputData.Add(lessonTitle + "-Exercise");
            }




        }
    }
}
