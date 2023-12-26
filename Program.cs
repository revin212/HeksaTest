using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeksaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool validated = false;
            string password = "";
            while (!validated)
            {
                Console.Write("Enter password : ");
                password = Console.ReadLine();
                validated = validatePassword(password);
                Console.WriteLine(validated);
                Console.ReadKey();
            }

            int target = 7;
            var inputList = new List<int> { 1, 2, 3, 4 };
            var result = SumOfTwo(inputList, target);
            if (result.GetType() == typeof(string))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.Write("[");
                for (int i = 0; i < 2; i++)
                {
                    Console.Write(result[i]);
                    if (i == 0)
                        Console.Write(", ");
                }
                Console.Write("]");
            }
            Console.ReadKey();
        }

        static bool validatePassword(string password)
        {
            string regex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*[`~_!@/(/)#$%^&*-//?.>,<'/=/+;:]).{8,}$";
            regex = regex.Substring(0, regex.Length - 8) + '"' + regex.Substring(regex.Length - 8);
            if (Regex.IsMatch(password, regex))
                return true;
            return false;
        }

        static dynamic SumOfTwo(List<int> inputList, int target)
        {
            var numDic = new Dictionary<int, int>();
            for(int i=0; i < inputList.Count; i++)
            {
                if(numDic.ContainsKey(target-inputList[i]))
                {
                    return new List<int> { i, numDic[target - inputList[i]] };
                }
                numDic[inputList[i]] = i;
            }
            return "None";
        }
    }
}
