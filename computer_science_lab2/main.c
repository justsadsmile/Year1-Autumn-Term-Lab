#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h> 
#include <time.h>  
#include "config.h"

int GetMaxEvenNonZeroNumber(int array[], int n) {
	int maxEvenNonZero = 0;
	for (int i = 0; i < n; i++) {
		if (maxEvenNonZero != 0 && maxEvenNonZero < array[i] && array[i] % 2 == 0) {
			maxEvenNonZero = array[i];
		}
		else if (maxEvenNonZero == 0 && array[i] % 2 == 0) {
			maxEvenNonZero = array[i];
		}
	}
	return maxEvenNonZero;
}

int GetFirstOddMultipleByNumber(int array[], int n) {
	int running = 0; // bool
	int indexFirstOdd = 0;

	int numbers = 0;
	while (numbers == 0) {
		printf("Enter the number: ");
		scanf("%d", &numbers);
		if (n == 0) {
			printf("Cannot be divided by 0 \n");
		}
	}

	int j = 0;
	while (running == 0 && j < n) {
		if (array[j] % 2 != 0 && array[j] % numbers == 0) {
			indexFirstOdd = j;
			running = 1;
		}
		j++;
	}
	if (running != 0) {
		return indexFirstOdd;
	}
	else {
		return 2;
	}
}

int main(void) {
	printf("Laboratory work 2\n");
	printf("Variant 13, %s, author %s\n", GROUP_NUMBER, NAME);

	srand(time(NULL));
	//
	printf("===== Array =====\n");

	int n;
	printf("Enter array size: ");
	scanf("%d", &n);

	int* array = (int*)malloc(n * sizeof(int));
	if (array == NULL) {
		fprintf(stderr, "Failed to allocate memory!\n");
		return 1;
	}

	if (n <= 4) {
		for (int i = 0; i < n; i++) {
			printf("Enter array[%d]: ", i);
			scanf("%d", &array[i]);
		}
	}
	else {
		for (int i = 0; i < n; i++) {
			array[i] = rand() % 1000;
		}
	}
	if (n <= 10) {
		for (int i = 0; i < n; i++) {
			printf("%d ", array[i]);
		}
		printf("\n");
	}
	else {
		printf("Cannot print because array length is greater than 10\n");
	}
	// ===== 1 =====
	printf("\n===== 1 =====\n");

	int maxEvenNonZero = GetMaxEvenNonZeroNumber(array, n);

	if (maxEvenNonZero != 0) {
		printf("Max even non-zero numbers in the array: %d\n", maxEvenNonZero);
	}
	else {
		printf("There are no even non-zero numbers in the array\n");
	}
	//===== 2 =====
	printf("\n===== 2 =====\n");
	int indexFirstOdd = GetFirstOddMultipleByNumber(array, n);
	if (indexFirstOdd != 2) {
		printf("Index of the first odd element that is a multiple of a given number: %d\n", indexFirstOdd);
	}
	else {
		printf("There are no odd elements that are multiples of a given number\n");
	}
	//
	free(array);
	return 0;
}

