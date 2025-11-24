#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>
#include "config.h"

int main(void)
{
    printf("Laboratory work 1\n");
    printf("Variant 1, %s, author %s\n", GROUP_NUMBER, NAME);
    //
    printf("\n===== Task 1 =====\n");
    printf("Given two positive numbers. Find their sum and product.\n");

    int a;
    printf("Enter number a: ");
    scanf("%d", &a);

    int b;
    printf("\nEnter number b: ");
    scanf("%d", &b);

    int sumAB;
    sumAB = a + b;
    int multiAB;
    multiAB = a * b;

    printf("\nSum of numbers: %d\n", sumAB);
    printf("Product of numbers: %d\n", multiAB);

    //
    printf("\n===== Task 2 =====\n");
    printf("Given distance in meters. Convert to feet.\n");

    double lengthInMetr;
    printf("Enter distance in meters: ");
    scanf("%lf", &lengthInMetr);

    double lengthInFeet;
    lengthInFeet = lengthInMetr * 3.28084;

    printf("\nDistance in feet: %f\n", lengthInFeet);

    //
    printf("\n===== Task 3 =====\n");
    printf("Given a three-digit number. The first left digit was crossed out and appended to the right. Output the resulting number.\n");

    int number3;
    char checking = 0;
    do {
        printf("Enter a three-digit number: ");
        scanf("%d", &number3);
        if (number3 >= 100 && number3 <= 999)
            checking = 1;
    } while (checking == 0);

    int firstNumberLeft;
    firstNumberLeft = number3 / 100;

    int otherNumber;
    otherNumber = number3 % 100;

    printf("\n%d%d\n", otherNumber, firstNumberLeft);

    //
    double x;
    printf("\n===== Task 4 =====\n");
    printf("Find the value of two given functions at given point x.\n");

    printf("Enter number x: ");
    scanf("%lf", &x);

    double func1;
    double func2;
    func1 = log(x + sqrt(1 + pow(x, 2)));
    func2 = x * atan(x) - log(1 + pow(x, 2));

    printf("\nFunction 1 result: %lf\n", func1);
    printf("\nFunction 2 result: %lf\n", func2);

    return 0;
}