#include <iostream>
#include <string>
using namespace std;

int queue[10000] = { 0 };
int frontPtr=0, backPtr=0;

void push(int data) {
	queue[backPtr++] = data;
}

int pop() {
	int buffer = 0;
	if (!(queue[frontPtr] + queue[backPtr])) return -1;
	buffer = queue[frontPtr];
	queue[frontPtr++] = 0;
	return buffer;
}

int size() {
	return backPtr - frontPtr;
}

bool empty() {
	return !(queue[frontPtr] + queue[backPtr]);
}

int front() {
	if (!(queue[frontPtr] + queue[backPtr])) return -1;
	return queue[frontPtr];
}

int back() {
	if (!(queue[frontPtr] + queue[backPtr])) return -1;
	return queue[backPtr-1];
}

int main() {
	string str;
	int n, num;
	cin >> n;
	for (int i = 0; i < n; i++) {
		cin >> str;
		if (str == "push") { cin >> num; push(num); }
		else if (str == "pop") { cout << pop() << endl; }
		else if (str == "size") { cout << size() << endl; }
		else if (str == "empty") { cout << empty() << endl; }
		else if (str == "front") { cout << front() << endl; }
		else if (str == "back") { cout << back() << endl; }
	}
	return 0;
}