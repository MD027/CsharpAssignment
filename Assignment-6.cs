//TASK 1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniAndMultiCastDelegate
{
    public delegate void EmployeeDelegate(); //declaring Unicast delegate
    public class UniCastDelegate
    {

        static void Main(string[] args)
        {
            Employee Employee = new Employee();
            EmployeeDelegate employeeDelegate = new EmployeeDelegate(Employee.Display);
            employeeDelegate.Invoke();
        }
    }
    public class Employee
    {
        private int empID;
        private string empName;
        private string companyName;
        private string Position;
        private string Location;



        public Employee()
        {
            Console.Write("Enter the Employee id : ");
            this.empID = (Convert.ToInt32(Console.ReadLine()));
            Console.Write("Enter the Employee name : ");
            this.empName = Console.ReadLine();

            Console.Write("Enter the Company Name : ");
            this.companyName = Console.ReadLine();

            Console.Write("Enter the Employee Position : ");
            this.Position = Console.ReadLine();

            Console.Write("Enter the Employee Location : ");
            this.Location = Console.ReadLine();

        }

        public void Display()
        {
            Console.WriteLine("Employee Id : {0}", empID);
            Console.WriteLine("Employee Name : {0}", empName);
            Console.WriteLine("Employee Company Name : {0}", companyName);

            Console.WriteLine("Employee Position : {0}", Position);

            Console.WriteLine("Employee Location : {0}", Location);
        }
    }
}


//TASK 2
sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniAndMultiCastDelegate
{
    public delegate void EmployeeDelegate1();
    public class MultiCastDelegate
    {

        static void Main(string[] args)
        {
            EmployeeMarketingExecutiveDetails manEx = new EmployeeMarketingExecutiveDetails();


            EmployeeDelegate1 employeeDelegate1 = new EmployeeDelegate1(manEx.Display);
            employeeDelegate1 += manEx.MarketingExecutiveDisplay;


            employeeDelegate1.Invoke();


        }
    }
    public class EmployeeMarketingExecutiveDetails
    {
        private int empID, markExId;
        private string empName, markExName;
        private string companyName, markExCompanyName;
        private string Position, markExPosition;
        private string Location, markExLocation;



        public EmployeeMarketingExecutiveDetails()
        {
            Console.Write("Enter the Employee id : ");
            this.empID = (Convert.ToInt32(Console.ReadLine()));
            Console.Write("Enter the Employee name : ");
            this.empName = Console.ReadLine();

            Console.Write("Enter the Company Name : ");
            this.companyName = Console.ReadLine();

            Console.Write("Enter the Employee Position : ");
            this.Position = Console.ReadLine();

            Console.Write("Enter the Employee Location : ");
            this.Location = Console.ReadLine();

            

            Console.Write("Enter the MarketingExecutive id : ");
            this.markExId = (Convert.ToInt32(Console.ReadLine()));

            Console.Write("Enter the MarketingExecutive name : ");
            this.markExName = Console.ReadLine();

            Console.Write("Enter the MarketingExecutive Company Name : ");
            this.markExCompanyName = Console.ReadLine();

            Console.Write("Enter the MarketingExecutive Position : ");
            this.markExPosition = Console.ReadLine();

            Console.Write("Enter the MarketingExecutive Location : ");
            this.markExLocation = Console.ReadLine();

        }

        public void Display()
        {
            Console.WriteLine("Employee Details :");
            Console.WriteLine("Employee Id : {0}", empID);
            Console.WriteLine("Employee Name : {0}", empName);
            Console.WriteLine("Employee Company Name : {0}", companyName);

            Console.WriteLine("Employee Position : {0}", Position);

            Console.WriteLine("Employee  Location : {0}", Location);

            Console.WriteLine("========================================================");
        }

        public void MarketingExecutiveDisplay()
        {
            Console.WriteLine("MarketingExecutiveDetails : ");
            Console.WriteLine("MarketingExecutive Employee Id : {0}", markExId);
            Console.WriteLine("MarketingExecutive Employee Name : {0}", markExName);
            Console.WriteLine("MarketingExecutive Employee Company Name : {0}", markExCompanyName);

            Console.WriteLine("MarketingExecutive Employee Position : {0}", markExPosition);

            Console.WriteLine("MarketingExecutive Employee Work Location : {0}", markExLocation);
        }


    }
}


//TASK 3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    public class TransactionEventArgs : EventArgs
    {
        public int TranactionAmount { get; set; }
        public string TranactionType { get; set; }

        public TransactionEventArgs(int amt, string type)
        {
            TranactionAmount = amt;
            TranactionType = type;
        }
    }
    public delegate void TransactionHandler(object sender, TransactionEventArgs e);
    public class MyEvent
    {
        public event TransactionHandler TransactionMade; 
        public int BalanceAmount;  

        public MyEvent(int amount)  
        {
            this .BalanceAmount = amount;   
        }
        public void Debit(int debitAmount) 
            if (debitAmount < BalanceAmount)
            {
                BalanceAmount = BalanceAmount - debitAmount;
                TransactionEventArgs e = new TransactionEventArgs(debitAmount, "Debited");
                OnTransactionMade(e); 
            }
        }

        public void Credit(int creditAmount)  
        {

            BalanceAmount = BalanceAmount + creditAmount;
            TransactionEventArgs e = new TransactionEventArgs(creditAmount, "Credited"); 
            OnTransactionMade(e); 

        }

        public void ZeroBalance()
        {
            BalanceAmount = 0;
            TransactionEventArgs e = new TransactionEventArgs(0, "ZeroBalance"); 
            OnTransactionMade(e);
        }
        protected virtual void OnTransactionMade(TransactionEventArgs e) 
        {
            if (TransactionMade != null) 
            {
                TransactionMade(this, e);  
            }
        }
    }
    public class TestMyEvent
    {
        private static void SendNotification(Object sender,TransactionEventArgs e) 
        {
            Console.WriteLine("Your Account is {0} for Rs.{1} ", e.TranactionType, e.TranactionAmount);
            
           
        }

        private static void Main(String[] args)
        {
            
            MyEvent ac2 = new MyEvent(200);
            
            if(ac2.BalanceAmount > 500)
            {
                ac2.TransactionMade += new TransactionHandler(SendNotification);
            }
            else if(ac2.BalanceAmount < 500  && ac2.BalanceAmount > 0)
            {
                
                Console.WriteLine("Your account is UnderBalance");
            }
            else if(ac2.BalanceAmount == 0)
            {
                ac2.ZeroBalance();
                ac2.TransactionMade += new TransactionHandler(SendNotification);
            }
            
            ac2.Credit(2000);
            Console.WriteLine("Your Current Balance is : " +ac2.BalanceAmount);
            Console.ReadLine();
            Console.WriteLine("* Rs 500 is Auto debited as Maintainance charge by Your Bank");
            Console.WriteLine("Press enter to view Total balance");
            Console.ReadKey();
            ac2.Debit(500);
            Console.WriteLine("Your Current Balance is : " + ac2.BalanceAmount);
            Console.ReadLine();
        }
    }
}
//TASK 4
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    
    public class Account
    {
        public int AccountNumber;
        public string CustomerName;
        public double Balance;

        public Account(int AccountNumber,String CustomerName,double Balance)
        {
            
            this.AccountNumber = AccountNumber;
            this.CustomerName = CustomerName;   
            this.Balance = Balance; 
        }
       

        public void Withdraw(double amount)
        {
            Console.WriteLine("Enter  withdrawal amount");
            Console.ReadLine();
            

            if (this.Balance>500)
            {
                if(amount == 200 || amount == 500 || amount == 2000)
                {
                    Console.WriteLine(Balance + " : choose Account");
                    Console.WriteLine("->Savings");
                    Console.WriteLine("->Current");
                    Console.Read();
                    Console.WriteLine("processing...");
                    double finalbalance = Balance - amount;
                    Console.WriteLine(finalbalance + " : Balance after withdrawal ");
                   
                }
                else
                {
                    Console.WriteLine("Error!");
                }
                          
            }
            else if(Balance < 500)
            {
                Console.WriteLine("Your balance is low");
            }
            else
            {
                Console.WriteLine("Your Session Expired!");
            }
            
        }
        public void Deposit(double amt)
        {
            Console.WriteLine("Enter the amount you want to deposit ");
            Console.Read();
            if(amt >= 500)
            {
               
                Console.WriteLine("deposition is completed");
                double dep = Balance + amt;
                Console.WriteLine(dep + ": Rs is your balance after the deposoition");
                
            }
            else if(amt < 500)  
            {
                Console.WriteLine("Please deposit more than 500 Rs");
            }
            else
            {
                Console.WriteLine("Invalid Number!!");
            }
        }
    }
    internal class WithdrawDeposit
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE BANKING APPLICATION DOMAIN");
            Console.ReadKey();
            Account ac1 = new Account(123456,"Mohit",560000);
            ac1.Withdraw(500);
            

        }
    }
}

