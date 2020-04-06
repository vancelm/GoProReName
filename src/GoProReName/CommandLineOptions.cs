using CommandLine;

namespace GoProReName
{
    public class CommandLineOptions
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
}
