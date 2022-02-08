string Приветсвие = "Hello, world!";
string Вывод = "";
for (int i = Приветсвие.Length - 1; i >= 0; i--)
{
    Вывод += Приветсвие[i];

    Console.WriteLine($"{Вывод}");


}




