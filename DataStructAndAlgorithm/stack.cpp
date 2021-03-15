#include <iostream>
#include <string>

int stack[1000] = { 0 };
int topPtr = -1;

void push(int data) {
	stack[++topPtr] = data;
}

int pop() {
	if (topPtr != -1)
		return stack[topPtr--];
	return 404;
}

int peek() {
	if (topPtr != -1)
		return stack[topPtr];
	return 404;
}

int empty() {
	if (topPtr != -1)
		return 1;
	return 0;
}

int size() {
	if (topPtr != -1)
		return topPtr + 1;
	return 404;
}

void help() {
	std::cout << std::endl;
	std::cout << "void push(int data) :: push data." << std::endl;
	std::cout << "int pop(void) :: return data of stack's TOP and delete data of stack's TOP." << std::endl << "If \"stack\" is empty, return 404." << std::endl;
	std::cout << "int peek() :: return data of stack's TOP." << std::endl;
	std::cout << "int empty() :: If there is data in stack, return 1. If not, return 0." << std::endl;
	std::cout << "int size() :: return number of data. If \"stack\" is empty, return 404." << std::endl;
	std::cout << "THX for read my code." << std::endl;
	system("pause");
	system("cls");
}

int checkComm(std::string comm) {
	if (comm.compare("push") == 0) return 1;
	else if (comm.compare("pop") == 0) return 2;
	else if (comm.compare("peek") == 0) return 3;
	else if (comm.compare("empty") == 0) return 4;
	else if (comm.compare("size") == 0) return 5;
	else if (comm.compare("help") == 0) return 6;
	else if (comm.compare("404") == 0) return 404;
	return 0;
}

int main() {
	std::string comm;
	int data;
	int swt = 0;
	while (1) {
		std::cout << "PLZ Enter Command (404 is exit)" << std::endl;
		std::cout << "Enter \"help\" to get help." << std::endl;
		std::cin >> comm;
		switch (checkComm(comm)) {
		case 1:
			std::cin >> data;
			std::cout << std::endl;
			push(data); break;
		case 2:
			std::cout << pop() << std::endl << std::endl; break;
		case 3:
			std::cout << peek() << std::endl << std::endl; break;
		case 4:
			std::cout << empty() << std::endl << std::endl; break;
		case 5:
			std::cout << size() << std::endl << std::endl; break;
		case 6:
			help(); break;
		case 404:
			system("cls");
			std::cout << "Exit S T A C K" << std::endl; goto exit;
		default:
			std::cout << "Invalid command entered." << std::endl;
		}
	}
	exit:
	return 0;
}