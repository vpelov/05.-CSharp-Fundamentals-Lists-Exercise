using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = Console.ReadLine().Split("|").ToList();
            inputList.Reverse();

            List<int> result = new List<int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                List<int> currentList = new List<int>(inputList[i]. Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

                result.AddRange(currentList);
            }


            Console.WriteLine(String.Join(" ", result)
                );


        }
    }
}
