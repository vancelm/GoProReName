using CommandLine;
using System;
using System.IO;

namespace GoProReName
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(o =>
                {
                    ProcessFiles(string.IsNullOrWhiteSpace(o.Directory) ?
                        Environment.CurrentDirectory :
                        o.Directory, o.Recursive);
                });
        }

        static void ProcessFiles(string directory, bool recursive)
        {
            var files = Directory.GetFiles(directory);
            foreach (var f in files)
            {
                RenameFile(f);
            }

            if (recursive)
            {
                var directories = Directory.GetDirectories(directory);
                foreach (var d in directories)
                {
                    ProcessFiles(d, true);
                }
            }
        }

        static void RenameFile(string file)
        {
            Console.WriteLine(file);
        }
    }
}
