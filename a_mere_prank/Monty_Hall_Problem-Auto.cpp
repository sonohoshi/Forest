#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <ctime>
using namespace std;

int main() {
	srand(time(NULL));

	int gameTimes;
	int winWithChange = 0;
	int winWithNoChange = 0;
	bool hall[3] = { false };

	cout << "������ �ݺ� Ƚ���� �Է����ּ��� >> ";
	cin >> gameTimes;

	for (int i = 0; i < gameTimes; i++) {
		hall[0] = hall[1] = hall[2] = false;
		int beforeAnswer;
		int afterAnswer;
		int left = -1, right = -1;

		int rightAnser = rand() % 3;
		hall[rightAnser] = true;
		// cout << "\n\n" << rightAnser + 1 << "���� �����Դϴ�.\n";

		// printf("left : %d, right : %d\n", left + 1, right + 1);
		cout << "1/2/3 �� �������� ���α׷��� �����մϴ�\n";
		
		//cin >> beforeAnswer;
		beforeAnswer = rand() % 3;
		cout << "���α׷��� " << beforeAnswer + 1 << "��°�� �����߽��ϴ�." << endl;
		
		for (int j = 0; j < 3; j++) {
			if (j != beforeAnswer) {
				if (left == -1) {
					left = j;
				}
				else {
					right = j;
				}
			}
		}

		int showAnswer = hall[left] ? right + 1 : left + 1;

		cout << showAnswer << "��°�� ���� �ƴմϴ�. �ٽ� �ѹ� �ڵ����� �����մϴ�.\n";
		//cin >> afterAnswer;
		left = -1;
		right = -1;
		for (int i = 0; i < 3; i++) {
			if (i != showAnswer - 1) {
				if (left == -1) left = i;
				else right = i;
			}
		}

		afterAnswer = rand() % 2 ? left : right;

		if (hall[afterAnswer]) {
			cout << "���α׷��� �� �� " << afterAnswer + 1 << "���� �����̾����ϴ�.\n";
			if (afterAnswer == beforeAnswer) {
				winWithNoChange++;
				cout << "���α׷��� ���� �ٲ��� �ʰ� ���߾����ϴ�.\n";
			}
			else {
				winWithChange++;
				cout << "���α׷��� ���� �ٲٰ� ���߾����ϴ�.\n";
			}
		}
		else {
			cout << "Ʋ�Ƚ��ϴ�.\n";
		}
		cout << "������ " << rightAnser + 1 << "���Դϴ�.\n";
	}
	printf("�� ���� Ƚ�� : %d\n", gameTimes);
	printf("����� : %.4lf\n", (double)(winWithChange + winWithNoChange) / gameTimes);
	printf("���� �� ���� �ȹٲٰ� ���� ����� : %.4lf\n", (double)winWithNoChange / (winWithChange + winWithNoChange));
	printf("���� �� ���� �ٲٰ� ���� ����� : %.4lf\n", (double)winWithChange / (winWithChange + winWithNoChange));
	system("pause");
	return 0;
}
