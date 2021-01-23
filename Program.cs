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
            public double argument;
            public double function;
            public int stepCount;
            public double functionAuto;
            public ArgumentAndFunction(double x, double y, int i, double fA) { argument = x; function = y; stepCount = i; functionAuto = fA; }
        }

        private static void PrintTable(List<ArgumentAndFunction> resultTable, double accuracy)
        {
            string[] accuracyString = accuracy.ToString().Split(',');
            int accuracyCapacity = accuracyString[1].Length;
            string formatString = "{0, 5:f" + accuracyCapacity.ToString() + "}";
            foreach (ArgumentAndFunction i in resultTable)
            {
                Console.Write(String.Format("{0, 7 :0.000}", i.argument));
                Console.Write(String.Format("{0, 7 :0.000}", i.function));
                Console.Write(String.Format("{0, 7 :0.}", i.stepCount));
                Console.Write(String.Format("{0, 7 :0.000}", i.functionAuto));
                Console.WriteLine();
            }
        }
        public static double CalculateArctangens(double xStart, double xEnd, double step, double accuracy)
        {
            double currentValue = xStart;
            double valueNext;
            double functionAuto;
            List<ArgumentAndFunction> resultCollection = new List<ArgumentAndFunction>();
            while (currentValue <= xEnd)
            {
                double valuePrev = currentValue;
                for (int i = 1; ; i++)
                {
                    valueNext = valuePrev + Math.Pow(currentValue, 2 * i + 1) * Math.Pow(-1, i) / (2 * i + 1);
                    if (Math.Abs(valuePrev - valueNext) <= accuracy)
                    {
                        functionAuto = Math.Atan(currentValue);
                        resultCollection.Add(new ArgumentAndFunction(currentValue, valueNext, i, functionAuto));
                        break;
                    } else
                     {
                        valuePrev = valueNext;
                     }
                    if (i > 200)
                    {
                        Console.WriteLine("More than 200");
                        return 0;
                    }
                }
                currentValue += step;
            }
            PrintTable(resultCollection, accuracy);
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Laba3PartOne.CalValue(-1);
            Laba3PartTwo.CalculateArctangens(-0.99, 0.99, 0.01, 0.01);
        }
    }
}


