#include <iostream>
using namespace std;

int main() {
	// n = 정점의 개수, m = 간선의 개수
	int n, m;
	cin >> n >> m;

	// n개의 각 정점마다 타 정점으로 갈 수 있도록 행렬을 생성
	int** graph = new int* [n];
	for (int i = 0; i < n; i++) {
		graph[i] = new int[n];
	}

	// 각 간선을 -1로 초기화. 못가는 길은 0으로 더 많이 초기화 하는 것 같지만 아무튼.
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			graph[i][j] = -1;
		}
	}

	// 간선의 수만큼 입력을 받아 초기화를 해줌.
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