using CommandLine;
using System;
using System.IO;

namespace GoProReName
{
    class Program
    {
        class Options
        {
            [Option(
                'r',
                "recursive",
                Required = false,
                Default = false,
                HelpText = "Recursively renames all files in the current directory and all subdirectories.")]
            public bool Recursive { get; set; }

            [Value(
                0,
                MetaName = "path",
                Required = false,
                HelpText = "Optional directory containing files to rename.")]
            public string Directory { get; set; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
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
