#include <stdio.h>

void Quick_sort(int* arr, int start, int end){
    if(start >= end) return;
    else if(end - start == 1){
        if(arr[start] > arr[end]){
            arr[start] ^= arr[end] ^= arr[start] ^= arr[end];
            return;
        }
    }
	int pivot, p, q;
	pivot = start;
	p = pivot + 1;
	q = end;
	while(p <= q){
		while(p <= end && arr[p] <= arr[pivot]) p++;
		while(q > start && arr[q] >= arr[pivot]) q--;
		if(p > q) arr[q] ^= arr[pivot] ^= arr[q] ^= arr[pivot];
		else arr[p] ^= arr[q] ^= arr[p] ^= arr[q];
	}
	Quick_sort(arr, start, q - 1);
	Quick_sort(arr, q + 1, end);
}

int main(){
	int arr[6] = {62, 98, 74, 39, 47, 53};
	Quick_sort(arr,0,5);
	for(int i=0;i<6;i++) printf("%d ",arr[i]);
	return 0;
}
