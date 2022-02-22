using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.AnonymousThreat2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "merge")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int endIndex = int.Parse(commandArray[2]);

                    DoMerge(inputData, startIndex, endIndex);
                }
                else if (commandArray[0] == "divide")
                {
                    int index = int.Parse(commandArray[1]);
                    int numPartition = int.Parse(commandArray[2]);

                    DoDivide(inputData, index, numPartition);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", inputData));
        }



        static void DoMerge(List<string> inputList, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > inputList.Count - 1)
            {
                endIndex = inputList.Count - 1;
            }

            for (int i = startIndex; i < endIndex; i++)
            {

                inputList[startIndex] += inputList[i + 1];
                inputList.RemoveAt(i + 1);
                i--;
                endIndex--;
            }
        }


        static void DoDivide(List<string> inputList, int index, int numPart)
        {
            string workString = inputList[index];
            int currentLenghtString = workString.Length;

            if (currentLenghtString < numPart)
            {
                return;
            }

            if (currentLenghtString % numPart == 0)
            {
                int step = currentLenghtString / numPart;

                for (int i = numPart - 1; i >= 0; i--)
                {
                    string diff = workString.Substring(currentLenghtString - step, step );
                    inputList.Insert(index, diff);
                    currentLenghtString -= step;

                }
                inputList.RemoveAt(index + numPart);
            }
            else if (currentLenghtString % numPart != 0)   // List<int> inputList, int index, int numPart  //
            {
                int step = currentLenghtString / numPart;
                int remainder = currentLenghtString % numPart;
                List<string> temporary = new List<string>();
                int count = 0;

                for (int i = 0; i < numPart; i++)
                {
                    if (i == (numPart - 1))
                    {
                        string temp = workString.Substring(count, (currentLenghtString - step * (numPart - 1)));
                        temporary.Add(temp);
                    }
                    else
                    {
                        string temp = workString.Substring(count, step);
                        temporary.Add(temp);
                        count += step;
                    }
                }

                inputList.RemoveAt(index);

                for (int i = numPart - 1; i >= 0; i--)
                {
                    inputList.Insert(index, temporary[i]);
                }                                             
                
            }

        }

    }
}
