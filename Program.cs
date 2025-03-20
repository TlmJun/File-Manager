using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        FileManager manager  = new FileManager();
        var CurrentDirectorys = Directory.GetCurrentDirectory();

        Console.WriteLine("Файловый менеджер");

        manager.ListFiles();
        

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
            CurrentDirectory = Directory.GetCurrentDirectory();     ///System.ArgumentNullException GetDirectories(path) 
        }
        public void ListFiles()
        {
            try
            {
                Console.WriteLine("Файлы из " + CurrentDirectory);
                foreach (var file in Directory.GetFiles(CurrentDirectory)) 
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
                Console.WriteLine("папки из");
                foreach (var files in Directory.GetDirectories(CurrentDirectory)) 
                {
                    Console.WriteLine(Path.GetFileName(files));
                }

            }
            catch(System.ArgumentNullException)
            {
                Console.WriteLine("Ошибка");
            }
        }
        public void ChangeDirectory(string newDirectory)//System.ArgumentNullException
        {
            try
            {
                string path = Path.Combine(CurrentDirectory, newDirectory);
                if (Directory.Exists(path))
                {
                    CurrentDirectory = path;
                    Console.WriteLine("Выберите директорию" + CurrentDirectory);
                }
                else
                {
                    Console.WriteLine("Директория не найдена" + newDirectory);
                }
            }
            catch(System.ArgumentNullException)
            {
                Console.WriteLine("Ошибка");
            }
        }
    } 
}
