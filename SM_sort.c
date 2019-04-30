#include <stdio.h>
void sm_sort(int arr[],int n) {
	for (int i = 0; i < n; i++) {
		for (int j = n-1; j > i; j--) {
			if (arr[i] > arr[j]) arr[i] ^= arr[j] ^= arr[i] ^= arr[j];
		}
	}
}

int main() {
	int arr[6] = { 15,7,22,37,45,3 };
	sm_sort(arr, 6);
	puts("Sort Result");
	for (int i = 0; i < 6; i++) {
		printf("%d ", arr[i]);
	}
	puts(" ");

	system("pause");
	return 0;
}