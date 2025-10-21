using System;
using System.Collections.Generic;
using System;

public class CM_24_25_PT02
{
    /*
    public static double PolyValue(double[] coefficients, double x)
        Input:
            an array of polynomial coefficients and a single value x
        Output:
            a value of a polynomial described by the coefficients at point x
        Examples:
            PolyValue({1, -1.5}, 2) 	-> 0.5
            PolyValue({1, -2, 1}, 0) 	-> 1
            PolyValue({1, -2, 1}, 3) 	-> 4
        */
    public static double PolyValue(double[] coefficients, double x)
    {
        /* Replace this with your code */
        return Double.PositiveInfinity;
    }

    /*
    public static double[] PolyDerivative(double[] coefficients)
        Input:
            an array of polynomial coefficients
        Output:
            an array of coefficients of the input polynomial derivative
        Examples:
            PolyDerivative({1, -1.5}) 		-> {1}
            PolyDerivative({1, -2, 1}) 		-> {2, -2}
            PolyDerivative({1, 2, 2}) 		-> {2, 2}
            PolyDerivative({2, 2, -4, 0}) 	-> {6, 4, -4}
    */
    public static double[] PolyDerivative(double[] coefficients)
    {
        /* Replace this with your code */
        return new double[] { };
    }

    /*
    public static double PolyRoot(double[] coefficients)
        Input:
            an array of polynomial coefficients
        Output:
            an approximation of a single root of the input polynomial or Infinity, if there is none found
        Examples:
            PolyRoot({1, -1.5}) 		-> 1.5
            PolyRoot({1, -2, 1}) 		-> 1
            PolyRoot({1, 2, 2}) 		-> Infinity
            PolyRoot({2, 2, -4, 0}) 	-> -2
    */
    public static double PolyRoot(double[] coefficients)
    {
        /* Replace this with your code */
        /* Use the `PolyValue` and the `PolyDerivative` methods to implement this function. */
        return Double.PositiveInfinity;
    }

    /*
    public static double[] PolyDiv(double[] coefficients, double xi)
        Input:
            an array of polynomial coefficients and its root xi
        Output:
            an array of coefficients of the quotient of the division of the input polynomial by (x - xi)
        Examples:
            PolyDiv({1, -1.5}, 1.5) 	-> {1}
            PolyDiv({1, -2, 1}, 1) 		-> {1, -1}
            PolyDiv({2, 2, -4, 0}, 0) 	-> {2, 2, -4}
    */
    public static double[] PolyDiv(double[] coefficients, double xi)
    {
        /* Replace this with your code */
        return new double[] { };
    }

    /*
    public static double[] PolyRoots(double[] coefficients)
        Input:
            an array of polynomial coefficients
        Output:
            an array of real roots of the input polynomial (or their approximations)
        Examples:
            PolyRoots({1, -1.5}) 		-> {1.5}
            PolyRoots({1, -2, 1}) 		-> {1, 1}
            PolyRoots({1, 2, 2}) 		-> {}
            PolyRoots({2, 2, -4, 0}) 	-> {0, 1, -2}
    */
    public static double[] PolyRoots(double[] coefficients)
    {
        /* Replace this with your code */
        /* Use the `PolyRoot` and the `PolyDiv` methods to implement this function. */
        return new double[] { };
    }

    public static void Main(string[] args)
    {
        /* Feel free to use this method to test your solution. */
        List<double> nums = new List<double>();
        string source;

        // loop to ask for arguments
        do
        {
            double number;
            Console.Clear();
            Console.Write("Coefficients so far: ");

            Console.Write("[ ");
            foreach (double i in nums)
            {
                Console.Write($"{i}, ");
            }
            Console.Write("]\n");

            Console.WriteLine("Please enter positive or negative coefficients: \nEnter 'Q' or 'q' to stop entry");
            source = Console.ReadLine();

            if (!double.TryParse(source, out number)) continue;

            nums.Add(number);
        } while (source.ToLower() != "q");

        foreach (double i in PolyRoots(nums.ToArray()))
        {
            Console.WriteLine(i);
        }

        // HOLD THE LINE (terminal window) !!!
        Console.ReadLine();
    }
}