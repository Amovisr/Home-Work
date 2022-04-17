using ТЗ_ООП;


string path = @"C:\Users\allda\Desktop";

string currentIndex = string.Empty;

string currentCmd = string.Empty;

int folderIndex = 0;

TreeFiles treeFiles = new TreeFiles(path);
Console.WriteLine(treeFiles);

Menu menu = new Menu();// Меню
Console.WriteLine(menu.Print);// Печать меню


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
                    Console.WriteLine(menu.Print);

                    break;
                }
                else
                {
                    try
                    {
                        int page = int.Parse(currentCmd);

                        int pageSize = 5;

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
                    Console.WriteLine(menu.Print);

                    break;
                }
                else
                {
                    try
                    {
                        int pageFile = int.Parse(currentIndex);

                        int pageFileSize = 5;

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

                    Console.WriteLine(menu.Print);

                    Console.Write(">:");
                }
            }
            Console.Write("\n");

            Complete("Успешное копирование файла!");

            Console.WriteLine();
            Console.Write("\n");

            Console.WriteLine(menu.Print);



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

                    Console.WriteLine(menu.Print);

                    Console.Write(">:");
                }
            }
            Complete("Файл успешно удален");

            Console.WriteLine();
            Console.Write("\n");

            Console.WriteLine(menu.Print);

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

            Console.WriteLine(menu.Print);
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

            Console.WriteLine(menu.Print);
            Console.Write(">:");
            break;

        case "back":

            Console.WriteLine(menu.Print);

            break;


        default:

            Error("Не корректный ввод");

            Console.WriteLine();
            Console.Write("\n");
            Console.Write(">:");

            break;

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
class TreeFiles 
{

    public TreeFiles(string files)
    {
        try
        {
            string[] file = Directory.GetFiles(files);
            for (int i = 0; i < file.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(file[i]);

                Console.WriteLine ($"{fileInfo.FullName} {fileInfo.Length} bytes");

            }

        }
        catch
        {

        }
    }
}