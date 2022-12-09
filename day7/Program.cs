using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Schema;

namespace AdventOfCode
{

    public enum FileSystemType
    {
        File,
        Directory
    }
    public class FileSystem
    {
        public FileSystem Parent;
        public List<FileSystem> Children = new List<FileSystem>();
        public FileSystemType FileOrDir;
        public String Name;
        public int Size;

        public FileSystem()
        {
            Parent = this;
            Name = "root";
            FileOrDir = FileSystemType.Directory;

        }

        public FileSystem(FileSystem parent, string name, FileSystemType type, int size)
        {
            Parent = parent;
            Name = name;
            FileOrDir = type;
            Size = size;
        }

        public FileSystem AddChild(string childName, FileSystemType fileOrDir, int size = 0)
        {
            FileSystem newChild = new FileSystem(this, childName, fileOrDir, size);
            Children.Add(newChild);
            return newChild;
        }

        public int GetSize()
        {
            if (FileOrDir == FileSystemType.File)
            {
                throw new Exception("You are not allowed to get size from a file");
            }
            int sum = 0;
            foreach (FileSystem fs in Children)
            {
                if (fs.FileOrDir == FileSystemType.Directory)
                {
                    sum += fs.GetSize();
                }
                else
                {
                    sum += fs.Size;
                }
            }
            return sum;
        }
    }

    public class Program
    {
        public static string[] readFromFile()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\axelc\source\repos\AdventOfCode\day7\input.txt");
        }

        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            FileSystem root = new FileSystem();
            FileSystem currentPath = root;
            List<FileSystem> folders = new List<FileSystem>();
            const int diskSize = 70_000_000;
            const int uppdateSize = 30_000_000;

            string[] input = readFromFile();
            foreach (string line in input)
            {
                string[] stringSplit = line.Split(' ');
                if (stringSplit[0] == "$")
                {
                    if (stringSplit[1] == "ls")
                    {

                    }
                    else if (stringSplit[1] == "cd")
                    {
                        if (stringSplit[2] == "/")
                        {

                            currentPath = root;
                        }
                        else if (stringSplit[2] == "..")
                        {
                            currentPath = currentPath.Parent;
                        }
                        else
                        {
                            currentPath = currentPath.Children.Find(c => c.Name == stringSplit[2]);
                        }
                    }
                }
                else
                {
                    if (stringSplit[0] == "dir")
                    {
                        folders.Add(currentPath.AddChild(stringSplit[1], FileSystemType.Directory));
                    }
                    else
                    {
                        currentPath.AddChild(stringSplit[1], FileSystemType.File, int.Parse(stringSplit[0]));
                    }
                }
            }
            int output = 0;
            foreach (FileSystem folder in folders)
            {
                if (folder.GetSize() <= 100000)
                {
                    output += folder.GetSize();
                }
            }
            int currentFreeStorage = diskSize - root.GetSize();
            int requiredToDelete = uppdateSize - currentFreeStorage;


            Console.WriteLine(folders.Where(f => f.GetSize() > requiredToDelete && f.FileOrDir == FileSystemType.Directory).Min(ff=> ff.GetSize()));

            Console.WriteLine($"The awnser of part 1 is {output}");

        }
    }
}
