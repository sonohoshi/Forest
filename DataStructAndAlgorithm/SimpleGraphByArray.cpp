#include <iostream>
using namespace std;

int main() {
	// n = ������ ����, m = ������ ����
	int n, m;
	cin >> n >> m;

	// n���� �� �������� Ÿ �������� �� �� �ֵ��� ����� ����
	int** graph = new int* [n];
	for (int i = 0; i < n; i++) {
		graph[i] = new int[n];
	}

	// �� ������ -1�� �ʱ�ȭ. ������ ���� 0���� �� ���� �ʱ�ȭ �ϴ� �� ������ �ƹ�ư.
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			graph[i][j] = -1;
		}
	}

	// ������ ����ŭ �Է��� �޾� �ʱ�ȭ�� ����.
	for (int i = 0; i < m; i++) {
		int u, v;
		cin >> u >> v;
		graph[v][u] = graph[u][v] = 1;
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			printf("%3d ", graph[i][j]);
		}
		cout << endl;
	}

	for (int i = 0; i < n; i++) {
		delete[] graph[i];
	}

	delete[] graph;

	return 0;
}