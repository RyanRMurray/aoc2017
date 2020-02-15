using System;

namespace aoc2017
{
    class Day01
    {

        public static void Run(string[] input){
            int[] numbers = new int[input[0].Length];
            int i = 0;

            foreach(char c in input[0].ToCharArray()){
                numbers[i] = int.Parse(c.ToString());
                i++;
            }

            Console.WriteLine("Part 1: " + part1(numbers));
            Console.WriteLine("Part 2: " + part2(numbers));
        }

        //sum of all integers that match their successor
        static int part1(int[] numbers){
            int last_int = numbers[^1];
            int sum = 0;

            foreach(int n in numbers){
                if(last_int == n)
                    sum += n;

                last_int = n;
            }

            return sum;
        }

        static int part2(int[] numbers){
            int l = numbers.Length;
            int offset = l / 2;
            int sum = 0;

            for(int i = 0; i < numbers.Length; i++){
                if(numbers[i] == numbers[(i + offset) % l])
                    sum += numbers[i];
            }

            return sum;

        }

    }
}