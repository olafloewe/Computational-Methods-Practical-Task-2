using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class CM_24_25_PT02{
    public static double PolyValue(double[] coefficients, double x){
        double power = 0;
        double result = 0.0;

        for (int i = 0; i < coefficients.Length; i++){
            power = (power == 0) ? 1 : power * x;
            result += coefficients[coefficients.Length-1-i] * power;
        }
        return result;
    }

    public static double[] PolyDerivative(double[] coefficients){
        double[] derivateCoefficients = new double[coefficients.Length - 1];

        for (int i = 0; i < derivateCoefficients.Length; i++) {
            derivateCoefficients[derivateCoefficients.Length - (i+1)] = coefficients[derivateCoefficients.Length - (i+1)] * (i + 1);
        }

        return derivateCoefficients;
    }

    public static double PolyRoot(double[] coefficients){
        double[] derivative = PolyDerivative(coefficients);
        double x0 = 5.0;
        double x1 = 0.0;
        double tollerance = 0.0000001;

        while (PolyValue(derivative, x0) == 0.0) x0 += 1.0;

        // newton method to check for root
        for (int i = 0; i < 1000; i++){
            x1 = (x0 - ( (PolyValue(coefficients, x0)) / (PolyValue(derivative, x0)) ));
            if (Math.Abs(x0 - x1) <= tollerance) return x1; // guard clause found root
            x0 = x1; // iteration step
        }

        return double.PositiveInfinity;
    }

    public static double[] PolyDiv(double[] coefficients, double xi){
        double[] dividedCoefficients = new double[coefficients.Length-1];

        // hornerschema
        dividedCoefficients[0] = coefficients[0];
        for (int i = 1; i < coefficients.Length - 1; i++){
            dividedCoefficients[i] = dividedCoefficients[i - 1] * xi + coefficients[i];
        }

        return dividedCoefficients;
    }

    public static double[] PolyRoots(double[] coefficients) {
        List<double> roots = new List<double>();
        double root;

        do {
            // POLYNOMIAL DISPLAY
            Console.Write("Polynomial:\t");
            for (int i = 0; i < coefficients.Length; i++){
                if (coefficients[i] == 0.0) continue;
                string sign = (coefficients[i] > 0) ? "+" : "";
                Console.Write($"{sign}{coefficients[i]}x^{coefficients.Length - (i + 1)} ");
            }
            Console.WriteLine();

            // ROOT CALCULATION
            root = PolyRoot(coefficients);
            if (root == double.PositiveInfinity) return roots.ToArray();
            roots.Add(root);
            Console.WriteLine($"PolyRoot result: {root}\n");

            // POLYNOMIAL DIVISION
            double[] divResult = PolyDiv(coefficients, root);
            coefficients = divResult;

        } while (coefficients.Length > 1);

        return roots.ToArray();
    }

    public static void Main(string[] args){
        List<double> nums = new List<double>();
        string source;
        double number;

        // loop to input polynomial coefficients
        do {
            // DISPLAY CURRENT INPUT
            Console.Clear();
            Console.Write("Coefficients so far: [ ");
            foreach (double i in nums){
                Console.Write($"{i}, ");
            }
            Console.Write("]\n");

            Console.WriteLine("Please enter up to 11 positive or negative coefficients: \nEnter 'Q' or 'q' to stop entry");
            source = Console.ReadLine();

            // guard clause for input read
            if (!double.TryParse(source, out number)) continue;
            nums.Add(number);
        } while (source.ToLower() != "q" && nums.Count <= 10);

        foreach (double i in PolyRoots(nums.ToArray())){
            Console.WriteLine($"Roots: {i}");
        }
        // HOLD THE LINE (terminal window) !!!
        Console.ReadLine();
    }
}