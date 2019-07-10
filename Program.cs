using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                AdditionOf100(10);
                Console.ReadLine();
            }
        }

        static void AdditionOf100(int seed)
        {
            if (seed < 10)
                throw new ArgumentOutOfRangeException("Seed must >= 10");
            int num1, num2;
            int result=0, result_reversed = 0;

            Random rnd = new Random();
            num1 = rnd.Next(1, seed);
            num2 = rnd.Next(1, seed);

            Console.WriteLine($"{num1} + {num2} = ?");
            Console.ReadLine();

            int max = num1 >= num2 ? num1:num2 ;
            bool isZeroOfHighestResult_Reversed = false;

            int remainder, num1_remainder, num2_remainder, additionCarry=0;
            int stepCount = 0;
            while(max>0)
            {
                stepCount++;
                num1_remainder = num1 % 10;
                num1 = num1 / 10;

                num2_remainder = num2 % 10;
                num2 = num2 / 10;

                remainder = (num1_remainder + num2_remainder + additionCarry) % 10;

                // if the lowest level of result is 0
                if (remainder == 0 && result_reversed == 0)
                    isZeroOfHighestResult_Reversed = true;

                // construct the result in reversed sequence
                result_reversed = result_reversed * 10 + remainder;

                if(additionCarry>0)
                {
                    Console.WriteLine($"Step {stepCount}: {num1_remainder} + {num2_remainder} + {additionCarry} = {remainder}");
                }
                else
                    Console.WriteLine($"Step {stepCount}: {num1_remainder} + {num2_remainder} = {remainder}");

                additionCarry = (num1_remainder + num2_remainder + additionCarry) / 10;
                if(additionCarry>0)
                    Console.WriteLine($"        Addition Carry: {additionCarry}");

                // Control the while loop
                max = max / 10;
            }

            // if there is overflow for the highest level
            if (additionCarry > 0)
                result_reversed = result_reversed * 10 + additionCarry;

            // construct the result
            while(result_reversed>0)
            {
                result = result * 10 + result_reversed % 10;
                result_reversed = result_reversed / 10;
            }

            // add the lowest 0
            if (isZeroOfHighestResult_Reversed)
                result = result * 10;

            Console.WriteLine($"Step {++stepCount}: Result is {result}");
        }
    }
}
