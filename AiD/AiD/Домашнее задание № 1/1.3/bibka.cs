//Fibonachi();
FibonachiN();
static void Fibonachi()// с рекурсией
{

    long F0 = 1;
    long F1 = 1;
    long F2 = 0;
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($" {F2}");
        F0 = F1;
        F1 = F2;


    }

}

static void FibonachiN()// без рекурсии рекурсией
{
Console.WriteLine("До какого числа считать ряд Фибоначчи?");
    int number = Convert.ToInt32(Console.ReadLine());
    long F0 = 1;
    long F1 = 1;
    long F2 = 0;
    while (number >= F2)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        F2 = F0 + F1;
        Console.Write($" {F2}");
        F0 = F1;
        F1 = F2;


    }

}
