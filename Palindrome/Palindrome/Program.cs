using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserInput;
            Console.WriteLine("Please input a string.");
            UserInput = Console.ReadLine();

            bool isPalin = PalindromeChecker.Instance.CheckPalindrome(UserInput);
            Console.WriteLine("");
            if (isPalin)
            {
                Console.WriteLine("It is a palindrome.");
            }
            else { Console.WriteLine("It is not a palindrome."); }


        }
    }
}
