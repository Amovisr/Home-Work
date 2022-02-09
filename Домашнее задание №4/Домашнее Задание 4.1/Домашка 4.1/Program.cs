int count = 0;
while (count <= 3) 
{
    Console.Write("Введите Имя: ");

    string firstName = Console.ReadLine();

    Console.Write("Введите Фаммилию: ");

    string lastName = Console.ReadLine();

    Console.Write("Введите Отчество: ");
    string patronymic = Console.ReadLine();
    Console.WriteLine(GetFullName(firstName, lastName, patronymic));
    count++;
}
static string GetFullName(string firstName,string lastName, string patronymic)
{
    return $"{firstName} {lastName} {patronymic}";
}
  

