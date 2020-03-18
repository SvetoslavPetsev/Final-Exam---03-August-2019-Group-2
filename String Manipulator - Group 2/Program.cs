using System;

namespace String_Manipulator_Group_2
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Done")
                {
                    break;
                }
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                if (cmd == "Change")
                {
                    char oldSymbol = char.Parse(cmdArgs[1]);
                    char newSymbol = char.Parse(cmdArgs[2]);
                    if (text.Contains(oldSymbol))
                    {
                        text = text.Replace(oldSymbol, newSymbol);
                        Console.WriteLine(text);
                    }
                }
                else if (cmd == "Includes")
                {
                    string substr = cmdArgs[1];
                    Console.WriteLine(text.Contains(substr));
                }
                else if (cmd == "End")
                {
                    string substr = cmdArgs[1];
                    bool endsWith = false;
                    if (text.Length >= substr.Length)
                    {
                        string endSubstr = text.Substring(text.Length - substr.Length);
                        if (endSubstr == substr)
                        {
                            endsWith = true;
                        }
                    }
                    Console.WriteLine(endsWith);
                }
                else if (cmd == "Uppercase")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (cmd == "FindIndex")
                {
                    char symbol = char.Parse(cmdArgs[1]);
                    if (text.Contains(symbol))
                    {
                        int index = text.IndexOf(symbol);
                        Console.WriteLine(index);
                    }
                }
                else if (cmd == "Cut")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int length = int.Parse(cmdArgs[2]);
                    if (startIndex >= 0 && startIndex + length <= text.Length)
                    {
                        text = text.Substring(startIndex, length);
                    }
                    Console.WriteLine(text);
                }
            }
        }
    }
}
