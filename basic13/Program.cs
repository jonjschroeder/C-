using System;

namespace basic13
{
    class Program
    {
        //Prints values 1 through 255 to the console
        public static void Print1to255() {
            for(int val=1; val <= 255; val++) {
                Console.WriteLine(val);
            }
        }
        public static void PrintOdd1to255() {
            for(int val = 1; val<=255; val++){
                if(val % 2 == 1){
                    System.Console.WriteLine(val);
                }

            }
        }
// Given an array X, say [1,3,5,7,9,13], write a program that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.
        public static void PrintSum(){
            int sum = 0;
            for(int val = 0; val<=255; val++){
                sum += val;
                System.Console.WriteLine("New Number: " + val + " Sum: " + sum);
            }
        }
       public static void IterateArray(int[] arr){
           string output = "[";
           for(int x = 0; x<arr.Length; x++){
                output += arr[x] + ", ";
           }
           output += "]";
           System.Console.WriteLine(output);

       }
       public static void FindMax(int[] arr){
           int max = arr[0];
           for(int x = 1; x<arr.Length; x++){
               if(max<arr[x]){
                   max = arr[x];

               }
               
           }
           System.Console.WriteLine("The max value is {0}", max);
       }
       public static void FindAverage(int[] arr){
           int sum = 0;
           for(int x = 0; x<arr.Length; x ++){
               sum += arr[x];
            //    System.Console.WriteLine(sum);
           }
           System.Console.WriteLine(sum/arr.Length);
           
       }
       public static void FindOddArray(int[] arr){
           for(int x = 0; x<arr.Length; x++){
               if(arr[x]%2==1){
                   System.Console.WriteLine(arr[x]);
               }
           }
       }
        public static void Main(string[] args)
        {
            Print1to255();
            PrintOdd1to255();
            PrintSum();
            int[] myArr = new int[6] {7,4,3456,098,57,3667};
            IterateArray(myArr);
            FindMax(myArr);
            FindAverage(myArr);
            FindOddArray(myArr);
        }
    }
}
