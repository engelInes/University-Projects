// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

class largest3DigitPalindrome
{
    private static void Main()
    {
        int checkIfPalindrome(int numberToCheck)
        {
            int copyOfNumber = numberToCheck;
            int inverseNumber = 0;
            while (numberToCheck!=0)
            {
                inverseNumber = inverseNumber * 10 + (numberToCheck%10);
                numberToCheck = numberToCheck / 10;
            }
            if (inverseNumber == copyOfNumber)
            {
                return 1;
            }
            return 0;
        }

        int max3DigitNumbers()
        {
            int maximumNumber = -1;
            for(int index1=900; index1<=999; index1++)
            {
                for(int index2=index1+1; index2<= 999; index2++)
                {
                    int productOfNumbers = index1 * index2;
                    if (checkIfPalindrome(productOfNumbers) == 1)
                    {
                        if (productOfNumbers > maximumNumber)
                        {
                            maximumNumber = productOfNumbers;
                        }
                    }
                }
            }
            return maximumNumber;
        }
        Console.WriteLine("The largest palindrome made from the product of 2 3-digit numbers is: "+ max3DigitNumbers());
    }
}
