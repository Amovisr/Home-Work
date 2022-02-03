char[,] SeaBattle = { 
    { 'X', 'O', 'X', 'X', 'O', 'O', 'O', 'O', 'O', 'O', },
    { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', },
    { 'X', 'O', 'O', 'O', 'X', 'X', 'X', 'O', 'O', 'O', },
    { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', },
    { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', },
    { 'X', 'O', 'O', 'O', 'X', 'X', 'X', 'O', 'O', 'X', },
    { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', },
    { 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', },
    { 'X', 'O', 'O', 'X', 'X', 'O', 'O', 'O', 'O', 'O', },
    { 'X', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'X', } 
};

for (int i = 0; i < SeaBattle.GetLength(0); i++)
{
    for (int j = 0; j < SeaBattle.GetLength(1); j++)
    {
      
        System.Console.Write($"{SeaBattle[i, j]} ");
    }

    System.Console.WriteLine();
}
