int[] array = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
_ = BinarySearch(array, 2);

_ = BinarySearch(array,10);
_ = BinarySearch(array, 15);
static int BinarySearch(int[] inputArray, int searchValue)
{
    int min = 0;
    int max = inputArray.Length - 1;
    while (min <= max)
    {
        int mid = (min + max) / 2;
        if (searchValue == inputArray[mid])
        {
            return mid;
        }
        else if (searchValue < inputArray[mid])
        {
            max = mid - 1;
        }
        else
        {
            min = mid + 1;
        }
    }
    return -1;
}