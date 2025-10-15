using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2 {
    internal class Program {
        public static double[] PolyRoots(double[] coefficients) { 
            return coefficients;
        }

        public static void Main(string[] args) {

            List<double> nums = new List<double>();
            string source;

            // loop to ask for arguments
            do{
                double number;
                Console.Clear();
                Console.Write("Coefficients so far: ");

                Console.Write("[ ");
                foreach (double i in nums) {
                    Console.Write($"{i}, ");
                }
                Console.Write("]\n");

                Console.WriteLine("Please enter positive or negative coefficients: \nEnter 'Q' or 'q' to stop entry");
                source = Console.ReadLine();

                if(!double.TryParse(source, out number)) continue;

                nums.Add(number);
            } while (source.ToLower() != "q");

            foreach (double i in PolyRoots(nums.ToArray())) { 
                Console.WriteLine(i);
            }

            // HOLD THE LINE (terminal window) !!!
            Console.ReadLine();
        }
    }
}