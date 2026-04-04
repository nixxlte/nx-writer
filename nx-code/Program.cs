// @formatter:off
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Management;

internal class Program {
    // Code by imNyan.T64 -w-

    public static string os;

    public static string[] simpleDistros = { "ChromeOS-Flex", "xUbuntu", "Ubuntu" };
    public static string[] advancedDistros = { "Brunch-Framework", "Arch", "Debian" };

    public static string image;
    public static string device;

    public static string option;
    public static string method;
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
            Console.Write("Selected: " + option + "\n Is that right? (yes/no)> ");
            option = Console.ReadLine();
            if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {
                Drive();
            } else if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("Okay. Restarting proces...");
                Write(selection);
            }
        } else if (option = advancedDistros[]) {
            if (selection == "simple") {
                Console.WriteLine("You selected a Advanced image, but youre on Simple mode.\n Please restart NX on Advanced mode, or select a Simple image.");
            } else if (selection == "advanced") {
                image = option;
                option = string.Empty;
                Console.Write("Selected: " + option + "\n Is that right? (yes/no)> ");
                option = Console.ReadLine();
                if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {
                    Drive();
                } else if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {
                    Console.WriteLine("Okay. Restarting proces...");
                    Write(selection);
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
    
    public static void Drive() {
        option = string.Empty;
        Console.Clear();
        Console.WriteLine("Please select the disk you want to create the image");
        if (os == "linux") { // if youre on linux
            var process = new Process();
            process.StartInfo.FileName = "lsblk";
            process.StartInfo.Arguments = "-d -o NAME,SIZE,MODEL,TRAN";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        } else if (os == "windows") { // if youre on windows
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject disk in searcher.Get()){
                Console.WriteLine($"{disk["Model"]} - {disk["Size"]}");
            }
        }
        Console.Write("> ");
        option = Console.ReadLine();
        if () { // Disk exists
            device = option;
            option = string.Empty;
        } else if () { // Disk doesnt exists
            Console.Write("\nThe device you have selected does not exist.\n Press any key to continue...");
            Console.ReadLine();
            Drive();
        }
    }

    public static void Simple(string on) {
        if (on == "argument"){
            method = "start";
        } else if (on == "activation") {
            method = "selector";
        }
        Write("simple");
    }

    public static void Complex(string on) {
        if (on == "argument"){
            method = "start";
        } else if (on == "activation") {
            method = "selector";
        }
        Write("advanced");
    }
    
    public static void Help() {
        Console.WriteLine("NX utility help:");
    }
    
    public static void System() {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            os = "windows";
        } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            os = "linux";
        }
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
        System();
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