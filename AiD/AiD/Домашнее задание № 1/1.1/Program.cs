Console.Write("Йо! Вводи только числа >: ");

while (true)
{
    try
    {
        Numbers.SimpleNumber(Convert.ToDouble(Console.ReadLine()));
    }
    catch (Exception)
    {
        Console.WriteLine("Неккоректный ввод");

    }
}
public class Numbers
{
   public static bool SimpleNumber(double number)
    {
        double d = 0;

        double i = 2;

        while (i < number)
        {
            if (number % i == 0)
            {
                d++;
                break;
            }
            else
            {
                i++;
            }
        }
        if (d == 0)
        {
            Console.Write("Йо! Вводи только числа >: ");
            Console.WriteLine(true);
            return true;
        }
        if (d != 0)
        {
            Console.Write("Йо! Вводи только числа >: ");
            Console.WriteLine(false);
            return false;
        }
        return true;

    }
}