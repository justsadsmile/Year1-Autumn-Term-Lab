#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "config.h"

#include <ctype.h>
#include <string.h>

#define MAX_LINE_LENGTH 1000
#define ALPHABET_SIZE 26

void findMostFrequentLetter(const char* line, char* resultLetter, int* resultCount) {
	int counts[ALPHABET_SIZE] = { 0 };

	for (int i = 0; line[i] != '\0'; i++) {
		char c = line[i];
		if (isalpha(c)) {
			c = tolower(c);
			counts[c - 'a']++;
		}
	}

	int maxCount = 0;
	char maxLetter = 'a';

	for (int i = 0; i < ALPHABET_SIZE; i++) {
		if (counts[i] > maxCount) {
			maxCount = counts[i];
			maxLetter = 'a' + i;
		}
	}

	if (maxCount == 0) {
		*resultLetter = '\0';
		*resultCount = 0;
		return;
	}

	*resultLetter = toupper(maxLetter);
	*resultCount = maxCount;
}

int main() {
	printf("Laboratory work 3\n");
	printf("Variant 10, %s, author %s\n", GROUP_NUMBER, NAME);

	FILE* inputFile, * outputFile;
	char line[MAX_LINE_LENGTH];

	// Open files
	inputFile = fopen("input.txt", "r");
	if (inputFile == NULL) {
		printf("Error: failed to open input.txt\n");
		return 1;
	}

	outputFile = fopen("output.txt", "w");
	if (outputFile == NULL) {
		printf("Error: failed to open output.txt\n");
		fclose(inputFile);
		return 1;
	}

	while (fgets(line, MAX_LINE_LENGTH, inputFile) != NULL) {
		size_t len = strlen(line);
		if (len > 0 && line[len - 1] == '\n') {
			line[len - 1] = '\0';
		}

		char mostFrequentLetter;
		int count;

		findMostFrequentLetter(line, &mostFrequentLetter, &count);

		if (count > 0) {
			fprintf(outputFile, "%c %d\n", mostFrequentLetter, count);
		}
		else {
			fprintf(outputFile, "No letters found\n");
		}
	}

	fclose(inputFile);
	fclose(outputFile);

	printf("Processing completed. Result written to output.txt\n");

	return 0;
}