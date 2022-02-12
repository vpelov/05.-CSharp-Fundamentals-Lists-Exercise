using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            int minLenght = Math.Min(firstHand.Count, secondHand.Count);


            while (minLenght > 0)
            {
                for (int i = 0; i < minLenght; i++)
                {
                    if (firstHand.Count > 0 && secondHand.Count > 0)
                    {


                        int numberFirst = firstHand[i];
                        int numberSecond = secondHand[i];

                        if (firstHand[i] > secondHand[i])
                        {
                            //int index = firstHand.IndexOf(number);
                            firstHand.Add(secondHand[i]);
                            secondHand.Remove(numberSecond);
                            firstHand.Add(firstHand[i]);
                            firstHand.Remove(numberFirst);
                            i--;
                        }
                        else if (firstHand[i] == secondHand[i])
                        {
                            firstHand.Remove(numberFirst);
                            secondHand.Remove(numberSecond);
                            i--;
                        }
                        else if (firstHand[i] < secondHand[i])
                        {
                            secondHand.Add(firstHand[i]);
                            firstHand.Remove(numberFirst);
                            secondHand.Add(secondHand[i]);
                            secondHand.Remove(numberSecond);
                            i--;
                        }
                    }
                    else
                    {
                        break;
                    }

                }

                minLenght = Math.Min(firstHand.Count, secondHand.Count);
            }


            int sumFirst = firstHand.Sum();
            int sumSecond = secondHand.Sum();
            if (sumFirst != 0)
            {
                Console.WriteLine($"First player wins! Sum: {sumFirst}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {sumSecond}");
            }
            
        }
    }
}
