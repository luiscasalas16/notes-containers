using System.Reflection;
using System.Runtime.InteropServices;

namespace NetDockerConsoleLinux64
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("NetDockerConsoleLinux64");

            AssemblyInformationalVersionAttribute assemblyInformation = ((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0];
            string[] informationalVersionSplit = assemblyInformation.InformationalVersion.Split('+');

            Console.WriteLine("**.NET information");
            Console.WriteLine($"{nameof(Environment.Version)}: {Environment.Version}");
            Console.WriteLine($"{nameof(RuntimeInformation.FrameworkDescription)}: {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"Libraries version: {informationalVersionSplit[0]}");
            Console.WriteLine($"Libraries hash: {informationalVersionSplit[1]}");
            Console.WriteLine();
            Console.WriteLine("**Environment information");
            Console.WriteLine($"{nameof(Environment.ProcessorCount)}: {Environment.ProcessorCount}");
            Console.WriteLine($"{nameof(RuntimeInformation.ProcessArchitecture)}: {RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"{nameof(RuntimeInformation.OSArchitecture)}: {RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"{nameof(RuntimeInformation.OSDescription)}: {RuntimeInformation.OSDescription}");
            Console.WriteLine($"{nameof(Environment.OSVersion)}: {Environment.OSVersion}");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                Console.WriteLine("OSPlatform: Windows");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Console.WriteLine("OSPlatform: Linux");
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                Console.WriteLine("OSPlatform: MacOS");

            Console.WriteLine($"{nameof(Environment.UserName)}: {Environment.UserName}");
            Console.WriteLine($"{nameof(Environment.MachineName)}: {Environment.MachineName}");
            Console.WriteLine($"{nameof(Environment.Is64BitOperatingSystem)}: {Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"{nameof(Environment.Is64BitProcess)}: {Environment.Is64BitProcess}");

            // Linux Pretty Name
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && File.Exists("/etc/os-release"))
            {
                foreach (string line in File.ReadAllLines("/etc/os-release"))
                {
                    if (line.StartsWith("PRETTY_NAME"))
                    {
                        Console.WriteLine($"Linux Pretty Name: {line.AsSpan()[("PRETTY_NAME".Length + 2)..^1].ToString()}");
                        break;
                    }
                }
            }

            Console.WriteLine();

            var counter = 0;
            var max = args.Length is not 0 ? Convert.ToInt32(args[0]) : -1;
            while (max is -1 || counter < max)
            {
                Console.WriteLine($"Counter: {++counter}");
                await Task.Delay(2500);
            }
        }
    }
}