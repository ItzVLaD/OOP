/*
Написати програму, яка обчислює середню температуру протягом року. Створити двовимірний 
рандомний масив temperature[12,30], в якому зберігається температура для кожного дня місяця 
(передбачається, що в кожному місяці 30 днів). Згенерувати значення температури випадковим 
чином. Для кожного місяця надрукувати середню температуру. Для цього написати метод,
який за масивом temperature[12,30] для кожного місяця обчислює середню температуру в 
ньому, і як результат повертає масив середніх температур. Отриманий масив середніх 
температур відсортувати за зростанням. Завдання також виконати з допомогою класу
Dictionary<TKey, TValue>. Як ключі вибрати рядки – назви місяців, а як значення – масив
значень температур по днях
*/
using System;

class Program
{
    static class MyFile
    {
        public static string file = "C:\\WORKSPACE\\University\\PROGA\\ООП\\Lab8\\Lab8\\Lab8\\temp.txt";
        private static char[] separators = { ' ', ',', ';', '.', '\t', '\n' };
        public static void FillFile(int minTemp = -20, int maxTemp = 40)
        {
            File.WriteAllText(file, string.Empty);
            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    File.AppendAllText(file, rnd.Next(minTemp, maxTemp) + " ");                  
                }
                File.AppendAllText(file, "\n");
            }
        }
        public static string GetValueFromFile()
        {
            return File.ReadAllText(file);
        }
        public static double[,] GetArray()
        {
            string[] tokens = GetValueFromFile().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            double[,] temperature = new double[12, 30];
            int dayNum = 0;
            for (int i = 0; i < 12; i++)
            {                
                for (int j = 0; j < 30; j++)
                {
                    double number;
                    if (Double.TryParse(tokens[dayNum], out number))
                    {
                        temperature[i,j] = number;
                    }
                    dayNum++;
                }                
            }
            return temperature;
        }
    }

    static void Main(string[] args)
    {        
        string commands = "0: Закрити програму\n" +
        "1: Надрукувати температуру з файлу\n" +
        "2: Змінити температуру у файлі\n" +
        "3: Надрукувати середню температуру для кожного місяця\n" +
        "4: Надрукувати відсортований за зростанням масив середніх температур";
        Console.WriteLine(commands);
    menu: Console.Write("\nCommand: ");
        int choice = int.Parse(Console.ReadLine());
        var tempArray = MyFile.GetArray();
        Dictionary<string, double[]> monthTemperatures = new Dictionary<string, double[]>();
        for (int i = 0; i < 12; i++)
        {
            double[] monthTemperatureArray = new double[30];
            for (int j = 0; j < 30; j++)
            {
                monthTemperatureArray[j] = tempArray[i, j];
            }
            monthTemperatures.Add(GetMonthName(i), monthTemperatureArray);
        }
        switch (choice)
        {
            default:
                Console.WriteLine("Введіть правильне значення!");
                goto menu;
            case 0:
                break;
            case 1:
                for (int i = 0; i < 12; i++)
                {
                    Console.WriteLine($"Температура за {GetMonthName(i)}:");
                    for (int j = 0; j < 30; j++)
                    {
                        Console.Write(tempArray[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                goto menu;
            case 2:
                MyFile.FillFile();
                goto menu;
            case 3:                
                Console.WriteLine("Словник місяців та їх середніх температур:");
                foreach (KeyValuePair<string, double[]> kvp in monthTemperatures)
                {
                    Console.WriteLine($"{kvp.Key}: {GetAverageTemperatureForArray(kvp.Value)}");
                }
                goto menu;
            case 4:
                var sortedMonthTemperatures = monthTemperatures.OrderBy(x => GetAverageTemperatureForArray(x.Value));
                Console.WriteLine("\nСловник місяців та їх середніх температур (відсортовані за зростанням):");
                foreach (KeyValuePair<string, double[]> kvp in sortedMonthTemperatures)
                {
                    Console.WriteLine($"{kvp.Key}: {GetAverageTemperatureForArray(kvp.Value)}");
                }
                goto menu;
        }        

        static string GetMonthName(int monthIndex)
        {
            string[] months = new string[] { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень", "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень" };
            return monthIndex < 0 ? months[0] : monthIndex > 11 ? months[11] : months[monthIndex];
        }

        static double GetAverageTemperatureForArray(double[] arr)
        {
            return arr.Average();
        }
    }
}

