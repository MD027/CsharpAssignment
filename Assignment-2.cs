using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2oopsclassassignment
{
    class Employee
    {
        private int EmpNo;
        private string EmpName;
        private double Salary;
        private double HRA;
        private double TA;
        private double DA;
        private double PF;
        private double TDS;
        private double NetSalary;
        private double GrossSalary;

        public void Getdetails()
        {
            Console.Write("Enter Employee ID: ");
            this.EmpNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name: ");
             this.EmpName = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            this.Salary = Convert.ToDouble(Console.ReadLine());
        }

      
        public double Grosssalary()
        {
            //this.Salary = Salary;
            if (Salary < 5000)
            {
                this.HRA = (Salary * 10) / 100;
                this.TA = (Salary * 5) / 100;
                this.DA = (Salary * 15) / 100;
            }
            else if (Salary >= 5000 && Salary < 10000)
            {
                this.HRA = (Salary * 15) / 100;
                this.TA = (Salary * 10) / 100;
                this.DA = (Salary * 20) / 100;
            }
            else if (Salary >= 10000 && Salary < 15000)
            {
                this.HRA = (Salary * 20) / 100;
                this.TA = (Salary * 15) / 100;
                this.DA = (Salary * 25) / 100;
            }
            else if (Salary >= 15000 && Salary < 20000)
            {
                this.HRA = (Salary * 25) / 100;
                this.TA = (Salary * 20) / 100;
                this.DA = (Salary * 30) / 100;
            }
            else
            {
                this.HRA = (Salary * 30) / 100;
                this.TA = (Salary * 25) / 100;
                this.DA = (Salary * 35) / 100;
            }
            return GrossSalary = Salary + this.HRA + this.TA + this.DA;
            
        }

        public double CalculateSalary()
        {
            PF = (GrossSalary * 10) / 100;
            TDS = (GrossSalary * 18) / 100;
            return NetSalary = GrossSalary - (PF + TDS); 
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Employee employee = new Employee();
                employee.Getdetails();                
                double gsalary = employee.Grosssalary();
                Console.WriteLine("Employee Net Salary is {0}",gsalary);
                double totalsalary = employee.CalculateSalary();
                Console.WriteLine("Employee total Salary is {0}", totalsalary);

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}


