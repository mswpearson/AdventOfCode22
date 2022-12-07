namespace AdventOfCode22.Day7
{
    public class ElfDirectory
    {
        public string Path { get; set; } = string.Empty;
        public List<int> FileSizes { get; set; } = new List<int>();
        public List<string> SubDirectories { get; set; } = new List<string>();
    }
}
