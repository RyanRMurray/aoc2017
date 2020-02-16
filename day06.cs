using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace aoc2017
{
    class Day06
    {
        public static void Run(string[] input){
            int[] banks = new int[16];
            Match ns = Regex.Match(input[0], @"\d+");

            for(int i = 0; i < 16; i++){
                banks[i] = int.Parse(ns.Value);
                ns = ns.NextMatch();
            }

            Console.WriteLine("Part 1: " + part01(banks));
            Console.WriteLine("Part 2: " + part02(banks));

        }

        static void balance(int[] banks){
            int ptr = 0, distribute = 0;

            for(int i = 1; i < 16; i++){
                if(banks[i] > banks[ptr])
                    ptr = i;
            }

            distribute = banks[ptr];
            banks[ptr] = 0;

            for(int i = 0; i < distribute; i++){
                ptr++;
                banks[ptr % 16]++;
            }
        }

        //find first instance of a repeated confirguration
        static int part01(int[] banks){
            List<int[]> seen = new List<int[]>();
            bool found = false;
            int steps = -1;

            while(!found){
                steps++;
                int[] inst = new int[16];

                banks.CopyTo(inst,0);

                foreach(int[] b in seen){
                    if(inst.SequenceEqual(b))
                        found = true;
                }

                seen.Add(inst);
                balance(banks);
            }

            return steps;
        }

        //find next instance of the repeated configuration
        static int part02(int[] banks){
            int[] first = new int[16];
            int steps = 1;
            
            banks.CopyTo(first,0);

            balance(banks);

            while(!banks.SequenceEqual(first)){
                steps++;
                balance(banks);
            }

            return steps;
        }
    }
}