#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "config.h"
#include <math.h>

#define ROUND_TO_DECIMAL(value, decimals) (round((value) * pow(10, decimals)) / pow(10, decimals))

int Function(int n) {
	if (n < 2) {
		return 1;
	}

	if (n % 2 == 0) {
		return Function(n / 2) + 1;
	}
	else {
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
	printf("%d\n", fx);//show func

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

double DoubleFactorial(int n) {
	if (n < 0) {
		return 0;
	}
	if (n == 0 || n == 1) {
		return 1;
	}
	return DoubleFactorial(n - 2) * n;
}//with int only 0!! to 19!!

double SumOriginalFunction(int N, double x) {
	double sum = 0;

	for (int n = 1; n <= N; n++) {
		double numerator = 2 * n * pow(x, 2 * n + 1);
		double denominator = DoubleFactorial(2 * n + 1);
		double term = numerator / denominator;
		sum += term;
	}
	return sum;
}

double SumRecurrentFunction(int N, double x) {
	if (N < 1) return 0;

	double a_n = (2 * pow(x, 3)) / 3.0;
	double sum = a_n;

	for (int n = 1; n < N; n++) {
		a_n = a_n * (pow(x, 2) * (n + 1)) / (n * (2 * n + 3));
		sum += a_n;
	}
	return sum;
}

int GetInt(char text[]) {
	printf("%s", text);
	int x;
	scanf("%d", &x);
	return x;
}

double GetDouble(char text[]) {
	printf("%s", text);
	double x;
	scanf("%lf", &x);
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

	int secondN = GetInt("Enter N: ");
	double secondX = GetDouble("Enter x: ");

	double sumOriginal = SumOriginalFunction(secondN, secondX);
	double sumRecurrent = SumRecurrentFunction(secondN, secondX);

	sumOriginal = ROUND_TO_DECIMAL(sumOriginal, 6);
	sumRecurrent = ROUND_TO_DECIMAL(sumRecurrent, 6);

	printf("Original:  %f\n", sumOriginal);
	printf("Recurrent: %f\n", sumRecurrent);

	if (sumOriginal == sumRecurrent) {
		printf("Both sums are equal");
	}
	else {
		printf("Both sums are NOT equal");
	}

	return 0;
}