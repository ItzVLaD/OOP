using System;

namespace Lab7
{
    public interface IArabic
    {
        int ArabicSum(int first, int second);
        int ArabicDiff(int first, int second);
    }

    public interface IRoman
    {
        string RomanSum(string first, string second);
        string RomanDiff(string first, string second);
    }

    public interface IWriting
    {
        string WritingSum(string first, string second);
        string WritingDiff(string first, string second);
    }


    public class Numbers: IArabic, IRoman, IWriting
    {
        private List<string> RomanNumbers = new List<string>() { "N", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", 
            "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII" };
        private List<string> WritingNumbers = new List<string>() { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
            "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen" };
        public int ArabicSum(int first, int second)
        {
            return first + second;
        }
        public int ArabicDiff(int first, int second)
        {
            return first - second;
        }

        public string RomanSum(string first, string second)
        {
            int indexA = -1, indexB = -1;
            for (int i = 0; i <= 9; i++)
            {
                if (first == RomanNumbers[i])
                    indexA = i;
                if (second == RomanNumbers[i])
                    indexB = i;
            }
            return indexA != -1 && indexB != -1 ? RomanNumbers[indexA + indexB] : "Incorrect writing of numbers!";
        }
        public string RomanDiff(string first, string second)
        {
            int indexA = -1, indexB = -1;
            for (int i = 0; i <= 9; i++)
            {
                if (first == RomanNumbers[i])
                    indexA = i;
                if (second == RomanNumbers[i])
                    indexB = i;
            }
            if (indexB > indexA)
            {
                return "Negative result!";
            }
            else
            {
                return indexA != -1 && indexB != -1 ? RomanNumbers[indexA - indexB] : "Incorrect writing of numbers!";
            }
        }

        public string WritingSum(string first, string second)
        {
            int indexA = -1, indexB = -1;
            for (int i = 0; i <= 9; i++)
            {
                if (first == WritingNumbers[i])
                    indexA = i;
                if (second == WritingNumbers[i])
                    indexB = i;
            }
            return indexA != -1 && indexB != -1 ? WritingNumbers[indexA + indexB] : "Incorrect writing of numbers!";
        }
        public string WritingDiff(string first, string second)
        {
            int indexA = -1, indexB = -1;
            for (int i = 0; i <= 9; i++)
            {
                if (first == WritingNumbers[i])
                    indexA = i;
                if (second == WritingNumbers[i])
                    indexB = i;
            }
            if (indexB > indexA)
            {
                return indexA != -1 && indexB != -1 ? "minus " + WritingNumbers[indexB - indexA] : "Incorrect writing of numbers!";
            } 
            else
            {
                return indexA != -1 && indexB != -1 ? WritingNumbers[indexA - indexB] : "Incorrect writing of numbers!";
            }           
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Numbers num = new();
            int choice;
            string a, b;
            string commands = "0: Close the program\n" +
            "1: Arabic sum\n" +
            "2: Arabic difference\n" +
            "3: Roman sum\n" +
            "4: Roman difference\n" +
            "5: Writing sum\n" +
            "6: Writing difference";
            Console.WriteLine(commands);
        menu: Console.Write("\nCommand: ");
            choice = int.Parse(Console.ReadLine());
            Console.Write("First value: ");
            a = Console.ReadLine();
            Console.Write("Second value: ");
            b = Console.ReadLine();
            switch (choice)
            {
                default:
                    Console.WriteLine("Enter a correct value!");
                    goto menu;
                case 0:
                    break;
                case 1:                   
                    Console.WriteLine("Result: " + num.ArabicSum(int.Parse(a), int.Parse(b)));
                    goto menu;                   
                case 2:                 
                    Console.WriteLine("Result: " + num.ArabicDiff(int.Parse(a), int.Parse(b)));
                    goto menu;
                case 3:                    
                    Console.WriteLine("Result: " + num.RomanSum(a, b));
                    goto menu;
                case 4:                    
                    Console.WriteLine("Result: " + num.RomanDiff(a, b));
                    goto menu;
                case 5:
                    Console.WriteLine("Result: " + num.WritingSum(a, b));
                    goto menu;
                case 6:
                    Console.WriteLine("Result: " + num.WritingDiff(a, b));
                    goto menu;
            }
        }
    }
}