using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonDontGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            int sum = 0;

            while (inputList.Count >= 1)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < inputList.Count)
                {
                    sum += inputList[index];
                    GetPokemonNormalIndex(inputList, index);
                }
                else if (index < 0)
                {
                    sum += inputList[0];
                    GetPokemonLessIndex(inputList, index);
                }
                else if (index >= inputList.Count)
                {
                    sum += inputList[inputList.Count - 1];
                    GetPokemonGreatIndex(inputList, index);
                }
            }

            Console.WriteLine(sum);
        }


        static void GetPokemonNormalIndex(List<int> inputList, int index)
        {
            int currentIndex = inputList[index];
            inputList.RemoveAt(index);

            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] <= currentIndex)
                {
                    inputList[i] += currentIndex;
                }
                else
                {
                    inputList[i] -= currentIndex;
                }
            }        
        }

        static void GetPokemonLessIndex(List<int> inputList, int index)
        {
            int currentValue = inputList[0];

            inputList.RemoveAt(0);
            inputList.Insert(0, inputList[inputList.Count - 1]);

            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] <= currentValue)
                {
                    inputList[i] += currentValue;
                }
                else
                {
                    inputList[i] -= currentValue;
                }
            }

        }

        static void GetPokemonGreatIndex(List<int> inputList, int index)   ///???
        {
            int currentValue = inputList[inputList.Count - 1];

            inputList.RemoveAt(inputList.Count - 1);
            inputList.Insert(inputList.Count, currentValue);

            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i] <= currentValue)
                {
                    inputList[i] += currentValue;
                }
                else
                {
                    inputList[i] -= currentValue;
                }
            }

        }
    }
}
