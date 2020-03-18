using System;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main()
        {
            Regex pattern = new Regex(@"([\*\@])(?<tag>[A-Z][a-z]{2,})\1\:\s\[(?<first>[A-Za-z])\]\|\[(?<second>[A-Za-z])\]\|\[(?<thurd>[A-Za-z])\]\|$");
            int imputNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < imputNum; i++)
            {
                string input = Console.ReadLine();
                Match machedInput = pattern.Match(input);

                if (machedInput.Success)
                {
                    string tag = machedInput.Groups["tag"].Value;
                    int first = char.Parse(machedInput.Groups["first"].Value);
                    int second = char.Parse(machedInput.Groups["second"].Value);
                    int thurd = char.Parse(machedInput.Groups["thurd"].Value);

                    Console.WriteLine($"{tag}: {first} {second} {thurd} ");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
