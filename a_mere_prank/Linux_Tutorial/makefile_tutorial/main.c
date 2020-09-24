#include <stdio.h>
#include "print.c"
#include "word.c"

int main(int argc, char* argv[]) {
	for(int i=1;i<argc;i++){
		printfile(argv[i]);
		wc(argv[i]);
	}

	return 0;
}