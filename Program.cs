using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Файловый менеджер");
        Console.WriteLine("Выберите действие");
        Console.WriteLine("1 - копировать");
        Console.WriteLine("2 - удалить");
        Console.WriteLine("3 - получить информацию");
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
}
