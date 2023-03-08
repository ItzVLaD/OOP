using System;

namespace Lab6
{
    static class FirstDimenshion
    {
        static int size;
        static Random random = new Random();

        private static void SetSize()
        {
            Console.Write("Enter a size of array: ");
            size = Convert.ToInt16(Console.ReadLine());
            if (size == 0)
                size = 2;
            if (size < 0)
                size = -size;
        }

        private static void FillArrayRandomly(int[] arr, int min = 0, int max = 2)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(min, max);
            }
        }

        private static void PrintArray(int[] arr, string header)
        {
            Console.WriteLine(header);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.WriteLine("");
        }

        private static void SwapElements(int[] arr, int firstIndex, int secondIndex)
        {
            int temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        public static void FirstTask()
        {
            SetSize();
            int[]arr = new int[size];
            FillArrayRandomly(arr, -10, 11);
            PrintArray(arr, "Your array:");
            int num = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    num = i; 
                    break;
                }
            }
            int amount = 0;
            if (num != -1)
            {
                for (int i = num; i < arr.Length; i++)
                {
                    if (arr[i] < 0)
                    {
                        amount++;
                    }
                }
            }
            Console.WriteLine("Amount of negative elements: " + amount);
        }

        public static void SecondTask()
        {
            SetSize();
            int[] a = new int[size];
            int[] b = new int[size];
            int[] c = new int[size];
            FillArrayRandomly(a, -10, 11);
            FillArrayRandomly(b, -10, 11);
            FillArrayRandomly(c, -10, 11);
            PrintArray(a, "Array a:");
            PrintArray(b, "Array b:");
            PrintArray(c, "Array c:");
            for(int i = 0; i < c.Length; i++)
            {
                c[i] = a[i] - 3 * b[i] + 2 * c[i];
            }
            PrintArray(c, "Result:");
        }

        public static void ThirdTask()
        {
            SetSize();
            int[] arr = new int[size];
            FillArrayRandomly(arr, -1, 2);
            PrintArray(arr, "Your array:");
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = arr.Length - 2; j >= 0; j--)
                {
                    if (arr[j] == 0)
                    SwapElements(arr, j, j + 1);
                }
            }
            PrintArray(arr, "Sorted array:");
        }
    }

    static class SecondDimenshion
    {
        static int size;
        static Random random = new Random();

        private static void SetSize()
        {
            Console.Write("Enter a size of array: ");
            size = Convert.ToInt16(Console.ReadLine());
            if (size == 0)
                size = 2;
            if (size < 0)
                size = -size;
        }

        private static void FillArrayRandomly(double[,] arr, int min, int max)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = random.Next(min, max);
                }
            }
        }

        private static void PrintArray(double[,] arr, string header)
        {
            Console.WriteLine(header);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        private static void SwapElements(double[,] arr, int firstIndexX, int firstIndexY, int secondIndexX, int secondIndexY)
        {
            double temp = arr[firstIndexX, firstIndexY];
            arr[firstIndexX, firstIndexY] = arr[secondIndexX, secondIndexY];
            arr[secondIndexX, secondIndexY] = temp;
        }

        private static void Smoothing(double[,] arr, int round = 2)
        {
            if (size > 1)
            {
                //Лівий верхній кут
                arr[0, 0] =
                    (arr[0, 1] +
                    arr[1, 0] + arr[1, 1])
                    / 3;
                if (size > 2)
                {
                    //Верхній рядок
                    for (int j = 1; j < arr.GetLength(0) - 1; j++)
                    {
                        arr[0, j] =
                            (arr[0, j - 1] + arr[0, j + 1] +
                            arr[1, j - 1] + arr[1, j] + arr[1, j + 1])
                            / 5;
                    }
                }
                //Правий верхній кут
                arr[0, arr.GetLength(1) - 1] =
                    (arr[0, arr.GetLength(1) - 2] +
                    arr[1, arr.GetLength(1) - 2] + arr[1, arr.GetLength(1) - 1])
                    / 3;
                if (size > 2)
                {
                    //Тіло масиву
                    for (int i = 0; i < arr.GetLength(0) - 2; i++)
                    {
                        //Перший елемент в рядку
                        arr[i + 1, 0] =
                            (arr[i, 0] + arr[i, 1] +
                            arr[i + 1, 1] +
                            arr[i + 2, 0] + arr[i + 2, 1])
                            / 5;
                        //Інші елементи рядка
                        for (int j = 0; j < arr.GetLength(1) - 2; j++)
                        {
                            arr[i + 1, j + 1] =
                                (arr[i, j] + arr[i, j + 1] + arr[i, j + 2] +
                                arr[i + 1, j] + arr[i + 1, j + 2] +
                                arr[i + 2, j] + arr[i + 2, j + 1] + arr[i + 2, j + 2]) / 8;
                        }
                        //Останній елемент в рядку
                        arr[i + 1, arr.GetLength(1) - 1] =
                            (arr[i, arr.GetLength(1) - 2] + arr[i, arr.GetLength(1) - 1] +
                            arr[i + 1, arr.GetLength(1) - 2] +
                            arr[i + 2, arr.GetLength(1) - 2] + arr[i + 2, arr.GetLength(1) - 1])
                            / 5;
                    }
                }
                //Лівий нижній кут
                arr[arr.GetLength(0) - 1, 0] =
                    (arr[arr.GetLength(0) - 2, 0] + arr[arr.GetLength(0) - 2, 1] +
                    arr[arr.GetLength(0) - 1, 1])
                    / 3;
                if (size > 2)
                {
                    //Нижній рядок
                    for (int j = 1; j < arr.GetLength(0) - 1; j++)
                    {
                        arr[arr.GetLength(0) - 1, j] =
                            (arr[arr.GetLength(0) - 2, j - 1] + arr[arr.GetLength(0) - 2, j] + arr[arr.GetLength(0) - 2, j + 1] +
                            arr[arr.GetLength(0) - 1, j - 1] + arr[arr.GetLength(0) - 1, j + 1])
                            / 5;
                    }
                }
                //Правий нижній кут
                arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1] =
                    (arr[arr.GetLength(0) - 2, arr.GetLength(1) - 2] + arr[arr.GetLength(0) - 2, arr.GetLength(1) - 1] +
                    arr[arr.GetLength(0) - 1, arr.GetLength(1) - 2])
                    / 3;
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = Math.Round(arr[i, j], round);
                }
            }
        }

        public static void FirstTask()
        {
            SetSize();
            double[,] arr = new double[size, size];
            FillArrayRandomly(arr, -10, 11);
            PrintArray(arr, "Your array:");
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < arr.GetLength(1) - 1; j++)
                {
                    if (arr[j, j] > arr[j + 1, j + 1])
                    {
                        SwapElements(arr, j, j, j + 1, j + 1);
                    }
                }
            }
            PrintArray(arr, "Sorted array:");
        }
        public static void SecondTask()
        {
            SetSize();
            double[,] arr = new double[size, size];
            FillArrayRandomly(arr, -10, 11);
            PrintArray(arr, "Your array:");
            Smoothing(arr);
            PrintArray(arr, "Smoothed:");
        }
        public static void ThirdTask()
        {
            SetSize();
            double[,] arr = new double[size, size];
            FillArrayRandomly(arr, -10, 11);
            PrintArray(arr, "Your array:");
            Smoothing(arr);
            PrintArray(arr, "Smoothed:");
            double sum = 0;
            /*for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                sum += Math.Abs(arr[i + 1, i]);
            }*/
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j)
                        break;
                    sum += Math.Abs(arr[i, j]);
                }
            }
            sum = Math.Round(sum, 2);
            Console.WriteLine("Sum = " + sum);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            /*FirstDimenshion.FirstTask();
            FirstDimenshion.SecondTask();
            FirstDimenshion.ThirdTask();*/
            SecondDimenshion.FirstTask();
            SecondDimenshion.SecondTask();
            SecondDimenshion.ThirdTask();
        }
    }
}