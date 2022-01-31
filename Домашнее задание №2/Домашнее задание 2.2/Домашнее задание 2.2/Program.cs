Console.WriteLine("Какой сейчас по счёту месяц");
int КакойМесяц = Convert.ToInt32(Console.ReadLine());

switch (КакойМесяц)
{ 
    case (int)Month.Январь:
        {
            Console.WriteLine("Январь");
    break;
        }
    case (int)Month.Февраль:
        {
            Console.WriteLine("Февраль");
            break;
        }
    case (int)Month.Март:
        {
            Console.WriteLine("Март");
            break;
        }
    case (int)Month.Апрель:
        {
            Console.WriteLine("Апрель");
            break;
        }
    case (int)Month.Май:
        {
            Console.WriteLine("Май");
            break;
        }
    case (int)Month.Июнь:
        {
            Console.WriteLine("Июнь");
            break;
        }
    case (int)Month.Июль:
        {
            Console.WriteLine("Июль");
            break;
        }
    case (int)Month.Август:
        {
            Console.WriteLine("Август");
            break;
        }
    case (int)Month.Сентябрь:
        {
            Console.WriteLine("Сентябрь");
            break;
        }
    case (int)Month.Октябрь:
        {
            Console.WriteLine("Октябрь");
            break;
        }
    case (int)Month.Ноябрь:
        {
            Console.WriteLine("Ноябрь");
            break;
        }
    case (int)Month.Декабрь:
        {
            Console.WriteLine("Декабрь");
            break;
        }
   
}

enum Month
{
    Январь = 1,
    Февраль = 2,
    Март = 3,
    Апрель = 4,
    Май = 5,
    Июнь = 6,
    Июль = 7,
    Август = 8,
    Сентябрь = 9,
    Октябрь = 10,
    Ноябрь = 11,
    Декабрь = 12,
}