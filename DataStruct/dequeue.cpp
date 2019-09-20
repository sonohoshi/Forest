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
	Node* tail;

	int length;

	List() : head(NULL), length(0) {}


	Node* getNode(int index) {
		Node* current = head;
		for (int i = 0; i < index; i++) {
			current = current->nextPtr;
		}
		return current;
	}

	void push_back(int data) {
		Node* node = (Node*)malloc(sizeof(Node));
		node->data = data;
		node->nextPtr = NULL;
		if (length == 0) {
			head = tail = node;
		}
		tail->nextPtr = node;
		tail = node;
		length++;
	}

	void push_front(int data) {
		Node* node = (Node *)malloc(sizeof(Node));
		node->data = data;
		node->nextPtr = NULL;
		if(length == 0){
			head = tail = node;
		}
		Node* temp = head->nextPtr;
		head = node;
		node->nextPtr = temp;
		length++;
	}

	void pop_front() {
		Node* temp = head->nextPtr;
		free(head);
		head = temp;

		length--;
	}

	void pop_back(){
		Node* temp = getNode(length - 1);
		free(tail);
		tail = temp;

		length--;
	}

	int size() {
		return length;
	}

	int& peek_front() {
		return head->data;
	}

	int& peek_back(){
		return tail->data;
	}
};

int main() {
	List list;

	system("pause");
	return 0;
}