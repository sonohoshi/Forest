#include <iostream>
#include <string>
using namespace std;

int frontPtr = 0;
int backPtr = 0;

int queue[10000] = {0};

void push(int data) {
	queue[frontPtr++] = data;
}

int pop() {
	if (!queue[frontPtr] && !queue[backPtr]) {
		return -1;
	}
	int buffer = queue[frontPtr];
	queue[frontPtr--] = 0;
	return buffer;
}

int size() {
	return frontPtr - backPtr ;
}

bool empty() {
	return !(queue[frontPtr] + queue[backPtr]) ? 1 : 0;
}

int front() {
	return !queue[frontPtr] ? -1 : queue[frontPtr];
}

int back() {
	return !queue[frontPtr] ? -1 : queue[backPtr];
}

int main() {
	string str;
	int num, n;
	cin >> num;
	for (int i = 0; i < num; i++) {
		cin >> str;
		if (str == "push") {
			cin >> n;
			push(n);
		}
		else if (str == "pop") {
			cout << pop() << endl;
		}
		else if (str == "size") {
			cout << size() << endl;
		}
		else if (str == "empty") {
			cout << empty() << endl;
		}
		else if (str == "front") {
			cout << front() << endl;
		}
		else if (str == "back") {
			cout << back() << endl;
		}
	}

	system("pause");
	return 0;
}