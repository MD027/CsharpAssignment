//TASK-1 - Write a Console application which will read text file from mentioned file system location.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
AccountOwnerNamespace fileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @"C:\folder\FileIO";
            string subdir1 = @"C:\folder\FileIO\Write";
            string subdir2 = @"C:\folder\FileIO\Read";
            string srcFilepath = @"C:\folder\FileIO\Write\myFile.txt";
            string desFilepath = @"C:\folder\FileIO\Read\myFile.txt";
            Directory.CreateDirectory(dir);
            Directory.CreateDirectory(subdir1);
            Directory.CreateDirectory(subdir2);

            DirectoryInfo ds = new DirectoryInfo(subdir2);

            FileStream fs = File.Create(srcFilepath);
            string[] lines = { "Mohit", "mohitparmar@gmail.com", "Gujarat" };
            StreamWriter sw = new StreamWriter(fs);
            foreach (string s in lines)
            {
                sw.WriteLine(s);
            }
            sw.Close();

            string[] line = File.ReadAllLines(srcFilepath);
            foreach (string s in line)
            {
                Console.WriteLine(s);
            }
            File.Copy(srcFilepath, desFilepath, true);
            Console.ReadLine();
        }
    }
}



//TASK-2-CREATE A SIMPLE USER INTERFACE TO ACCEPT ACCOUNT RELATED INFORMATION OF A CUSTOMER.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

AccountOwnerNamespace fileIO
{
    internal class bank
    {
        public class account
        {
            public string AccountOwnerName;
            public double AccountrNumber;
            public double AccountrBalance;

            public Account(string AccountOwnerName,double accountAccountrNumber,double AccountrBalance)
            {
                this.AccountOwnerName = AccountOwnerName;
                this.AccountAccountrNumber = accountAccountrNumber;
                this.AccountrBalance = AccountrBalance;
            }
        }
        static void Main(string[] args)
        {

            string dir = @"C:\folder\BankAccountDetails";
            string srcFilepath = @"C:\folder\BankAccountDetails\Account.txt";
            Directory.CreateDirectory(dir);

            FileStream fs = File.Create(srcFilepath);
                fs.Close();
            Console.WriteLine("Enter  AccountOwnerName :");
            string AccountOwnerName = Console.ReadLine();
            Console.WriteLine("Enter AccountrNumber :");
             double AccountrNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter AccountrBalance :");
             double AccountrBalance = Convert.ToDouble(Console.ReadLine());
            Account a1 = new Account(AccountOwnerName, AccountrNumber, AccountrBalance);

            StreamWriter sw = new StreamWriter(srcFilepath);     
                sw.WriteLine(a1.AccountOwnerName);
                sw.WriteLine(a1.AccountrNumber);
                sw.WriteLine(a1.AccountrBalance);




            sw.Close();
            StreamReader sr = new StreamReader(srcFilepath);
            string line;

            Console.WriteLine("\nAccounts Details :");
            while ((line= sr.ReadLine()) != null)
            {
                
                Console.WriteLine(line);
            }
         
            Console.ReadLine();
        }
    }
}


//TASK-3- MAKE THE EMPLOYEE.MARKETINGEXECUTIVE AND MANAGER CLASS AS SERIALIZABLE.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

AccountOwnerNamespace FileInputandOutput
{
    interface IPrintable
    {
        void PrintDetails();
    }
    [Serializable()]
    class EployeeDetails : IPrintable
    {
        protected int EmpNo;
        protected string EmpAccountOwnerName;
        protected double Salary;
        protected double HRA;
        protected double TA;
        protected double DA;
        protected double PF;
        protected double TDS;
        protected double NetSalary;
        protected double GrossSalary;

        public void SetEmpNo(int EmpNo)
        {
            this.EmpNo = EmpNo;
        }
        public void SetEmpAccountOwnerName(string EmpAccountOwnerName)
        {
            this.EmpAccountOwnerName = EmpAccountOwnerName;
        }
        public double SetSalary(double Salary)
        {
            this.Salary = Salary;
            if (this.Salary < 500)
            {
                this.HRA = (this.Salary * 10) / 100;
                this.TA = (this.Salary * 5) / 100;
                this.DA = (this.Salary * 15) / 100;
            }
            else if (this.Salary > 5000 && this.Salary < 10000)
            {
                this.HRA = (this.Salary * 15) / 100;
                this.TA = (this.Salary * 10) / 100;
                this.DA = (this.Salary * 20) / 100;
            }
            else if (this.Salary >= 10000 && this.Salary < 15000)
            {
                this.HRA = (this.Salary * 20) / 100;
                this.TA = (this.Salary * 15) / 100;
                this.DA = (this.Salary * 25) / 100;
            }
            else if (this.Salary >= 15000 && this.Salary < 20000)
            {
                this.HRA = (this.Salary * 25) / 100;
                this.TA = (this.Salary * 20) / 100;
                this.DA = (this.Salary * 30) / 100;
            }
            else
            {
                this.HRA = (this.Salary * 30) / 100;
                this.TA = (this.Salary * 25) / 100;
                this.DA = (this.Salary * 35) / 100;
            }
            
            return this.GrossSalary = this.Salary + this.HRA + this.TA + this.DA;

        }
        public virtual double CalculateSalary()
        {
            this.PF = (this.GrossSalary * 10) / 100;
            this.TDS = (this.GrossSalary * 18) / 100;
            this.NetSalary = this.GrossSalary - (this.PF + this.TDS);
            return this.NetSalary;
        }
        public void PrintDetails()
        {

            Console.WriteLine("Employee No: " + EmpNo + ", EmployeeName: " + EmpName + ", Salary: " + Salary);
            Console.WriteLine("HRA: " + this.HRA + ", TA: " + this.TA + ", DA: " + this.DA);
            Console.WriteLine("PF: " + this.PF + ", TDS: " + this.TDS + "\n");
        }        

    }

    [Serializable]
    class Manager : EployeeDetails
    {
        private double PetrolAllowance;
        private double FoodAllowance;
        private double OtherAllowances;

        public double Gsalary(double Salary)
        {
            base.SetSalary(Salary);
            this.PetrolAllowance = Salary * 8 / 100;
            this.FoodAllowance = Salary * 13 / 100;
            this.OtherAllowances = Salary * 3 / 100;
            return this.GrossSalary = base.GrossSalary + PetrolAllowance + FoodAllowance + OtherAllowances;
        }
        public override double CalculateSalary()
        {
            this.TDS = (this.GrossSalary * 18) / 100;
            NetSalary = GrossSalary - (PF + TDS);
            return NetSalary;
        }
 
}
    [Serializable]
        class MarketingExecutive : EployeeDetails
    {
        private double KilometerTravel;
        private double TourAllowances;
        private int TelephoneAllowances = 1000;

        public void SetKilometersTravel(double Kilo)
        {
            KilometerTravel = Kilo;
            TourAllowances = KilometerTravel * 5;
        }
        public double Gsalary(double Salary)
        {
            base.SetSalary(Salary);
            return GrossSalary += TourAllowances + TelephoneAllowances;
        }
        public override double CalculateSalary()
        {
            base.SetSalary(Salary);
            this.PF = this.GrossSalary * 10 / 100;
            this.TDS = this.GrossSalary * 18 / 100;
            NetSalary = GrossSalary - (PF + TDS);
            return NetSalary;
        }
      
    }
    class inheritanceandpolymorphism
    {
        static void Main(string[] args)
        {
            Console.Write("Enter EployeeDetails ID: ");
            int EmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name: ");
            string EmpAccountOwnerName = Console.ReadLine();
            Console.Write("Enter Employee SALARY: ");
            double Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter kilometre value :");
            int kilo1 = Convert.ToInt32(Console.ReadLine());


            EmployeeDetails EployeeDetail = new EmployeeDetails();
            EployeeDetail.SetEmpNo(EmpId);
            EployeeDetail.SetEmpName(EmpName);
            EployeeDetail.SetSalary(Salary);
            EployeeDetail.CalculateSalary();
            EployeeDetail.PrintDetails();

            Manager manager = new Manager();


            MarketingExecutive me = new MarketingExecutive();

           Stream stream = File.Open("EmployeeDetailInfo.txt", FileMode.Create);

            Stream stream1 = File.Open("ManagerInfo.txt", FileMode.Create);

            Stream stream2 = File.Open("MarketingExecutiveInfo.txt", FileMode.Create);



            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, EployeeDetails);
            bformatter.Serialize(stream1, manager);
            bformatter.Serialize(stream2, me);



            stream.Close();



           

            me.SetSalary(Salary);
            me.SetKilometersTravel(kilo1);
            Console.WriteLine("EmployeeDetails Gross Salary is : {0}", EmployeeDetails.SetSalary(Salary));
            Console.WriteLine("EmployeeDetails Net salary is : {0}\n", EmployeeDetails.CalculateSalary());
            Console.WriteLine("Manager Gross Salary is :{0}", manager.Gsalary(Salary));
            Console.WriteLine("Manager Net salary is :{0}\n", manager.CalculateSalary());
            Console.WriteLine("Marketing Executive Gross Salary is :{0}", me.Gsalary(Salary));
            Console.WriteLine("Marketing Executive Net salary is :{0}", me.CalculateSalary());
            Console.ReadKey();
        }
    }
}


//TASK-4-Create a  User Interface to accept information about manager for simplicity accept only emp id,name and basic salary.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

AccountOwnerNamespace FileInputandOutput
{
    [Serializable]
    public class EmployeeDetails
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }
    }
    class Serializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bf.Serialize(fileStream, data);
            fileStream.Close();
        }
        public object BinaryDeserialize(string filePath)
        {
            object obj = null;
            FileStream fileStream;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bf.Deserialize(fileStream);
                fileStream.Close();
            }
            return obj;
        }
    }
    internal class Serialize
    {
        static void Main(string[] args)
        {
            string dir = @"C:\folder\FileIO\Write";
            string srcFilepath = @"C:\folder\FileIO\Write\myFile.txt";
            Directory.CreateDirectory(dir);
            Employeedetails emp1 = new EmployeeDetails
            {
                EmpId = Convert.ToInt32(Console.ReadLine()),
                EmpName = Console.ReadLine(),
                EmpSalary = Convert.ToDouble(Console.ReadLine())
            };
            Serializer se = new Serializer();
            se.BinarySerialize(emp1, srcFilepath);
            Console.WriteLine("Serialize complete");
            emp1 = se.BinaryDeserialize(srcFilepath) as EmployeeDetails;
            Console.WriteLine(emp1.EmpId);
            Console.WriteLine(emp1.EmpName);
            Console.WriteLine(emp1.EmpSalary);
            Console.WriteLine("Deserialize complete");
            Console.ReadKey();
        }
    }
}
