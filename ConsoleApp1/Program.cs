using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    internal class Program {
        static void Main(string[] args) {
            int[] nums = { 15, 11, 5, 12, 321, 98, 4, 7, 2 };
            foreach (int arg in TwoSum(nums, 19)) {
                Console.WriteLine(arg);
            }
        }


        public static int[] TwoSum(int[] nums, int target) {

            int j = nums.Length - 1;

            for (int i = 0; i != nums.Length; i++){
        
                Console.WriteLine($"i: {i}, j: {j}");

                if (i != j && nums[i] + nums[j] == target) return new int[] { i, j };

                if (nums[i] < nums[j] || nums[j] >= target) {
                    j--;
                    i--;
                    continue;
                }
                if (nums[i] + nums[j] > target) continue;



            }

            return new int[] { -1, -1};
        }

    }
}
