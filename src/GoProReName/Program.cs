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
        //static readonly Regex SinglePhotoRegex = new Regex(@"GOPR([0-9]{4})\.jpg", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        //static readonly Regex BurstPhotoRegex = new Regex(@"G([0-9]{3})([0-9]{4})\.jpg", RegexOptions.IgnoreCase & RegexOptions.Compiled);

        static readonly string SingleVideoFormat = "GH01{0}.MP4";
        static readonly string ChapteredVideoFormat = "GH{0}{1}.MP4";
        //static readonly string SinglePhotoFormat = "";

        static void Main(string[] args)
        {
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
                    ProcessFiles(d, true);
                }
            }
        }

        static void RenameFile(string path)
        {
            var filename = Path.GetFileName(path);
            var directory = Path.GetDirectoryName(path);

            string[] parts;
            if (SingleVideoRegex.IsMatch(filename))
            {
                parts = SingleVideoRegex.Split(filename);
                Console.WriteLine(path + " -> " + string.Format(SingleVideoFormat, parts[1]));
            }
            else if (ChapteredVideoRegex.IsMatch(filename))
            {
                parts = ChapteredVideoRegex.Split(filename);
                Console.WriteLine(path + " -> " + string.Format(ChapteredVideoFormat, parts[1], parts[2]));
            }
        }
    }
}
