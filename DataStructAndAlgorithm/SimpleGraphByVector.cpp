#include <iostream>
#include <vector>
using namespace std;

int main() {
	int n, m;
	cin >> n >> m;
	vector<int>* graph = new vector<int>[n + 1];

	int u, v;
	cin >> u >> v;
	graph[u].push_back(v);
	graph[v].push_back(u);

	delete[] graph;

	return 0;
}