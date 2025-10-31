using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
        double power = 0;
        double result = 0.0;
        // coefficient nums[i]
        // exponent (nums.ToArray().Length - (i + 1))

        for (int i = 0; i < coefficients.Length; i++){
            power = (power == 0) ? 1 : power * x;
            result += coefficients[coefficients.Length-1-i] * power;
        }
        Console.WriteLine($"PolyValue result at {x}: {result}");
        return (result == 0.0) ? double.NaN : result; 
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

        // TODO check if derivative is zero
        double x0 = 5.0;
        double x1 = 0;
        double tollerance = 0.0000001;
        bool found = false;

        // newton method to check for root
        for (int i = 0; i < 1000 && !found; i++){
            x1 = (x0 - ((PolyValue(coefficients, x0)) / (PolyValue(PolyDerivative(coefficients), x0))));
            Console.WriteLine($"x0: {x0}, x1: {x1}");
            found = (Math.Abs((x0 - x1)) <= tollerance);
            x0 = x1;
        }

        return (found)? x1 : double.NaN;
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
        double[] dividedCoefficients = new double[coefficients.Length-1];

        // hornerschema
        dividedCoefficients[0] = coefficients[0];
        for (int i = 1; i < coefficients.Length - 1; i++){
            dividedCoefficients[i] = dividedCoefficients[i - 1] * xi + coefficients[i];
        }

        return dividedCoefficients;
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
    public static double[] PolyRoots(double[] coefficients) {

        double[] roots = new double[coefficients.Length];
        int i = 0;
        double tmp;
        try { 
        do{
            tmp = PolyRoot(coefficients);
            if (tmp == double.NaN) return new double[0];

            // TODO replace coefficients with PolyDiv result

            roots[i] = tmp;
            Console.WriteLine($"PolyRoot result: {roots[i]}");
            PolyDiv(coefficients, roots[i]);
            i++;
        }while (coefficients.Length > 1);
        } catch (Exception e){
            Console.WriteLine($"Exception caught: {e}");
        }

        /*
        double[] divResult = PolyDiv(coefficients, root);
        for (int i = 0; i < divResult.Length; i++){
            Console.Write($"{divResult[i]}x^{divResult.Length - (i + 1)} ");
        }
        */

        return roots;
    }

    public static void Main(string[] args){
        List<double> nums = new List<double>();
        string source;

        // loop to input polynomial coefficients
        do {
            double number;

            // print formated coefficients
            Console.Clear();
            Console.Write("Coefficients so far: ");
            Console.Write("[ ");
            foreach (double i in nums){
                Console.Write($"{i}, ");
            }
            Console.Write("]\n");

            Console.WriteLine("Please enter up to 10 positive or negative coefficients: \nEnter 'Q' or 'q' to stop entry");
            source = Console.ReadLine();

            if (!double.TryParse(source, out number)) continue;
            nums.Add(number);
        } while (source.ToLower() != "q" && nums.Count < 10);

        // polynomial display
        Console.WriteLine("Polynomial: ");
        for (int i = 0; i < nums.ToArray().Length; i++){
            Console.Write($"{nums.ToArray()[i]}x^{nums.ToArray().Length - (i + 1)} ");
        }
        Console.WriteLine();


        foreach (double i in PolyRoots(nums.ToArray())){
            Console.WriteLine($"ROOTS: {i}");
        }
        
        // HOLD THE LINE (terminal window) !!!
        Console.ReadLine();
    }
}