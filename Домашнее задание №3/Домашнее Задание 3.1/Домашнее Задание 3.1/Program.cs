int[,] matrix = new int[5, 5];
matrix[0, 0] = 1;
matrix[1, 1] = 1;
matrix[2, 2] = 1;
matrix[3, 3] = 1;
matrix[4, 4] = 1;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        System.Console.Write($"{matrix[j, i]} ");
    }
    System.Console.WriteLine();
}

