using System;
using System.Linq;
using System.Text;

namespace Palindrome
{
    public class PalindromeChecker : IPalindromeCheck
    {
        private PalindromeChecker() { }
        private static readonly Lazy<PalindromeChecker> lazy =
            new Lazy<PalindromeChecker>(() => new PalindromeChecker());
        public static PalindromeChecker Instance { get { return lazy.Value;  } }
        
        public bool CheckPalindrome(string s)
        {
            bool IsPalindrome;
            var logger = NLog.LogManager.GetCurrentClassLogger();
            try
            {
                s = s.ToLower();

                StringBuilder StrBuilder = new StringBuilder();

                for (int i = 0; i < s.Length; i++)
                {
                    if (((s[i] >= 0) && (s[i] <=9)) || ((s[i] >= 'A') && (s[i] <= 'z')))
                        {
                        StrBuilder.Append(s[i]);
                    }
                }

                s = StrBuilder.ToString();

                string reversed = new string(s.ToCharArray().Reverse().ToArray());

                IsPalindrome = (reversed == s) ? true : false;
                return IsPalindrome;

            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                return false;
            }

        }

        public bool CheckPalindrome(int s)
        {
            return this.CheckPalindrome(s.ToString());
        }

        public bool CheckPalindrome(double s)
        {
            return this.CheckPalindrome(s.ToString());
        }

        public bool CheckPalindrome(decimal s)
        {
            return this.CheckPalindrome(s.ToString());
        }


    }
}
