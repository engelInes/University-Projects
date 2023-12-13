#include <stdio.h>


void decompose_into_prime_numbers(int numberToDecompose)
{
    int divisor = 2;
    int powerOfDivisor =0;
    while (numberToDecompose > 1)
    {
        powerOfDivisor = 0;
        while (numberToDecompose % divisor == 0)
        {
            powerOfDivisor++;
            numberToDecompose = numberToDecompose /divisor;
        }
        if (powerOfDivisor)
        {
            printf("%d,%d", divisor, powerOfDivisor);
            printf("\n");
        }
        divisor++;
        if (numberToDecompose > 1 && divisor * divisor > numberToDecompose)
        {
            divisor = numberToDecompose;
        }
            
    }
}

int longest_subsequence_of_elements_with_same_digits(int sequence[1001], int lenghtOfSequence)
{
    int lenghtOfSubsequence = 1;
    int maxLenghtOfSubsequence = 0;
    for (int i = 0; i < lenghtOfSequence -1; i++)
    {
        if (check_if_same_digits(sequence[i], sequence[i + 1]) == 1)
        {
            lenghtOfSubsequence++;
        }
        else
        {
            lenghtOfSubsequence = 1;
        }
        if (lenghtOfSubsequence > maxLenghtOfSubsequence)
            maxLenghtOfSubsequence = lenghtOfSubsequence;
    }
    return maxLenghtOfSubsequence;
}

int check_if_same_digits(int firstNumber, int secondNumber)
{
    int frequency_Vector_For_First_number[10] = { 0 };
    int frequency_Vector_For_Second_Number[10] = { 0 };
    while (firstNumber)
    {
        frequency_Vector_For_First_number[firstNumber % 10]++;
        firstNumber = firstNumber / 10;
    }
    while (secondNumber)
    {
        frequency_Vector_For_Second_Number[secondNumber % 10]++;
        secondNumber = secondNumber / 10;
    }
    int haveTheSameDigits = 1;
    for (int i = 0; i <= 9; i++)
    {
        if (frequency_Vector_For_First_number[i] != frequency_Vector_For_Second_Number[i])
        {
            haveTheSameDigits = 0;
            break;
        }

    }
    return haveTheSameDigits;
}

void print_menu()
{
    printf("%s\n", "1. Read a vector of numbers from the console");
    printf("%s\n", "2. Decompose a number in its prime factors");
    printf("%s\n", "3. Find the longest subsequence such that any consecutive elements contain the same digits");
    printf("%s\n", "4. Exit the program");

}

void run_menu()
{
    int run_program = 1;
    while (run_program)
    {
        print_menu();
        printf("Choose an option: ");
        int inputOption;
        int inputLenght;
        scanf("%d", &inputOption);
        if (inputOption == 1)
        {
            printf("Enter the lenght of the vector: ");
            scanf("%d", &inputLenght);
            printf("\nEnter the elements of the vector: ");
            int vector_of_numbers_from_console[100];
            for (int i = 0; i < inputLenght; i++)
            {
                scanf("%d", &vector_of_numbers_from_console[i]);
            }
            for (int i = 0; i < inputLenght; i++)
            {
                printf("%d", vector_of_numbers_from_console[i]);
                printf(" ");
            }
            printf("\n");
        }
        else if (inputOption == 2)
        {
            printf("Enter the number you want to decompose: ");
            int number_to_decompose;
            scanf("%d", &number_to_decompose);
            decompose_into_prime_numbers(number_to_decompose);
            printf("\n");
        }
        else if (inputOption == 3)
        {
            printf("Enter the lenght of the sequence for which you want to use the functionality to: ");
            int sequenceLenght;
            scanf("%d", &sequenceLenght);
            printf("\nEnter the elements of the sequence: ");
            int sequence_of_numbers_from_console[100];
            for (int i = 0; i < sequenceLenght; i++)
            {
                scanf("%d", &sequence_of_numbers_from_console[i]);
            }
            printf("%d\n", longest_subsequence_of_elements_with_same_digits(sequence_of_numbers_from_console, sequenceLenght));
            printf("\n");
        }
        else if (inputOption == 4)
            break;
        else
        {
            printf("Invalid option");
            break;
        }
    }
}
int main()
{
    run_menu();
	getchar();
}