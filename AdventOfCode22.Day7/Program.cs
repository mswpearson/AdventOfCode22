using AdventOfCode22.Day7;

string inputText = File.ReadAllText("puzzleInput.txt");
var directoryChanges = inputText.Split("$ cd ").Where(dc => !string.IsNullOrWhiteSpace(dc.Trim())).Select(dc => dc.Trim());

string currentDirectory = "";
List<ElfDirectory> allDirectories = new List<ElfDirectory>();

foreach (var directoryChange in directoryChanges)
{
    var directory = new ElfDirectory();
    if (!directoryChange.StartsWith(".."))
    {
        var splitDirectoryChange = directoryChange.Split("$ ls");

        var directoryName = splitDirectoryChange[0].Trim();
        if (string.IsNullOrWhiteSpace(currentDirectory) && directoryName == "/")
        {
            currentDirectory = "/";
        }
        else if (currentDirectory.EndsWith("/"))
        {
            currentDirectory += directoryName;
        }
        else
        {
            currentDirectory += $"/{directoryName}";
        }
        directory.Path = currentDirectory;

        var insideDirectory = splitDirectoryChange[1].Split("\r\n").Where(x => !string.IsNullOrWhiteSpace(x.Trim()));
        foreach (var fileOrDir in insideDirectory)
        {
            if (fileOrDir.StartsWith("dir"))
            {
                if (currentDirectory.EndsWith("/"))
                {
                    directory.SubDirectories.Add(currentDirectory + fileOrDir.Split(" ")[1]);
                }
                else
                {
                    directory.SubDirectories.Add(currentDirectory + "/" + fileOrDir.Split(" ")[1]);
                }
            }
            else
            {
                directory.FileSizes.Add(int.Parse(fileOrDir.Split(" ")[0]));
            }
        }
        allDirectories.Add(directory);
    }
    else
    {
        var lastSlashIndex = currentDirectory.LastIndexOf('/');
        currentDirectory = currentDirectory.Substring(0, lastSlashIndex);
    }
}

int GetSizeOfDirectory(string fullDirectoryPath)
{
    var directory = allDirectories.Single(dir => dir.Path == fullDirectoryPath);

    return directory.FileSizes.Sum() + directory.SubDirectories.Sum(sd => GetSizeOfDirectory(sd));
}

var allDirectorySizes = allDirectories.Select(dir => GetSizeOfDirectory(dir.Path));

Console.WriteLine(allDirectorySizes.Where(dSize => dSize <= 100_000).Sum());