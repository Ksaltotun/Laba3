using System;
using System.Collections.Generic;

namespace Laba3_Var9
{
    public class OutOfRangeX : Exception
    {
        public OutOfRangeX(String message)
            : base(message)
        {

        }
    }
    class Laba3PartOne
    {   
        public static double CalValue(double x)
        {
            double y = 0;
            try
            {
                if (-9 <= x && x <= -7 )
                {
                    y = 0;
                } else if ( -7 < x && x <= -3)
                {
                    y = x + 7;
                } else if (-3 < x && x <= -2)
                {
                    y = 4;
                } else if (-2 < x && x <= 2)
                {
                    y = x * x;
                } else if (2 < x && x <= 4)
                {
                    y = -2 * x + 8;
                } else if (4 < x && x <= 7)
                {
                    y = 0;
                } else
                {
                    throw new OutOfRangeX("Извените за мат, но х не может быть меньше -9 или больше 7");
                }

            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine($"Вы ввели x = {x}, результат y = {y}");
            return y;
        }
    }

    class Laba3PartTwo
    {
        class ArgumentAndFunction
        {
            double argument;
            double function;
            public ArgumentAndFunction(double x, double y) { argument = x; function = y; }
        }
        public static double CalculateArctangens(double xStart, double xEnd, int step, double accuracy)
        {
            double currentValue = xStart;
            double valuePrev;
            double valueNext;
            List<ArgumentAndFunction> resultCollection = new List<ArgumentAndFunction>();
            while (currentValue <= xEnd)
            {
                valuePrev = Math.Pow(currentValue, 3);
                valueNext = valuePrev;
                for (int i = 2; ; i++)
                {
                    valueNext += Math.Pow(currentValue, 2 * i + 1) * Math.Pow(-1, i) / (2 * i + 1);
                    if (Math.Abs(valuePrev - valueNext) <= accuracy)
                    {
                        resultCollection.Add(new ArgumentAndFunction(currentValue, valueNext));
                        break;
                    }
                    if (i > 200)
                    {
                        Console.WriteLine("More than 200");
                        return 0;
                    }
                }
            }
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Laba3PartOne.CalValue(-1);
        }
    }
}


