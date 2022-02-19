
int Fibonachi(int n)
{
    if (n == 0 || n == 1) return n;

    return Fibonachi(n - 1) + Fibonachi(n - 2);
}

int firstFibonachi = Fibonachi(1);
int secondFibonachi = Fibonachi(2);
int thirdFibonachi = Fibonachi(3);
int fourthFibonachi = Fibonachi(4);

Console.WriteLine(firstFibonachi);
Console.WriteLine(secondFibonachi);
Console.WriteLine(thirdFibonachi);
Console.WriteLine(fourthFibonachi);
