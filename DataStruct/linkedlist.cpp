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

	Node* getNode(int index) {
		Node* current = head;
		for (int i = 0; i < index; i++) {
			current = current->nextPtr;
		}
		return current;
	}

	void insert(int data, int index) {
		Node* node = (Node*)malloc(sizeof(Node));
		node->nextPtr = NULL;
		node->data = data;
		if (index == 0) {
			if (head == NULL) {
				node->nextPtr = head;
			}
			head = node;
		}
		else if (index > 0 && index < length) {
			Node* next = getNode(index);
			Node* prev = getNode(index - 1);
			prev->nextPtr = node;
			node->nextPtr = next;
		}
		else if (index == length) {
			getNode(index - 1)->nextPtr = node;
		}
		length++;
	}

	void remove(int index) {
		if (index == 0) {
			Node* node = head->nextPtr;
			free(head);
			head = node;
		}
		else if (index > 0 && index < length) {
			Node* next = getNode(index + 1);
			Node* prev = getNode(index - 1);
			free(getNode(index));
			prev->nextPtr = next;
		}
		else if (index > length) {
			Node* prev = getNode(index - 1);
			free(getNode(index));
			prev->nextPtr = NULL;
		}
		length--;
	}

	int size() {
		return length;
	}

	int& get(int index) {
		return getNode(index)->data;
	}
};

int main() {
	List list;

	list.insert(1, 0);
	list.insert(2, 1);
	list.insert(3, 2);

	for (int i = 0; i < 3; ++i) {
		std::cout << list.get(i) << std::endl;
	}

	std::cout << list.size() << std::endl;

	list.remove(0);
	list.remove(0);
	list.remove(0);

	std::cout << list.size() << std::endl; 

	system("pause");
	return 0;
}