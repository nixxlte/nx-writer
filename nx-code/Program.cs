using System;
using System.Linq;

internal class Program {
    // Code by imNyan.T64 -w-

    public static string option; 
    public static string Prefix;
    public static string SPrefix;
    public static bool IsCommand(string input, string full, string shortCmd) {
        return input.Equals(Prefix + full, StringComparison.OrdinalIgnoreCase) ||
               input.Equals(SPrefix + shortCmd, StringComparison.OrdinalIgnoreCase);
    }

    public static void Help() {
        Console.WriteLine("NX utility help:");
    }
    
    public static void Main(string[] args)
    {
        var startup = Environment.GetCommandLineArgs();
        if (startup.Length > 1) {
            Init(startup);
        } else {
            Init(new string[] { "" });
        }
    }
    
    public static void Init(string[] argument) {
        var cmd = argument.FirstOrDefault() ?? "";
        if (argument[0] == string.Empty) {
            Console.WriteLine("Hello, World!");
        } else if (IsCommand(cmd, "help", "h")) {
            Help();
        }
    }
}