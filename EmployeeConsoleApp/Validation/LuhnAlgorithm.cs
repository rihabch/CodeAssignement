using System;
using System.Linq;

namespace EmployeeConsoleApp.Validation
{
    public static class LuhnAlgorithm
    {
        public static bool Check(string ccNumber)
        {
            int sum = 0;
            bool alternate = false;
            for (int i = ccNumber.Length - 1; i >= 0; i--)
            {
                char[] nx = ccNumber.ToArray();
                int n = int.Parse(nx[i].ToString());

                if (alternate)
                {
                    n *= 2;

                    if (n > 9)
                    {
                        n = (n % 10) + 1;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0);
        }
    }
}
