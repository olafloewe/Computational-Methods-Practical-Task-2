using System;
using System.Collections.Generic;

public class CM_24_25_PT02{
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
    public static double PolyValue(double[] coefficients, double x){
        int power = 0;
        double result = 0.0;
        // coefficient nums[i]
        // exponent (nums.ToArray().Length - (i + 1))

        for (int i = 0; i < coefficients.Length; i++){
            result += coefficients[i] * (x * power);
            power = (power == 0)? 1 : power * (int)x;
        }
        Console.WriteLine($"PolyValue result at {x}: {result}");
        return (result == 0.0) ? Double.PositiveInfinity : result; 
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
    public static double[] PolyDerivative(double[] coefficients){
        double[] derivateCoefficients = new double[coefficients.Length - 1];

        for (int i = 0; i < derivateCoefficients.Length; i++) {
            derivateCoefficients[derivateCoefficients.Length - (i+1)] = coefficients[derivateCoefficients.Length - (i+1)] * (i + 1);
        }

        return derivateCoefficients;
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
    public static double PolyRoot(double[] coefficients){
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
    public static double[] PolyDiv(double[] coefficients, double xi){
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
    public static double[] PolyRoots(double[] coefficients){
        /* Use the `PolyRoot` and the `PolyDiv` methods to implement this function. */
        return new double[] { };
    }

    public static void Main(string[] args){
        List<double> nums = new List<double>();
        string source;

        // loop to ask for arguments
        do{
            double number;
            Console.Clear();
            Console.Write("Coefficients so far: ");

            // print formated coefficients
            Console.Write("[ ");
            foreach (double i in nums){
                Console.Write($"{i}, ");
            }
            Console.Write("]\n");

            Console.WriteLine("Please enter up to 10 positive or negative coefficients: \nEnter 'Q' or 'q' to stop entry");
            source = Console.ReadLine();

            if (!double.TryParse(source, out number)) continue;

            nums.Add(number);
        } while (source.ToLower() != "q");

        /* Derivative test
         */
        Console.WriteLine("Polynomial: ");
        for (int i = 0; i < nums.ToArray().Length; i++){
            Console.Write($"{nums[i]}x^{nums.ToArray().Length - (i+1)} ");
        }
        Console.WriteLine();

        double[] derivative = PolyDerivative(nums.ToArray());

        Console.WriteLine("Derivative: ");
        for (int i = 0; i < derivative.Length; i++){
            Console.Write($"{derivative[i]}x^{derivative.Length - (i + 1)} ");
        }
        Console.WriteLine();

        // Console.WriteLine($"Value: {PolyValue(nums.ToArray(), 2)}");



        // HOLD THE LINE (terminal window) !!!
        Console.ReadLine();
    }
}