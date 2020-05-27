#pragma warning(disable:4996)
#include <stdio.h>
#include <stdlib.h>

int** alloc_matrix(int row, int col);
void print_matrix(int** a, int row, int col);
void free_matrix(int** a, int row, int col);

int main() {
    int** matrix;
    int m, n, i, j;

    printf("행의 수 : ");
    scanf("%d", &m);
    printf("열의 수 : ");
    scanf("%d", &n);

    matrix = alloc_matrix(m, n);
    print_matrix(matrix, m, n);

    for (i = 0; i < m; i++) {
        for (j = 0; j < n; j++) {
            matrix[i][j] = 1;
        }
    }

    print_matrix(matrix, m, n);

    free_matrix(matrix, m, n);
    return 0;
}

int** alloc_matrix(int row, int col)
{
    int** arr = malloc(sizeof(int*) * row);
    for (int i = 0; i < row; i++) {
        arr[i] = malloc(sizeof(int) * col);
    }
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            arr[i][j] = 0;
        }
    }
    return arr;
}

void print_matrix(int** a, int row, int col)
{
    for (int i = 0; i < row; i++) {
        for (int j = 0; j < col; j++) {
            printf("%d ", a[i][j]);
        }
        printf("\n");
    }
}

void free_matrix(int** a, int row, int col)
{
    for (int i = 0; i < row; i++) {
        free(a[i]);
    }
    free(a);
}