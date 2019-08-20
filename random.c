#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main() {
	int temp;
	int PlayerDice, ComputerDice;
	int turn = 0;
	int first = 0;
	int _31 = 1;
	int swt = 0;
	int exitswt = 0;
	srand(time(NULL));
	printf("주사위를 통해 큰 수가 나온 쪽이 먼저 플레이 합니다.\n");
	system("pause");
	PlayerDice = (rand() % 6) + 1;
	ComputerDice = (rand() % 6) + 1;
	printf("플레이어의 주사위 : %d\n", PlayerDice);
	printf("컴퓨터의 주사위 : %d\n", ComputerDice);
	PlayerDice > ComputerDice ? puts("플레이어가 먼저 수를 선언합니다.\n") : puts("컴퓨터가 먼저 수를 선언합니다.\n");
	system("pause");
	system("cls");
	first = PlayerDice > ComputerDice ? 1 : 0;
	if (first) {
		do {
			int random = (rand() % 3) + 1;
			if (_31 == 31) {
				puts("31! 플레이어의 패배입니다.\n");
				system("pause");
				return;
			}
			printf("%d번째 턴, 플레이어의 턴입니다. 선언할 수의 개수를 입력해주세요. (최대 3개)\n", ++turn);
			while (1) {
				scanf_s("%d", &swt);
				switch (swt) {
					case 1: printf("%d!\n", _31++); exitswt++; break;
					case 2: printf("%d! %d!\n", _31, _31 + 1); _31+=2; exitswt++; break;
					case 3: printf("%d! %d! %d!\n", _31, _31 + 1, _31 + 2); _31 += 3; exitswt++; break;
					default: printf("잘못된 수를 입력하셨습니다. 1부터 3 사이의 수를 입력해주세요.\n");
				}
				if (exitswt) break;
			}
			exitswt = 0;
			printf("%d번째 턴, 컴퓨터의 턴입니다. 컴퓨터가 알아서 수를 뱉습니다.\n",++turn);
			system("pause");
			if (_31 == 2) {
				printf("%d\n", _31++);
			}
			else if (_31 >= 3 && _31 <= 6) {
				for (int i = 0; _31 <= 6; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else if (_31 >= 7 && _31 <= 10) {
				for (int i = 0; _31 <= 10; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);;
				}
			}
			else if (_31 >= 11 && _31 <= 14) {
				for (int i = 0; _31 <= 14; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else if (_31 >= 15 && _31 <= 18) {
				for (int i = 0; _31 <= 18; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else if (_31 >= 19 && _31 <= 22) {
				for (int i = 0; _31 <= 22; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else if (_31 >= 23 && _31 <= 26) {
				for (int i = 0; _31 <= 26; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else if (_31 >= 27 && _31 <= 30) {
				for (int i = 0; _31 <= 30; i++) {
					if (i > 2) break;
					printf("%d\n", _31++);
				}
			}
			else {
				for (int i = 0; i<=31; i++, i++) {
					printf("%d\n", _31++);
					if (i > 2) break;
				}
			}
		} while (_31<31);
	}
	system("pause");
}