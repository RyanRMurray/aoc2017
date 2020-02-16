using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace aoc2017
{
    class Day03
    {
        public static void Run(string[] input){
            int address = int.Parse(input[0]);

            Console.WriteLine("Part 1: " + part01(address));
        }

        //sum of consecutive squares
        static int sos(int n){
            return (n * (n+1) * (2*n+1))/6;
        }

        //get the manhattan distance to the specified data address
        static int part01(int address){
            int tier = 1, ptr = 0, q_step = 0;

            while(Math.Pow(tier,2) < address)
                tier += 2;

            ptr = (int) Math.Pow(tier,2);

            q_step = (int) (ptr - Math.Pow(tier-2,2)) / 4;

            for(int i = 0; i < 4; i++){
                if(ptr > address)
                    ptr -= q_step;
            }

            return (tier - 1) - Math.Abs(address - ptr);
        }
    }
}