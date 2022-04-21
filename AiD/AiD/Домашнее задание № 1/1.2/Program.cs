static int StrangeSum(int[] inputArray)
{
    int sum = 0;
    for (int i = 0; i < inputArray.Length; i++)// O(a(N)) 
    {
        for (int j = 0; j < inputArray.Length; j++)// O(b(N))
        {
            for (int k = 0; k < inputArray.Length; k++)//O(c(N))           O(a(N)) x O(b(N)) x O(c(N)) = O(N x N x N) = O(N³)
            {
                int y = 0;
                if (j != 0)
                {
                    y = k / j;
                }
                sum += inputArray[i] + i + k + j + y;
            }
        }
    }
    return sum;
}