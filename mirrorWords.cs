using System.Text.RegularExpressions;

namespace softUniFund_FinalExamPrep1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regex = @"([@#])(?<str1>[A-Za-z]{3,})\1{2}(?<str2>[A-Za-z]{3,})\1";
            var str = Console.ReadLine();

            List<string> mirrorWords = new List<string>();
            MatchCollection mc = Regex.Matches(str, regex);
            foreach(Match m in mc)
            {
                string str1 = m.Groups["str1"].Value;
                string str2 = m.Groups["str2"].Value;

                string str2Reversed = "";
                for(int i = str2.Length - 1; i >= 0; i--)
                {
                    str2Reversed += str2[i];
                }
                if(str1 == str2Reversed) mirrorWords.Add($"{str1} <=> {str2}");
            }
            if(mc.Count > 0) Console.WriteLine($"{mc.Count} word pairs found!");
            else Console.WriteLine("No word pairs found!");

            if(mirrorWords.Count == 0) Console.WriteLine("No mirror words!");
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}