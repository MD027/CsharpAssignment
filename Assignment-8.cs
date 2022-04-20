//TASK 1 - Write a console based application to dyanmically load an assembly.

using System;
using System.Reflection;



namespace Reflections
{
class Employeedetails
{
public int EmpId { get; set; }
public string EmpName { get; set; }
public double EmpSalary { get; set; }

public Employeedetails(int EmpId, string EmpName ,double EmpSalary)
{
this.EmpId=EmpId;
this.EmpName=EmpName;
this.EmpSalary=EmpSalary;
}
public void empDetails()
{
Console.WriteLine("Employee Id :"+EmpId);
Console.WriteLine("Employee name :"+EmpName);
Console.WriteLine("Employee Salary :"+ EmpSalary);
}
}
class Program
{
static void Main(string[] args)
{
Employeedetails emp = new Employeedetails(1, "mohit", 400000);

Assembly executing = Assembly.GetExecutingAssembly();
Type[] types = executing.GetTypes();
emp.empDetails();
foreach (var item in types)
{
Console.WriteLine(item.Name);
MethodInfo[] mi = item.GetMethods();



foreach (var method in mi)
{
Console.WriteLine(method.Name);



}
}
Console.ReadLine();
}
}
}


//TASK 2- Write Property for all these members.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace reflectionApplication
{
[AttributeUsage(AttributeTargets.Class |
AttributeTargets.Field |
AttributeTargets.Method |
AttributeTargets.Constructor |
AttributeTargets.Property, AllowMultiple = true)]
class SoftwareAtttribute : System.Attribute
{
private string ProjectName;
private string Description;
private string ClientName;
private string StartedDate;
private string EndDate;



public string ProjectName
{
get{ return projectName; }
set{ ProjectName= value; }
}
public string description
{
get { return Description; }
set { Description= value; }
}
public string clientName
{
get { return ClientName; }
set { ClientName= value; }
}
public string startedDate
{
get { return StartedDate; }
set { StartedDate= value; }
}
public string endDate
{
get { return EndDate; }
set { EndDate= value; }
}
public class HDFCAccount : SoftwareAtttribute
{
public void displayAccount(string projectName, string description, string clientname)
{



this.Description = description;
this.ProjectName = projectName;
this.ClientName = clientname;
Console.WriteLine("Project Desc : " + Description);
Console.WriteLine("Projectname : " + ProjectName);
Console.WriteLine("Project Client Name : " + ClientName)

Console.WriteLine("Project Started Date : "+startedDate);
Console.WriteLine("Project End Date : \n"+EndDate);
}
}



class Test
{
static void Main(string[] args)
{
HDFCAccount ha=new HDFCAccount();
ha.displayAccount("reflection assignment", "reflection", "capgemini");
HDFCAccount ia = new HDFCAccount();
ia.displayAccount("reflection assignment", "reflection", "capgemini","17-06-2022","27-06-2022");



Assembly executing = Assembly.GetExecutingAssembly();
Type[] types = executing.GetTypes();
foreach (Type t in types)
{
MethodInfo[] mi = t.GetMethods();
foreach (var m in mi)
{



Console.WriteLine(m);
}
}
Console.ReadKey();
}
}
}
}