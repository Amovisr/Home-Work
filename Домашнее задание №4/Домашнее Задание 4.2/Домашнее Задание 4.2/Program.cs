Console.WriteLine("Введите числа через пробел");
string someNumbers = Console.ReadLine();
int allNumbers = 0;
string tempWord = "";
for (int i = 0; i < someNumbers.Length; i++)
{
    
    char currentSymb = someNumbers[i];

    if (currentSymb != ' ')
    {
        tempWord += someNumbers[i];
        
    }

    if (someNumbers[i] == ' ' || i == someNumbers.Length - 1)
    {
        allNumbers += int.Parse(tempWord);
        tempWord = "";
    }

    Console.WriteLine(allNumbers);
}





