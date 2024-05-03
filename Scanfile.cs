using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: ScanFile.exe <tmfs_path> <region> <filename>");
            return;
        }

        // Path to the Trend Micro AmaaS CLI (tmfs)
        string tmfsPath = args[0];

        // Region for the command
        string region = args[1];

        // Filename to scan (provide the filename)
        string filename = args[2];

        // Construct the command
        string command = $"scan --region {region} file:{filename}";

        // Create process start info
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = tmfsPath;
        startInfo.Arguments = command;

        // Redirect standard output
        startInfo.RedirectStandardOutput = true;

        // Redirect standard error
        startInfo.RedirectStandardError = true;

        // Do not create a window
        startInfo.CreateNoWindow = true;

        // Enable shell execute
        startInfo.UseShellExecute = false;

        // Create the process
        Process process = new Process();
        process.StartInfo = startInfo;

        // Start the process
        process.Start();

        // Read the output (if any)
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        // Wait for the process to exit
        process.WaitForExit();

        // Output the results
        Console.WriteLine("Output:");
        Console.WriteLine(output);

        Console.WriteLine("Error:");
        Console.WriteLine(error);
    }
}
