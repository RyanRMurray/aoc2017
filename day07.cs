using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace aoc2017
{
    class Day07
    {
        struct D7Graph{
            public Dictionary<String, int> nodes;
            public string[][] conns;

            public D7Graph(string[] input){
                this.nodes = new Dictionary<string, int>();
                List<string[]> c_buffer = new List<string[]>();

                foreach(string i in input){
                    string[] nc = i.Split("->");

                    string n_name = Regex.Match(nc[0], @"[a-z]+").Value;
                    int n_weight = int.Parse(Regex.Match(nc[0], @"\d+").Value);

                    this.nodes.Add(n_name, n_weight);

                    //add paths
                    if(nc.Length > 1){
                        string[] cs = nc[1].Split(new[] {',',' '}, StringSplitOptions.RemoveEmptyEntries);

                        foreach(string c in cs){
                            c_buffer.Add(new[] {n_name, c});
                        }
                    }
                }

                conns = c_buffer.ToArray();
            }

            public string[] children(string root){
                List<string> cs = new List<string>();

                foreach(string[] c in conns){
                    if(string.Equals(root, c[0]))
                        cs.Add(c[1]);
                }

                return cs.ToArray();
            }

            public int reachable(string root){
                int total = 1;                

                foreach(string c in children(root))
                    total += this.reachable(c);
                
                return total;
            }

            public int weight(string root){
                int weight = this.nodes[root];
                
                foreach(string c in children(root))
                    weight += this.weight(c);

                return weight;
            }
        }


        public static void Run(string[] input){
            D7Graph g = new D7Graph(input);
            string root = part01(g);

            Console.WriteLine("Part 1: " + root);

            Console.WriteLine(get_unbalanced(g, g.children("ugml")));
        }

        static string part01(D7Graph g){
            
            foreach(string n in g.nodes.Keys){
                if(g.reachable(n) == g.nodes.Count)
                    return n;
            }

            return "??";
        }
        static bool children_unbalanced(D7Graph g, string root){
            HashSet<int> ws = new HashSet<int>();
            
            foreach(string c in g.children(root)){
                ws.Add(g.weight(c));
            }

            return (ws.Count > 1);
        }

        static string get_unbalanced(D7Graph g, string[] cs){
            var q = cs.GroupBy(
                str => g.weight(str),
                str => str,
                (w, n) => new
                { 
                    Key = w,
                    Count = n.Count(),
                    Res = n.Min()
                });

            foreach(var res in q){
                if(res.Count == 1)
                    return res.Res;
            }

            return null;
        }

        static int part02(D7Graph g, string root){
            bool found = false;
            
            while(!found){
                string[] targets = g.children(root);

                string unbalanced = get_unbalanced(g, targets);

                if(unbalanced == null){
                    found = true;
                }else{
                    root = unbalanced;
                }
            }

        }


    }
}