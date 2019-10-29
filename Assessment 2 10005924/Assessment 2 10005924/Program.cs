using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Assessment_2_10005924
{// Layton Vincent-Stewart
 // 10005924
 //Assessment 2

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch(); //Creating a stopwatch for timing Question 4
            Algorithm myArray = new Algorithm(); //Creating the original array of random doubles

            //Creating copies of the original array
            double[] findMaxCopy1 = new double[myArray.Numbers.Length]; //Array for Question 1
            Array.Copy(myArray.Numbers, findMaxCopy1, myArray.Numbers.Length);
            
            double[] findOccCopy2 = new double[myArray.Numbers.Length]; //Array for Question 2
            Array.Copy(myArray.Numbers, findOccCopy2, myArray.Numbers.Length);
            
            double[] lastOccCopy3 = new double[myArray.Numbers.Length]; //Array for Question 3
            Array.Copy(myArray.Numbers, lastOccCopy3, myArray.Numbers.Length);

            double[] bubbleCopy3 = new double[myArray.Numbers.Length]; //Array for Question 4 - Bubble Sort
            Array.Copy(myArray.Numbers, bubbleCopy3, myArray.Numbers.Length);

            double[] impBubbleCopy3 = new double[myArray.Numbers.Length]; //Array for Question 4 - Improved Bubble Sort
            Array.Copy(myArray.Numbers, impBubbleCopy3, myArray.Numbers.Length);

            Algorithm.Display(myArray.Numbers);
            Console.WriteLine();

            //Question 1 User Input
            Console.Write("How many of the largest numbers do you wish to be printed: ");
            int numLargest = Convert.ToInt32(Console.ReadLine());
            FindMaximum(findMaxCopy1, numLargest);

            //Question 2 User Input
            Console.WriteLine();
            Console.Write("Which number do you want search for: ");
            double myDouble = Convert.ToDouble(Console.ReadLine());
            Console.Write("Which occurance do you want: ");
            int myOcc = Convert.ToInt32(Console.ReadLine());
            NumFindOccurance(findOccCopy2, myDouble, myOcc);

            //Question 3 User Input
            Console.WriteLine();
            Console.Write("Enter the number you want to find the last index of: ");
            double lastDouble = Convert.ToDouble(Console.ReadLine());
            LastOccuranceSearch(lastOccCopy3, lastDouble);
            Console.WriteLine();


            //Question 4 Method Calls - No User Input Required
            Console.Write("Press any key to start the standard bubble sort: ");
            Console.ReadKey();
            Console.Clear();
          
            bubbleSort(bubbleCopy3, stopwatch);
            stopwatch.Reset();

            Console.Write("Press any key to start the improved bubble sort: ");
            Console.ReadKey();

            improvedBubbleSort(impBubbleCopy3, stopwatch);

            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
        }

        static void FindMaximum(double[] myArray, int n) //Question 1 Method
            
        {
            double[] nMax = new double[n];
            double checker = myArray[0];
            int arrIndex;

            for (int k = 0; k < n; k++)
            {
                checker = myArray[0];
                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] > checker)
                    {
                        checker = myArray[i];
                    }

                }
                nMax[k] = checker;
                arrIndex = Array.IndexOf(myArray, checker);
                myArray[arrIndex] = -11;
            }

            Algorithm.Display(nMax);

            Console.WriteLine();
        }

        static void NumFindOccurance(double[] myArray, double myDouble, int myOcc) //Question 2 Method
        {
            int i = 0;
            
            for (int k = 0; k < myArray.Length; k++)
            {
                if (myArray[k] == myDouble)
                {
                    i++;
                    if(i == myOcc)
                    {
                        Console.WriteLine($"The number {myDouble} has occurance {myOcc} at index: {k}");
                        return;
                    }

                }
            }
            Console.WriteLine($"{myDouble} doesn't have that many instances in the array");
        }

        static void LastOccuranceSearch(double[] myArray, double myDouble) //Question 3 Method
        {
            int i = 0;
            int lastOcc = 0;

            foreach(double l in myArray)
            {
                if (l == myDouble)
                {
                    lastOcc = i;
                }
                i++;
            }
            Console.WriteLine($"The last occurence of {myDouble} is: {lastOcc}");            
        }

        static void bubbleSort(double[] myArray, Stopwatch stopwatch) //Question 4 Method - Standard Bubble Sort
        {
            
            stopwatch.Start();
            //Loop to search through the array
            for (int i = 0; i < myArray.Length; i++)
            {
                
                for (int j = 0; j < myArray.Length - 1; j++)
                {
                    //checks if the current element is lower than the next
                    if (myArray[j] > myArray[j + 1])
                    {
                        double temp = myArray[j + 1];
                        myArray[j + 1] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }
            
            stopwatch.Stop();
            Algorithm.Display(myArray);

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = string.Format($"{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}");
            Console.WriteLine($"Runtime : {elapsedTime}");
            
            Console.ReadLine();
        }

        static void improvedBubbleSort(double[] myArray, Stopwatch stopwatch) //Question 4 Method - Improved Bubble Sort
        {
            stopwatch.Reset();
            stopwatch.Start();
            bool swap = true;
            
            //Loop to look through the whole array
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                swap = false;
                //Loop to look through the rest of the array and not values that have already been sorted
                for (int j = 0; j < myArray.Length - 1 - i; j++)
                {
                    //Checks to see if the next number is more or less than the current number
                    if (myArray[j] > myArray[j + 1])
                    {
                        //temp variable to swap the number locations in the array
                        double temp = myArray[j + 1];
                        myArray[j + 1] = myArray[j];
                        myArray[j] = temp;
                        
                        swap = true;
                    }
                }
                
                if (!swap)
                    break;
            }
            
            stopwatch.Stop();
            Algorithm.Display(myArray); 
            //The time for displaying the array takes longer in the improved bubble sort, not sure why
            //So I moved the display outside of the stopwatch timer to show the timing of the actual sort

            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = string.Format($"{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds}");
            Console.WriteLine($"Runtime : {elapsedTime}");

        }
    }


}
