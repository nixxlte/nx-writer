// @formatter:off
using System;
using System.Diagnostics;
using System.Linq;
using System.IO;

internal class Program {
    // Code by imNyan.T64 -w-

    public static string[] simpleDistros = { "ChromeOS-Flex", "xUbuntu", "Ubuntu" };
    public static string[] advancedDistros = { "Brunch-Framework", "Arch", "Debian" };

    public static string image;

    public static string option;
    public static string Prefix;
    public static string SPrefix;

    public static bool IsCommand(string input, string full, string shortCmd) {
        return input.Equals(Prefix + full, StringComparison.OrdinalIgnoreCase) ||
               input.Equals(SPrefix + shortCmd, StringComparison.OrdinalIgnoreCase);
    }

    public static void Write(string selection) {
        option = String.Empty;
        Console.WriteLine("Select a image:");
        if (selection == "simple") {
            foreach (var distro in simpleDistros) {
                Console.WriteLine(". " + distro);
            }
        } else if (selection == "advanced") {
            foreach (var distro in advancedDistros) {
                Console.WriteLine(". " + distro);
            }
        }
        Console.Write("> ");
        option = Console.ReadLine();

        if (option = simpleDistros[]) {
            image = option;
            option = string.Empty;
            Console.Write("Selected: " + option + "\n Is that right? (yes/no) ");
            option = Console.ReadLine();
            if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {

            } else if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {

            }
        } else if (option = advancedDistros[]) {
            if (selection == "simple") {
                Console.WriteLine("You selected a Advanced image, but youre on Simple mode.\n Please restart NX on Advanced mode, or select a Simple image.");
            } else if (selection == "advanced") {
                image = option;
                option = string.Empty;
                Console.Write("Selected: " + option + "\n Is that right? (yes/no) ");
                option = Console.ReadLine();
                if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {

                } else if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {

                }
            }
        }
    }

    public static void Show() {
        Console.Clear();
        Console.WriteLine("Avaiable distros:");
        Console.WriteLine("Simple mode");
        foreach (var distro in simpleDistros) {
            Console.WriteLine(". " + distro);
        }
        Console.WriteLine("\nAdvanced mode");
        foreach (var distro in advancedDistros) {
            Console.WriteLine(". " + distro);
        }
    }

    public static void Simple(string on) {
        if (on == "argument"){
        } else if (on == "activation") {
            Write("simple");
        }
    }
    
    public static void Drive() {

    }

    public static void Complex(string on) {
        if (on == "argument"){
        } else if (on == "activation") {
            Write("advanced");
        }
    }
    
    public static void Help() {
        Console.WriteLine("NX utility help:");
    }
    
    public static void Mode(int mode) {
        if (mode == 0) {
            Console.WriteLine("NX CLI simple mode");
            Simple("argument");
        } else if (mode == 1) {
            Console.WriteLine("NX CLI advanced mode");
            Complex("argument");
        }
    }
    
    public static void Main(string[] args) {
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
            Console.WriteLine("Hello, World!\n NX CLI default write mode");
            option = string.Empty;
            Console.WriteLine("Please select the write method:\n [1] Simple\n [2] Advanced");
            option = Console.ReadLine();
            if (option == "1" || option.Equals("simple", StringComparison.OrdinalIgnoreCase)) {

            }
        } else if (IsCommand(cmd, "help", "h")) {
            Help();
        } else if (IsCommand(cmd, "write", "w")) {
            if (argument.Length > 1 &&
                (argument[1].Equals(Prefix + "advanced") || argument[1].Equals(SPrefix + "a"))) {
                Mode(1);
            }
            if (argument.Length > 1 &&
                (argument[1].ToLower() != "advanced" || argument[1].ToLower() != "a")) { // if theres an argument after -w, but the arg isnt "--advanced" or "-a"
                Mode(0);
            }
            if (argument.Length < 1) { // if theres not an argument after -w
                option = string.Empty;
                Console.WriteLine("Please select the write method:\n [1] Simple\n [2] Advanced");
                option = Console.ReadLine();
                if (option == "1" || option.Equals("simple", StringComparison.OrdinalIgnoreCase)) {
                    simple("activation");
                } else if (option == "1" || option.Equals("advanced", StringComparison.OrdinalIgnoreCase)) {
                    Complex("activation");
                }
            }
        } else if (IsCommand(cmd, "list", "l")) {
            Show();
        }
    }
}