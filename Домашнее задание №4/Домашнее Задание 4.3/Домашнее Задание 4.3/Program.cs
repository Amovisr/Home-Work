Console.WriteLine("Какой сейчас по счёту месяц");

Console.WriteLine(WhichSeason());


static string WhichSeason()
{
    int whichMonth = Convert.ToInt32(Console.ReadLine());

    if (whichMonth > 12)
    {
        return $"Ошибка: введите число от 1 до 12";
    }
    if (whichMonth < 1)
    {
        return $"Ошибка: введите число от 1 до 12";
    }

    switch (whichMonth)
    {

        case (int)Winter.Декабрь:
            {
                Console.WriteLine("Зима");
                break;
            }
        case (int)Winter.Январь:
            {
                Console.WriteLine("Зима");
                break;
            }
        case (int)Winter.Февраль:
            {
                Console.WriteLine("Зима");
                break;
            }
        case (int)Spring.Март:
            {
                Console.WriteLine("Весна");
                break;
            }
        case (int)Spring.Апрель:
            {
                Console.WriteLine("Весна");
                break;
            }
        case (int)Spring.Май:
            {
                Console.WriteLine("Весна");
                break;
            }
        case (int)Summer.Июнь:
            {
                Console.WriteLine("Лето");
                break;
            }
        case (int)Summer.Июль:
            {
                Console.WriteLine("Лето");
                break;
            }
        case (int)Summer.Август:
            {
                Console.WriteLine("Лето");
                break;
            }
        case (int)Autumn.Сентябрь:
            {
                Console.WriteLine("Осень");
                break;
            }
        case (int)Autumn.Октябрь:
            {
                Console.WriteLine("Осень");
                break;
            }
        case (int)Autumn.Ноябрь:
            {
                Console.WriteLine("Осень");
                break;
            }


    }

    return String.Empty;

}

public enum Winter
{
    Январь = 1,
    Февраль = 2,
    Декабрь = 12,
}
public enum Spring
{
    Март = 3,
    Апрель = 4,
    Май = 5,
}
public enum Summer
{
    Июнь = 6,
    Июль = 7,
    Август = 8,
}
public enum Autumn
{
    Сентябрь = 9,
    Октябрь = 10,
    Ноябрь = 11,
}


