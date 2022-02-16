using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputText = Console.ReadLine().Split(' ').ToList();
            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] commandArray = command.Split(' ').ToArray();

                if (commandArray[0] == "merge")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int endIndex = int.Parse(commandArray[2]);

                    inputText = GoMerge(inputText, startIndex, endIndex);

                }
                else if (commandArray[0] == "divide")
                {
                    int index = int.Parse(commandArray[1]);
                    int partition = int.Parse(commandArray[2]);

                    inputText = GetDivide(inputText, index, partition);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", inputText));

        }

        static List<string> GoMerge(List<string> currentList, int start, int end)
        {
            List<string> middleResult = currentList;

            if (end < currentList.Count)
            {
                int index = start;
                for (int i = start + 1; i <= end; i++)      //concatenate string
                {
                    middleResult[index] = middleResult[index] + middleResult[i];
                }
                for (int i = end; i > start; i--)            // Remove index
                {
                    middleResult.RemoveAt(i);
                }

            }
            else if (end >= currentList.Count)
            {
                int index = start;
                for (int i = start + 1; i < currentList.Count; i++)       //concatenate string
                {
                    middleResult[index] = middleResult[index] + middleResult[i];
                }
                for (int i = currentList.Count - 1; i > start; i--)        // Remove index
                {
                    middleResult.RemoveAt(i);
                }
            }

            return middleResult;
        }


        static List<string> GetDivide(List<string> currentList, int index, int partition)
        {
            string work = currentList[index];
            currentList.RemoveAt(index);
            int step = work.Length / partition;

            if (work.Length % partition == 0)
            {
                for (int i = work.Length - 1; i >= 0; i -= step)
                {
                    string element = work.Substring(i - step + 1, step);
                    currentList.Insert(index, element);
                }

            }
            else if (work.Length % partition != 0)
            {
                int count = 0;
                for (int i = 0; i < work.Length; i += step)
                {
                    string element = work.Substring(i, step);
                    currentList.Insert(index + count, element);
                    count++;
                    if (count == partition)
                    {
                        break;
                    }
                }

                int endSymbolIndex = work.Length - (work.Length % partition);
                currentList[index + count - 1] += work.Substring(endSymbolIndex, work.Length - (partition * step));
            }

            return currentList;
        }
    }
}
