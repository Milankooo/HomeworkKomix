using System;

namespace homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Order by size from big to small
            int[] pole = { 1, 80, 5, 2, 7, 80, 13, 20 };
            int[] poleOrdered = new int[pole.Length];

            for (int i = 0; i < pole.Length; i++)
            {
                // sets first number in first pos
                if (i == 0)
                {
                    poleOrdered.SetValue(pole[i], i);
                    continue;
                }

                var currentVal = pole[i];
                if (poleOrdered[i - 1] > currentVal)
                {
                    poleOrdered.SetValue(currentVal, i);
                }
                else
                {
                    for (int j = 1; j < i + 1; j++)
                    {
                        int val = poleOrdered[i - j];
                        if (val < currentVal)
                        {
                            poleOrdered = MoveDownByOne(i - j, poleOrdered); //moves number down by one 
                            poleOrdered.SetValue(currentVal, i - j);
                            if (i - j != 0)
                                continue;
                        }

                        //for same numbers
                        if (val == currentVal)
                        {
                            poleOrdered.SetValue(currentVal, i - j + 1);
                        }
                        break;
                    }
                }
            }

            foreach (var item in poleOrdered)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static int[] MoveDownByOne(int startPos, int[] pole)
        {
            pole.SetValue(pole[startPos], startPos + 1);

            return pole;
        }
    }
}
