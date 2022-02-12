using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] arrNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bombNumber = arrNumber[0];
            int bombPower = arrNumber[1];

            while (numberList.Contains(bombNumber))
            {
                DetonateList(numberList, bombNumber, bombPower);
            }


            int sum = numberList.Sum();
            Console.WriteLine(sum);
        }

        static List<int> DetonateList(List<int> numberList, int bombNumber, int bombPower)
        {

            List<int> resultList = new List<int>();
            int minIndex = 0;
            int MaxIndex = 0;

            int bombIndex = numberList.IndexOf(bombNumber);

            if (bombIndex - bombPower < 0)
            {
                minIndex = 0;
            }
            else
            {
                minIndex = bombIndex - bombPower;
            }

            if (bombIndex + bombPower >= numberList.Count)
            {
                MaxIndex = numberList.Count - 1;
            }
            else
            {
                MaxIndex = bombIndex + bombPower;
            }


            for (int i = MaxIndex; i >= minIndex; i--)
            {
                numberList.RemoveAt(i);
            }



            return resultList;
        }

    }
}
