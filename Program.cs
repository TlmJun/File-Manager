using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileManager manager  = new FileManager();
        manager.ListFiles();
        manager.ListFiles();
        manager.ChangeDirectory("folder1");
        manager.ListFiles();

        Console.WriteLine("Файловый менеджер");
        Console.WriteLine("Выберите действие");
        Console.WriteLine("1 - копировать");
        Console.WriteLine("2 - удалить");
        Console.WriteLine("3 - свойства");
        Console.WriteLine("4 - выйти");

        string Num = Console.ReadLine()!;
        switch (Num)
        {
            case "1":
            case "2":
            case "3":
            case "4":
                break;
            default:
                {
                    Console.WriteLine("Ошибка");
                    break;
                }
        }
    }

    class FileManager
    {
        public string CurrentDirectory;
        public FileManager()
        {
            CurrentDirectory = new Directory.GetCurrentDirectory();
        }
        public void ListFiles()
        {
            Console.WriteLine("Contents of" + CurrentDirectory);
            foreach (var file in Directory.GetFiles(CurrentDirectory))
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            Console.WriteLine("Contents of" + CurrentDirectory);
            foreach (var dir in Directory.GetFiles(CurrentDirectory))
            {
                Console.WriteLine(Path.GetFileName(dir));
            }
        }
        public void ChangeDirectory(string newDirectory)
        {
            string path = Path.Combine(CurrentDirectory, newDirectory);
            if (Directory.Exists(path))
            {
                CurrentDirectory = path;
                Console.WriteLine("Changed directory to" + CurrentDirectory);
            }
            else
            {
                Console.WriteLine("Directory not found:" + newDirectory);
            }
        }
    } 
}
