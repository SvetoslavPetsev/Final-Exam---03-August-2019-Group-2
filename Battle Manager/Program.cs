using System;
using System.Linq;
using System.Collections.Generic;

namespace Battle_Manager
{
    public class Status
    {
        public int Health { get; set; }
        public int Energy { get; set; }

        public Status(int health, int energy)
        {
            this.Health = health;
            this.Energy = energy;
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Status> people = new Dictionary<string, Status>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Results")
                {
                    break;
                }
                string[] cmdArgs = input.Split(":");
                string cmd = cmdArgs[0];
                if (cmd == "Add")
                {
                    string name = cmdArgs[1];
                    int health = int.Parse(cmdArgs[2]);
                    int energy = int.Parse(cmdArgs[3]);
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, new Status(health, energy));
                    }
                    else
                    {
                        people[name].Health += health;
                    }
                }
                else if (cmd == "Attack")
                {
                    string attacker = cmdArgs[1];
                    string defender = cmdArgs[2];
                    int damage = int.Parse(cmdArgs[3]);
                    if (people.ContainsKey(attacker) && people.ContainsKey(defender))
                    {
                        people[defender].Health -= damage;
                        if (people[defender].Health <= 0)
                        {
                            RemovePlayer(people, defender);
                        }

                        people[attacker].Energy--;
                        if (people[attacker].Energy <= 0)
                        {
                            RemovePlayer(people, attacker);
                        }
                    }
                }
                else if (cmd == "Delete")
                {
                    string name = cmdArgs[1];
                    if (name == "All")
                    {
                        people = new Dictionary<string, Status>();
                    }
                    else if (people.ContainsKey(name))
                    {
                        people.Remove(name);
                    }
                }
            }

            Console.WriteLine($"People count: {people.Count}");
            foreach (var player in people.OrderByDescending(x => x.Value.Health).ThenBy( x => x.Key))
            {
                Console.WriteLine($"{player.Key} - {player.Value.Health} - {player.Value.Energy}");
            }
        }

        private static void RemovePlayer(Dictionary<string, Status> people, string name)
        {
            people.Remove(name);
            Console.WriteLine($"{name} was disqualified!");
        }
    }
}
