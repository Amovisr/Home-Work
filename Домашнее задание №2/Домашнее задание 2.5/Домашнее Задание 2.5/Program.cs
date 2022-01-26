Console.WriteLine("Какой сейчас по счёту месяц");
int КакойМесяц = Convert.ToInt32(Console.ReadLine());

switch (КакойМесяц)
{
    case (int)Winter.Январь:
        {
            Console.WriteLine("Январь");
            break;
        }
    case (int)Winter.Февраль:
        {
            Console.WriteLine("Февраль");
            break;
        }
    case (int)Spring.Март:
        {
            Console.WriteLine("Март");
            break;
        }
    case (int)Spring.Апрель:
        {
            Console.WriteLine("Апрель");
            break;
        }
    case (int)Spring.Май:
        {
            Console.WriteLine("Май");
            break;
        }
    case (int)Summer.Июнь:
        {
            Console.WriteLine("Июнь");
            break;
        }
    case (int)Summer.Июль:
        {
            Console.WriteLine("Июль");
            break;
        }
    case (int)Summer.Август:
        {
            Console.WriteLine("Август");
            break;
        }
    case (int)Autumn.Сентябрь:
        {
            Console.WriteLine("Сентябрь");
            break;
        }
    case (int)Autumn.Октябрь:
        {
            Console.WriteLine("Октябрь");
            break;
        }
    case (int)Autumn.Ноябрь:
        {
            Console.WriteLine("Ноябрь");
            break;
        }
    case (int)Winter.Декабрь:
        {
            Console.WriteLine("Декабрь");
            break;
        }

}

Console.WriteLine("Введите минимальную температуру");

int a = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Введите максимальную температуру");

int b = Convert.ToInt32(Console.ReadLine());
 
Console.WriteLine("Средняя температура");

Console.WriteLine((a + b) / 2);
    

    int c = ((a + b) / 2);


    switch (c)
    {
        case (int)Winter.Декабрь:
            Console.WriteLine("Дождливая зима");
            break;
        case (int)Winter.Январь:
            Console.WriteLine("Дождливая зима");
            break;
        case (int)Winter.Февраль:
            Console.WriteLine("Дождливая зима");
            break;
    }


enum Winter
{
    Январь = 1,
    Февраль = 2,
    Декабрь = 12,
}
enum Spring
{
    Март = 3,
    Апрель = 4,
    Май = 5,
}
enum Summer
{
    Июнь = 6,
    Июль = 7,
    Август = 8,
}
enum Autumn
{
    Сентябрь = 9,
    Октябрь = 10,
    Ноябрь = 11,
}