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
		cout << "1/2/3 중 정답이라고 생각되는 것을 입력해주세요 >> ";
		
		cin >> beforeAnswer;
		beforeAnswer -= 1;
		
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

		cout << (hall[left] ? right + 1 : left + 1) << "번째는 답이 아닙니다. 다시 한번 입력해주세요.\n";
		cin >> afterAnswer;
		afterAnswer -= 1;
		if (hall[afterAnswer]) {
			cout << "축하합니다. 정답입니다.\n";
			if (afterAnswer == beforeAnswer) winWithNoChange++;
			else winWithChange++;
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
	return 0;
}
