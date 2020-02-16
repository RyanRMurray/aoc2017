using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace aoc2017
{
    class Day05
    {
        public static void Run(string[] input){
            int[] nums1 = new int[input.Length];
            int[] nums2 = new int[input.Length];

            for(int i = 0; i < input.Length; i++){
                nums1[i] = int.Parse(input[i]);
                nums2[i] = nums1[i];
            }

            Console.WriteLine("Part 1: " + part01(nums1));
            Console.WriteLine("Part 2: " + part02(nums2));
        }

        static int part01(int[] nums){
            int counter = 0, ptr = 0;

            while(ptr > -1 && ptr < nums.Length){
                counter++;
                ptr += nums[ptr]++;
            }

            return counter;
        }
        static int part02(int[] nums){
            int counter = 0, ptr = 0;

            while(ptr > -1 && ptr < nums.Length){
                counter++;
                if(nums[ptr] >= 3){
                    ptr += nums[ptr]--;
                }else{
                    ptr += nums[ptr]++;
                }
            }

            return counter;
        }
    }
}
