using System;

namespace aoc2017
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 0;
            string[] input;

            if(args.Length != 2){
                Console.WriteLine("Usage: dotnet run [day number] [input filepath]");
                return;
            }
            
            try{
                day = int.Parse(args[0]);
            }catch{
                Console.WriteLine("Invalid argument for day number.");
                return;
            }

            try{
                input = System.IO.File.ReadAllLines(@args[1]);
            }catch{
                Console.WriteLine("Invalid filepath or file for input.");
                return;
            }

            switch(day){
                case 1: Day01.Run(input); break;
                case 2: Day02.Run(input); break;
                default:
                    Console.WriteLine("That day hasn't been added yet!");
                    break;
            }


        }
    }
}
