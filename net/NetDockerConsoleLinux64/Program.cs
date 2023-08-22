using System.Runtime.InteropServices;

namespace NetDockerConsoleLinux64
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("NetDockerConsoleLinux64");

            // OSDescription
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && File.Exists("/etc/os-release"))
            {
                foreach (string line in File.ReadAllLines("/etc/os-release"))
                {
                    if (line.StartsWith("PRETTY_NAME"))
                    {
                        Console.WriteLine($"{nameof(RuntimeInformation.OSDescription)}: {line.AsSpan()[("PRETTY_NAME".Length + 2)..^1].ToString()}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{nameof(RuntimeInformation.OSDescription)}: {RuntimeInformation.OSDescription}");
            }

            // OSArchitecture
            Console.WriteLine($"{nameof(RuntimeInformation.OSArchitecture)}: {RuntimeInformation.OSArchitecture}");

            // ProcessArchitecture
            Console.WriteLine($"{nameof(RuntimeInformation.ProcessArchitecture)}: {RuntimeInformation.ProcessArchitecture}");

            // FrameworkDescription
            Console.WriteLine($"{nameof(RuntimeInformation.FrameworkDescription)}: {RuntimeInformation.FrameworkDescription}");

            var counter = 0;
            var max = args.Length is not 0 ? Convert.ToInt32(args[0]) : -1;
            while (max is -1 || counter < max)
            {
                Console.WriteLine($"Counter: {++counter}");
                await Task.Delay(1000);
            }
        }
    }
}