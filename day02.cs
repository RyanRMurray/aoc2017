using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace aoc2017
{
    class Day02
    {
        public static void Run(string[] input){
            List<List<int>> numbers = new List<List<int>>();
            List<int> buffer = new List<int>();


            for(int i = 0; i < input.Length; i++){
                Match ns = Regex.Match(input[i], @"\d+");
                while(ns.Success){
                    buffer.Add(int.Parse(ns.Value));

                    ns = ns.NextMatch();
                }

                buffer.Sort((a, b) => b.CompareTo(a));

                numbers.Add(buffer);
                buffer = new List<int>();
            }

            Console.WriteLine("Part 1: " + part01(numbers));     
            Console.WriteLine("Part 2: " + part02(numbers));        
        }

        //sum of the difference between the max and min of each line
        static int part01(List<List<int>> numbers){
            int sum = 0;
            
            foreach(List<int> ns in numbers){
                sum += ns[0] - ns[^1];
            }

            return sum;
        }

        //sum of evenly divisible values in each line
        //for each value in a list, check if it divides with all lesser values
        static int part02(List<List<int>> numbers){
            int sum = 0;
            bool found = false;

            foreach(List<int> ns in numbers){

                found = false;

                for(int i = 0; i < ns.Capacity; i ++){
                    if(found) break;

                    for(int j = i + 1; j < ns.Capacity; j++){
                        if(found) break;

                        if(ns[i] % ns[j] == 0){
                            sum += ns[i] / ns[j];
                            found = true; 
                        } 
                    }
                }
            }
            
            return sum;
        }
    }
}