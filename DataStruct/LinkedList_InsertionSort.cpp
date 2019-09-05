#include <iostream>

class Node
{
public:
    int data;
    Node* next;

    Node() : data(0), next(NULL) {}
};

class List
{
private:
    Node* head;
    Node* tail;
    int length;

    Node* getNode(int index)
    {
        Node* current = head;

        for (int i = 0; i < index; ++i)
        {
            current = current->next;
        }

        return current;
    }

public:
    void insert(int data)
    {
        Node* newNode = new Node;
        newNode->data = data;

        if (head == NULL)
        {
            head = newNode;
            tail = head;
            head->next = tail;
        }
        else
        {
            Node* current = new Node;
            Node* before = NULL;
            int index = 0;

            for (;index < length; ++index)
            {
                if (getNode(index)->data >= data)
                {
                    break;
                }
            }

            getNode(index - 1)->next = newNode;
            newNode->next = getNode(index);
        }

        length++;
    }

    void remove(int index)
    {

    }

    int& operator[](int index)
    {
        return getNode(index)->data;
    }

    const int& size()
    {
        return length;
    }

};

int main(){
	
}