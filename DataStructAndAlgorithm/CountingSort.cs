public static int[] CountingSort(this int[] arr)
{
    var result = new int[arr.Length];
    int min, max;
    min = max = arr[0];
    foreach (var item in arr)
    {
        if (item < min) min = item;
        if (item > max) max = item;
    }

    var counts = new int[max - min + 1];
    
    foreach (var item in arr)
    {
        counts[item - min]++;
    }

    int idx = 0;
    for (int i = min; i <= max; i++)
    {
        while (counts[i - min]-- > 0)
        {
            result[idx++] = i;
        }
    }

    return result;
}
/* 
 * 동적으로 뜬금없이 튀어나온 배열에서도 쓸 수 있게끔 음수도 정렬할 수 있도록 만들었더니
 * 생각보다 작업 양이 조금 많네요. 공부하면서 찾아본 시간 복잡도에 비하면 작업이 조금 더 나왔어요.
*/