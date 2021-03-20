public static class Extensions
{
    private static int DivideArray(int[] arr, int left, int right)
    {
        var pivotValue = arr[left];
        var leftIndex = left;
        var rightIndex = right;

        while (leftIndex < rightIndex)
        {
            while ((leftIndex <= right) && (arr[leftIndex] < pivotValue)) leftIndex++;
            while ((rightIndex >= left) && (arr[rightIndex] > pivotValue)) rightIndex--;

            if (leftIndex < rightIndex)
            {
                var temp = arr[leftIndex];
                arr[leftIndex] = arr[rightIndex];
                arr[rightIndex] = temp;

                if (arr[leftIndex] == arr[rightIndex]) rightIndex--;
            }
        }

        return rightIndex;
    }
    
    public static void QuickSort(this int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = DivideArray(arr, left, right);

            arr.QuickSort(left, pivot - 1);
            arr.QuickSort(pivot + 1, right);
        }
    }
}