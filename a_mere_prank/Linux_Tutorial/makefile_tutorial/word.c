#include <stdio.h>
void wc(char* file){
	char c;
	int cCnt, wCnt, lCnt;
	cCnt = wCnt = 0;
	lCnt = 1;
	FILE* f = fopen(file, "r");
	c = fgetc(f);
	while (c != EOF) {
      if(c == ' ') wCnt++;
	  if(c == '\n') {
		  lCnt++;
		  wCnt++;
	  }
	  cCnt++;
	  c = fgetc(f);
    }
	printf("Char : %d, Word : %d, Line : %d\n",cCnt,wCnt,lCnt);
	fclose(f);
}