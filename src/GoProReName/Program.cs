﻿using CommandLine;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace GoProReName
{
    class Program
    {
        static readonly Regex SingleVideoRegex = new Regex(@"GOPR([0-9]{4})\.mp4", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        static readonly Regex ChapteredVideoRegex = new Regex(@"GP([0-9]{2})([0-9]{4})\.mp4", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        static readonly Regex SinglePhotoRegex = new Regex(@"GOPR([0-9]{4})\.jpg", RegexOptions.IgnoreCase & RegexOptions.Compiled);
        static readonly Regex BurstPhotoRegex = new Regex(@"G([0-9]{3})([0-9]{4})\.jpg", RegexOptions.IgnoreCase & RegexOptions.Compiled);

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
