using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        FileManager manager  = new FileManager();
        var CurrentDirectories = Directory.GetCurrentDirectory();

        Console.WriteLine("Файловый менеджер");

        while (true)
        {
            manager.ListFiles();
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1 - выбрать директорию");
            Console.WriteLine("2 - копировать");
            Console.WriteLine("3 - удалить");
            Console.WriteLine("4 - свойства");
            Console.WriteLine("5 - Задать свой путь");
            Console.WriteLine("6 - выйти");
            Console.WriteLine("");

            string Num = Console.ReadLine()!;
            switch (Num)
            {
                case "1":
                    manager.ChangeDirectory(CurrentDirectories);
                    break;
                case "2":
                    
                    break;
                case "3":
                    manager.Delete();
                    break;
                case "4":
                    manager.characteristics();
                    break;
                case "5":

                    break;
                case "6":
                    break;
                default:
                    {
                        Console.WriteLine("Выберите действие");
                        break;
                    }
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
                Console.WriteLine("<Файлы из " + CurrentDirectory);
                foreach (var file in Directory.GetFiles(CurrentDirectory)) 
                {
                    Console.WriteLine("     " + Path.GetFileName(file));
                }
                Console.WriteLine("папки");
                foreach (var files in Directory.GetDirectories(CurrentDirectory)) 
                {
                    Console.WriteLine("     " + Path.GetFileName(files));
                }

            }
            catch(System.ArgumentNullException)
            {
                Console.WriteLine("Ошибка");
            }
        }
        public void ChangeDirectory(string newDirectory)                        // Позволяет выбирать директорию в текущей директории
        {
            try
            {
                Console.WriteLine("Выберите директорию");
                var Choice = Console.ReadLine();
                Console.WriteLine("Файлы из " + Choice);
                foreach (var file in Directory.GetFiles(CurrentDirectory + "//" + Choice))
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
                Console.WriteLine("папки");
                foreach (var files in Directory.GetDirectories(CurrentDirectory + Choice))
                {
                    Console.WriteLine(Path.GetFileName(files));
                }

            }
            catch(System.ArgumentNullException)
            {
                Console.WriteLine("Ошибка");
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Такой директории не существует");
            }
            catch(System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка");
            }
        }
        public void Delete()                                            //Удаляет директорию
        {
            Console.WriteLine("Что удалить?");
            var Delete = Console.ReadLine();
            Directory.Delete(CurrentDirectory + "//" + Delete);
            
        }
        public void characteristics()                               // Дает характеристики файла
        {
            try
            {
            Console.WriteLine("Свойства какого объекта хотите узнать?");
            string Object = Console.ReadLine()!;
            FileInfo FileInfo = new FileInfo(CurrentDirectory + "\\" + Object);
            Console.WriteLine($"Путь: " + FileInfo.FullName);
            Console.WriteLine($"Имя: " + FileInfo.DirectoryName);
            Console.WriteLine("Дата создания: " + FileInfo.CreationTime);
            Console.WriteLine($"Размер: " + FileInfo.Length);
            Console.WriteLine($"Расширение: " + FileInfo.Extension);
            }
            catch(System.IO.FileNotFoundException)
            {
                Console.WriteLine("Ошибка видимо вы выбрали не файл");
            }
        }
        //public void Back()
        //{
        //    var back = Directory.GetParent(CurrentDirectory)!;
        //    foreach (var file in )
        //    {
        //        Console.WriteLine(Path.GetFileName(file));
        //    }
        //}
    } 
}
