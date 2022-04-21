Fibonachi();
static void Fibonachi()
{

    long F0 = 1;
    long F1 = 1;
    long F2 = 0;
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        F2 = F0 + F1;
        Console.Write($" {F2}");
        F0 = F1;
        F1 = F2;


    }

}