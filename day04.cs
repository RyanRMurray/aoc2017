using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace aoc2017
{
    class Day04
    {
        public static void Run(string[] input){
            List<List<string>> phrases = new List<List<string>>();

            foreach(string i in input){
                List<string> buffer = new List<string>();
                Match ns = Regex.Match(i, @"[a-z]+");

                while(ns.Success){
                    buffer.Add(ns.Value);

                    ns = ns.NextMatch();
                }
                phrases.Add(buffer);
            }

            Console.WriteLine("Part 1: " + part01(phrases));
            Console.WriteLine("Part 2: " + part02(phrases));

        }

        static int part01(List<List<string>> phrases){
            int sum = 0;


            foreach(List<string> phrase in phrases){
                HashSet<string> parsed = new HashSet<string>();
                int count = 0;

                foreach(string s in phrase){
                    parsed.Add(s);
                    count++;
                }
                
                if(parsed.Count == count)
                    sum++;
            }

            return sum;
        }

        static string alphabetize(string x){
            char[] buffer = x.ToCharArray();
            Array.Sort(buffer);

            return new string(buffer);
        }

        static int part02(List<List<string>> phrases){
            int sum = 0;


            foreach(List<string> phrase in phrases){
                HashSet<string> parsed = new HashSet<string>();
                int count = 0;

                foreach(string s in phrase){
                    parsed.Add(alphabetize(s));
                    count++;
                }
                
                if(parsed.Count == count)
                    sum++;
            }

            return sum;
        }

    }
}