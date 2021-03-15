#include <iostream>

using namespace std;

class Node{
public:
	int data;
	Node* left;
	Node* right;

	Node() : data(0), left(NULL), right(NULL){}
}

class Tree{
public:
	Node* root;
	int level;

	Tree() : root(NULL), level(0);
	
	Node* MakeTreeNode(){
		Node* node = (Node*)malloc(sizeof(Node));
		node->left = NULL;
		node->right = NULL;

		return node;
	}
	int GetData(Node* node){
		return node->data;
	}
	void SetData(Node* node,int data){
		node->data = data;
	}
	Node* GetLeftSubTree(Node* node){
		return node->left;
	}
	Node* GetRightSubTree(Node* node){
		return node->right;
	}
	void MakeLeftSubTree(Node* sub){

	}
	void MakeRightSubTree(Node* sub){

	}
	void Inorder(Node* node){
		if(node != NULL){
			Inorder(node->left);
			cout << node->data << endl;
			Inorder(node->right);
		}
	}
	void Preorder(Node* node){
		if(node != NULL){
			cout << node->data << endl;
			Preorder(node->left);
			Preorder(node->right);
		}
	}
	void Postorder(Node* node){
		if(node != NULL){
			Postorder(node->left);
			Postorder(node->right);
			cout << node->data << endl;
		}
	}
	void FreeTree(Node* node){
		if(node != NULL){
			FreeTree(node->left);
			FreeTree(node->right);
			cout << "Free Tree " << node->data << endl;
		}
	}
}