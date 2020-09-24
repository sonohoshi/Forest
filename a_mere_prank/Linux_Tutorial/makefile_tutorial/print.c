#include<stdio.h>
void printfile(char* file){
	char c;
	FILE* f = fopen(file, "r");
	c = fgetc(f);
	while (c != EOF) {
      printf("%c",c);
	  c = fgetc(f);
    }
	printf("\n");
	fclose(f);
}