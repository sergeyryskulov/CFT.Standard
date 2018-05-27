using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {



        static void Main(string[] args)
        {
            string oldFile = "D:/vk/26.05.2017/86.html";
            string newFile = "D:/vk/18.06.2017/86.html";

            var numbersOld = GetNumbers(oldFile);
            var numbersNew = GetNumbers(newFile);
            numbersNew.RemoveAll(m => numbersOld.Contains(m));
            foreach (var numberDiff in numbersNew)
            {
                Console.WriteLine(numberDiff);
                File.AppendAllText(newFile + "_diff.txt", numberDiff + "\r\n");
            }            

        }
      
        private static List<string> GetNumbers(string fileName )
        {
            string responseString = File.ReadAllText(fileName);
            string beginStr = "<a href=\"";
            string endString = "\" onclick=\"return nav.go(this, event);";
            int startIndex = responseString.IndexOf(beginStr);
            List<string> numbers = new List<string>();
            while (startIndex != -1)
            {
                int endIndex = responseString.IndexOf(endString, startIndex);
                if (endIndex == -1)
                {
                    break;
                }                                
                string foundString = responseString.Substring(startIndex + beginStr.Length, endIndex-startIndex - beginStr.Length);
                if (foundString.Contains("<") || foundString.Contains(">"))
                {
                    startIndex = responseString.IndexOf(beginStr, startIndex + 1);
                    continue;
                }
                if (!numbers.Contains(foundString))
                {
                    numbers.Add(foundString);
                }
                startIndex = responseString.IndexOf(beginStr, startIndex + 1);
            }
            return numbers;
        }
    }
}
