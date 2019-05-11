#include <iostream>
#include <string>
using namespace std;

class Node {
public:
	int data;
	Node* nextPtr;

	Node() : data(0), nextPtr(NULL) {}
};

class List {
public:
	Node* head;

	int length;

	List() : head(NULL), length(0) {}

	void push(int data) {
		Node* node = (Node*)malloc(sizeof(Node));
		Node* temp = head;
		node->data = data;
		node->nextPtr = NULL;
		if (length == 0) head = node;
		node->nextPtr = temp;
		node = head;
		length++;
	}

	void pop() {
		Node* temp = head->nextPtr;
		free(head);
		head = temp;

		length--;
	}

	int size() {
		return length;
	}

	int& peek() {
		return head->data;
	}
};

int main() {
	List list;

	list.push(3);
	std::cout << list.size() << std::endl;
	std::cout << list.peek() << std::endl;
	list.pop();
	std::cout << list.size() << std::endl;

	system("pause");
	return 0;
}