#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "config.h"



int Function(int n) {
	if (n < 2) {
		return 1;
	}

	if (n % 2 == 0) {
		return Function(n / 2) + 1;
	}
	else{
		return Function(n - 1) + n;
	}
}

int First1() {
	int target = 19;
	for (int i = 1; ; i++) {
		int result = Function(i);
		if (result == target) {
			return i;
		}
	}
}

int First2(int x) {
	int fx = Function(x);

	if (fx == 0) {
		return 1; // 0 / 3 = 3(count = 1)
	}

	int count = 0;

	while (fx > 0) {
		int digit = fx % 10;
		if (digit % 3 == 0) {
			count++;
		}
		fx /= 10;
	}
	return count;
}

int Second() {

}

int GetInt(char text[]) {
	printf("%s", text);
	int x;
	scanf("%d", &x);
	return x;
}

int main() {
	printf("Laboratory work 4\n");
	printf("Variant 7, %s, author %s\n", GROUP_NUMBER, NAME);

	//1
	printf("\n===== 1 =====\n");
	int n1 = First1();
	printf("Minimal n, F(n) = 19: %d\n", n1);

	int x = GetInt("Enter x: ");
	int n2 = First2(x);
	printf("Number of digits multiple of 3 in F(%d): %d\n", x, n2);

	//2
	printf("\n===== 2 =====\n");


	return 0;
}