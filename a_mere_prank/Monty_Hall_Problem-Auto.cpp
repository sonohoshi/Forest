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

	cout << "게임의 반복 횟수를 입력해주세요 >> ";
	cin >> gameTimes;

	for (int i = 0; i < gameTimes; i++) {
		hall[0] = hall[1] = hall[2] = false;
		int beforeAnswer;
		int afterAnswer;
		int left = -1, right = -1;

		int rightAnser = rand() % 3;
		hall[rightAnser] = true;
		// cout << "\n\n" << rightAnser + 1 << "번이 정답입니다.\n";

		// printf("left : %d, right : %d\n", left + 1, right + 1);
		cout << "1/2/3 중 랜덤으로 프로그램이 선택합니다\n";
		
		//cin >> beforeAnswer;
		beforeAnswer = rand() % 3;
		cout << "프로그램은 " << beforeAnswer + 1 << "번째를 선택했습니다." << endl;
		
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

		cout << showAnswer << "번째는 답이 아닙니다. 다시 한번 자동으로 선택합니다.\n";
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
			cout << "프로그램이 고른 답 " << afterAnswer + 1 << "번은 정답이었습니다.\n";
			if (afterAnswer == beforeAnswer) {
				winWithNoChange++;
				cout << "프로그램은 답을 바꾸지 않고 맞추었습니다.\n";
			}
			else {
				winWithChange++;
				cout << "프로그램은 답을 바꾸고 맞추었습니다.\n";
			}
		}
		else {
			cout << "틀렸습니다.\n";
		}
		cout << "정답은 " << rightAnser + 1 << "번입니다.\n";
	}
	printf("총 게임 횟수 : %d\n", gameTimes);
	printf("정답률 : %.4lf\n", (double)(winWithChange + winWithNoChange) / gameTimes);
	printf("정답 중 답을 안바꾸고 맞춘 정답률 : %.4lf\n", (double)winWithNoChange / (winWithChange + winWithNoChange));
	printf("정답 중 답을 바꾸고 맞춘 정답률 : %.4lf\n", (double)winWithChange / (winWithChange + winWithNoChange));
	system("pause");
	return 0;
}
