using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Домашнее_задание_9__1_
{
    class Program
    {


        static void Main(string[] args)
        {
            string path = @"G:\SwallowTheSea_v1_1";

            string currentIndex = string.Empty;

            string currentCmd = string.Empty;

            int folderIndex = 0;

            PrintTreeFiles(path);

            PrintTree(path, folderIndex);

            PrintMenu();

            Console.Write(">:");

            while (true)



                switch (Console.ReadLine())
                {
                    case "ls dir":

                        Console.WriteLine(">Введите номер страницы нумерация идет с 0 \n чтобы выйти из Пейджинга введите - quit");

                        while (currentCmd != "quit")

                        {

                            currentCmd = Console.ReadLine();

                            if (currentCmd == "quit")
                            {
                                PrintMenu();

                                break;
                            }
                            else
                            {
                                try
                                {
                                    int page = int.Parse(currentCmd);

                                    int pageSize = Properties.Settings.Default.FolderSize;

                                    int skipFolders = pageSize * page;

                                    int maxFolderToShow = skipFolders + pageSize;

                                    for (int i = skipFolders; i < maxFolderToShow; i++)
                                    {
                                        string[] folders = Directory.GetDirectories(path);

                                        if (folders.Length <= i)
                                        {
                                            Error("Страницы закончились!");
                                            Console.WriteLine();
                                            Console.Write(">:");
                                            break;

                                        }


                                        Console.WriteLine($"{folders[i]}");
                                    }

                                }

                                catch (Exception)
                                {

                                }


                            }
                        }
                        break;

                    case "ls":

                        Console.WriteLine(">Введите номер страницы нумерация идет с 0 \n чтобы выйти из Пейджинга введите - quit");

                        while (currentIndex != "quit")

                        {

                            currentIndex = Console.ReadLine();

                            if (currentIndex == "quit")
                            {
                                PrintMenu();

                                break;
                            }
                            else
                            {
                                try
                                {
                                    int pageFile = int.Parse(currentIndex);

                                    int pageFileSize = Properties.Settings.Default.PageSize;

                                    int skipFilesInFolder = pageFileSize * pageFile;

                                    int maxFilesToShowInFolder = skipFilesInFolder + pageFileSize;

                                    for (int i = skipFilesInFolder; i < maxFilesToShowInFolder; i++)
                                    {
                                        string[] files = Directory.GetFiles(path);
                                        if (files.Length <= i)
                                        {
                                            Error("Страницы закончились!");
                                            Console.WriteLine();
                                            Console.Write(">:");
                                            break;

                                        }

                                        FileInfo fileInfo = new FileInfo(files[i]);

                                        Console.WriteLine($"{fileInfo.FullName} {fileInfo.Length} bytes");

                                    }

                                }
                                catch (Exception)
                                {
                                    Error("Вводите толлько цифры");

                                    Console.WriteLine();
                                    Console.Write(">:");
                                }
                            }
                        }
                        break;

                    case "cp": // Коммнда на копированиее файлов
                        Console.Write("\n");
                        Console.WriteLine(">Введите путь файла для копирования и название копироваемого файла \n если хотите вернуться введие : back ");
                        Console.Write("\n");
                        Console.Write(">:");



                        try
                        {
                            File.Copy(Console.ReadLine(), Console.ReadLine());
                            Console.Write("\n");
                        }
                        catch (Exception ex)
                        {
                            if (ex != null)
                            {
                                Console.Write("\n");

                                Error("Введены не корекнтые даные ");

                                Console.WriteLine();
                                Console.Write("\n");

                                PrintMenu();

                                Console.Write(">:");
                            }
                        }
                        Console.Write("\n");

                        Complete("Успешное копирование файла!");

                        Console.WriteLine();
                        Console.Write("\n");

                        PrintMenu();



                        break;




                    case "rm": //Комманда на удаление файлов
                        Console.Write("\n");

                        Console.WriteLine("> Введиите путь файла для удаления \n  если хотите вернуться введие : back ");

                        Console.Write("\n");

                        Console.Write(">");
                        try
                        {
                            File.Delete(Console.ReadLine());
                            Console.Write("\n");
                        }
                        catch (Exception ex)
                        {
                            if (ex != null)
                            {
                                Console.Write("\n");

                                Error("Введены не корекнтые даные ");

                                Console.WriteLine();
                                Console.Write("\n");

                                PrintMenu();

                                Console.Write(">:");
                            }
                        }
                        Complete("Файл успешно удален");

                        Console.WriteLine();
                        Console.Write("\n");

                        PrintMenu();

                        break;

                    case "cp dir": // Коммнда для копирования папки Папки
                        Console.Write("\n");

                        Console.WriteLine(">Введите путь Папки для копирования Папки \n если хотите вернуться введие : back ");

                        Console.Write("\n");

                        Console.Write(">:");
                        try
                        {
                            Directory.CreateDirectory(Console.ReadLine());
                            Console.Write("\n");


                        }

                        catch (Exception)
                        {
                            Console.Write("\n");

                            Error("Введены не корекнтые даные ");

                            Console.WriteLine();
                            Console.Write("\n");
                        }

                        Complete("Каталог успешно создан");
                        Console.WriteLine();
                        Console.Write("\n");

                        PrintMenu();
                        Console.Write(">:");


                        break;




                    case "rm dir": //Комманда на удаления Папки
                        Console.Write("\n");
                        Console.WriteLine("> Введиите путь Папки для удаления \n  (Папка должна быть пустая удалите все файлы перед удаление Папки)  \n  если хотите вернуться введие : back ");
                        Console.Write("\n");
                        Console.Write(">:");
                        try
                        {
                            Directory.Delete(Console.ReadLine());
                            Console.Write("\n");
                        }
                        catch (Exception)
                        {
                            Error("Введены не корекнтые даные ");

                            Console.WriteLine();
                            Console.Write("\n");
                        }

                        Complete("Каталог успешно удален");
                        Console.WriteLine();
                        Console.Write("\n");

                        PrintMenu();
                        Console.Write(">:");
                        break;

                    case "back":

                        PrintMenu();

                        break;


                    default:

                        Error("Не корректный ввод");

                        Console.WriteLine();
                        Console.Write("\n");
                        Console.Write(">:");

                        break;

                }

        }

        private static void PrintMenu() //Начальное меню файлового менеджера

        {
            Console.WriteLine("> Список доступных команд :\n  ls dir - Пейджинг" +
                " Папок  \n  rm dir - Удаление папки (папка должна быть пустая)\n  cp dir Создание Папки \n  ls - Пейджинг \n  cp - Копирование файлов \n  rm - Удаление Файлов" +
                "\n  back - Вернуться в это меню из других комманд");
        }


        public static void PrintTreeFiles(string files)
        {
            try 
            {
                string[] file = Directory.GetFiles(files);
                for (int i = 0; i < file.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(file[i]);

                    Console.WriteLine($"{fileInfo.FullName} {fileInfo.Length} bytes");

                }
                
            }
            catch 
            {
                
            }
        }




        public static void PrintTree(string directory, int level) //Показ древа
        {
            try
            {
                string[] dirs = Directory.GetDirectories(directory);

                for (int i = 0; i < dirs.Length; i++)
                {

                    string childDir = dirs[i];
                    
                    for (int z = 0; z < level; z++)
                    {
                        Console.Write("\t ");
                    }

                    Console.WriteLine(childDir);

                    PrintTree(childDir, level + 1);
                }
            }
            catch (Exception)
            {

            }
        }

        static void Complete(string value) // Покрас успешных операций
        {

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();

        }
        static void Error(string value) // Покрас ошибок
        {

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
            Console.ResetColor();

        }
    }
}