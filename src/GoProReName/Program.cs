using CommandLine;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GoProReName
{
    class Program
    {
        static readonly Regex SingleVideoRegex = new Regex(@"GOPR([0-9]{4})\.MP4", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static readonly Regex ChapteredVideoRegex = new Regex(@"GP([0-9]{2})([0-9]{4})\.MP4", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        static readonly string FilenameFormat = "{0}{1}.mp4";

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed<CommandLineOptions>(o =>
                {
                    RenameAllFiles(string.IsNullOrWhiteSpace(o.Directory) ?
                        Environment.CurrentDirectory :
                        o.Directory, o.Recursive);
                });
        }

        static void RenameAllFiles(string directory, bool recursive)
        {
            var filePaths = Directory.GetFiles(directory);
            foreach (var filePath in filePaths)
            {
                RenameFile(filePath);
            }

            if (recursive)
            {
                var directories = Directory.GetDirectories(directory);
                foreach (var d in directories)
                {
                    RenameAllFiles(d, true);
                }
            }
        }

        static void RenameFile(string path)
        {
            var filename = Path.GetFileName(path);
            var directory = Path.GetDirectoryName(path);
            var newFilename = GetNewFilename(filename);

            if (newFilename != filename)
            {
                var newPath = Path.Combine(directory, newFilename);
                Console.WriteLine(path + " -> " + newPath);
                try
                {
                    File.Move(path, newPath, false);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static string GetNewFilename(string filename)
        {
            if (SingleVideoRegex.IsMatch(filename))
            {
                var parts = SingleVideoRegex.Split(filename);
                var sequence = int.Parse(parts[1]);
                var chapter = 1;
                return string.Format(FilenameFormat, sequence, chapter);
            }
            else if (ChapteredVideoRegex.IsMatch(filename))
            {
                var parts = ChapteredVideoRegex.Split(filename);
                var sequence = int.Parse(parts[2]);
                var chapter = int.Parse(parts[1]) + 1;
                return string.Format(FilenameFormat, sequence, chapter);
            }
            else
            {
                return filename;
            }
        }
    }
}
