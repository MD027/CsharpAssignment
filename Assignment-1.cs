
// TASK1:APPPLICATION CALCULATOR.
using System;
namespace MyApplication
{
    class Program
    {
        static void Main (string[] args)


        {
            Console.WriteLine("Select Task You Want To Perfrom");
            Console.WriteLine("Press 1 For Addition \n" +
                "Press 2 For Subtraction \n" +
                "Press 3 For Multiplication \n" +
                "Press 4 For Division \n"
                );
            int task = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine("Enter a FirstNumber");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a SecondNumber");
            int n2 = Convert.ToInt32(Console.ReadLine());

            double answer = 0;
           if(task>0  && task < 5) {
                switch (task)
                {
                    case 1:
                        {
                            answer = n1 + n2;
                            break;
                        }
                    case 2:
                        {
                            answer = n1 - n2;
                            break;
                        }
                    case 3:
                        {
                            answer = n1 * n2;
                            break;
                        }
                    case 4:
                        {
                            answer = n1 / (double)n2;
                            break;
                        }

                    default:
                        Console.WriteLine("Please Enter Correct digit");
                        break;
                }

                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("Choose Correct choice");
            }
                 }
       }
  }
  
  
  
 // TASK2:AVERAGE MARK OF FIVE STUDENT .DISPLAY HIGHEST MARKS OBATAINED.
using System;
using System.Linq;
namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
          double sum = 0, avg = 0;
            Console.WriteLine("Number Of Marks You Want Enter");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] marks = new double[n];
           for (int i = 0; i<marks.Length; i++)
            {
                Console.WriteLine("Number{0}", i + 1);
               
                marks[i] = Convert.ToDouble(Console.ReadLine());

                sum = sum + marks[i];
                
                
            }
           avg = sum / n;
            Console.WriteLine("The Average Is:"+ avg);
            Console.WriteLine(marks.Max());
          
        }
}
}

// TASK3:USE PARAMS KEYWORD AND PRINT SUM OF INTEGER.
using System;

namespace MyApplication
{
    class Client
    {
        public static int add(params int[] nums)
        {
            int sum = 0;
            foreach (int i in nums)
            {
                sum+=i;
              
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Number Of Integer You Want Enter");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] integeres = new int[n];
            for (int i = 0; i < integeres.Length; i++)
            {
                Console.WriteLine("Number{0}", i + 1);
                integeres[i] = Convert.ToInt32(Console.ReadLine());

                

            }
            int sum = 0;
            sum = Client.add(integeres);
            Console.WriteLine("Total Sum is "+sum);



        }

        
    }
}


// TASK 4:SWAP NUMBERS 

using System;

namespace MyApplication
{
     class SwapEx
    {
        public static void Swaping(int n1, int n2) {
            int temp;
            temp = n1;
            n1 = n2;
            n2 = temp;
            Console.WriteLine("After Swapping");
            Console.WriteLine("First Number is " + n1 + " Second Number Is " + n2);

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter First Number");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before Swapping");
            Console.WriteLine(" First Number is " + n1 + " Second Number Is " +  n2);

            Swaping(n1, n2);
            
        }
    }
      
}



// TASK 5:FIND AREA AND CIRCUMFERENCE

using System;

namespace MyApplication
{
     class Circle
    {
        public static void find(int r)
        {

            double Pi = 3.14;
            double area = (double)(Pi * r * r);
            double circumference = (double)(2 * Pi * r);
            Console.WriteLine("Area Is " + area + " Circumference Is " + circumference);
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Radius");
            int n =Convert.ToInt32(Console.ReadLine());
            find(n);

            
        }
    }
      
}





