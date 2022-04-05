Console.WriteLine("Введите слово для его переворачивания");
Console.Write(">:");
_ = ReverseString(Console.ReadLine());

string ReverseString(string reverse)
{
    for (int i = reverse.Length - 1 ; i <= reverse.Length; i--)
    {
        Console.Write(reverse[i]);

        if (i <= 0) break;
       
      
    }

    return reverse;
}
