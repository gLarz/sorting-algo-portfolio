using System;
using System.Linq;

namespace NumberSortingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Typewrite(string message)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    Console.Write(message[i]);
                    System.Threading.Thread.Sleep(60);
                }

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Typewrite("Welcome to Sorting Algorithms\n\n");

            // user input
            Console.ForegroundColor = ConsoleColor.White;
            Typewrite("Enter numbers separated by spaces: ");
            int[] numbers = Console.ReadLine()
                                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            // sorting algorithms
            Console.WriteLine("Choose the sorting algorithm:");
            Typewrite("1) Buble Sort\n");
            Typewrite("2) Selection Sort\n");
            Typewrite("3) Quick Sort\n");
            Console.Write("Enter your choice (1, 2, or 3): ");
            int choice = int.Parse(Console.ReadLine());

            // sorting based on user selections
            switch (choice)
            {
                case 1:
                    BubbleSort(numbers);
                    break;
                case 2:
                    SelectionSort(numbers);
                    break;
                case 3:
                    QuickSort(numbers, 0, numbers.Length - 1);
                    break;
                default:
                    Console.WriteLine("Incorrect choice");
                    return;
            }

            // output type
            Console.WriteLine("Choose output type:");
            Typewrite("1) Ascending\n");
            Typewrite("2) Descending\n");
            Typewrite("3) Zigzag\n");
            Console.Write("Enter your choice (1, 2, or 3): ");
            int outputType = int.Parse(Console.ReadLine());

            // output of the sorted array from the user choice
            switch (outputType)
            {
                case 1:
                    PrintArray(numbers, "Ascending Order:");
                    break;
                case 2:
                    PrintArray(numbers.Reverse().ToArray(), "Descending Order:");
                    break;
                case 3:
                    PrintZigzag(numbers);
                    break;
                default:
                    Console.WriteLine("Incorrect choice");
                    break;
            }
        }

        // bubble sort
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // selection sort
        static void SelectionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[minIndex] > array[j])
                        minIndex = j;
                }
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }

        // quick sort
        static void QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pi = Partition(array, start, end);
                QuickSort(array, start, pi - 1);
                QuickSort(array, pi + 1, end);
            }
        }

        static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int i = start - 1;
            for (int j = start; j < end; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            
            int temP = array[i + 1];
            array[i + 1] = array[end];
            array[end] = temP;
            return i + 1;
        }

        // print array elements
        static void PrintArray(int[] array, string message)
        {
            Console.WriteLine(message);
            foreach (var num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        // print array elements but in zigzag
        static void PrintZigzag(int[] array)
        {
            Console.WriteLine("Zigzag Order:");
            int n = array.Length;
            int[] zigzag = new int[n];
            int front = 0, rear = n - 1;
            bool flag = true;

            for (int i = 0; i < n; i++)
            {
                if (flag)
                    zigzag[i] = array[rear--];
                else
                    zigzag[i] = array[front++];
                flag = !flag;
            }

            foreach (var num in zigzag)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}

