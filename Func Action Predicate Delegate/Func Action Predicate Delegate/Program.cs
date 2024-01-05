


using System;
using System.IO;
using System.Collections.Generic;

namespace FuncActionPredicate
{
    class Program
    {

        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1,out TResult>(T1 arg1);
        delegate TResult Func2<in T1,in T2,out TResult>(T1 arg1,T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            //......Func Example.....

            /* MathClass mc = new MathClass();
             Func<int, int, int> calculation = mc.Sum;
             int res = calculation((10 * 10), 43);
             Func<int , int ,int> cal = delegate (int a, int b){ return a + b; };
             Func<int , int ,int> cal = (a,  b) =>  a + b;
             int res= cal(10000,403);
             Console.WriteLine($"Sum : {res}");

             float a = 2.5f, b = 3.5f;
             int c = 3;
             Func<float, float, int, float> cla2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;
             float res = cla2(a, b, c);
             Console.WriteLine(res); 

             Func<decimal, decimal, decimal> totalAnnualSalary = (annualSalary, bouns) => annualSalary + (annualSalary * (bouns / 100));
             decimal total = totalAnnualSalary(100000.1500m, 20);
             Console.WriteLine(total);*/

           // .......Action Example....

            Action<int, string, string,decimal,char,bool> displayEmployeeRecords = (arg1, arg2, arg3,arg4,arg5,arg6) => Console.WriteLine($"Id : {arg1}{Environment.NewLine}Firt Name : {arg2}{Environment.NewLine}Last Name : {arg3}{Environment.NewLine}Annual Salary : {arg4}{Environment.NewLine}Gender : {arg5}{Environment.NewLine}Manager: {arg6}");
            displayEmployeeRecords(7, "ABC", "XYZ",500,'F',true);



            //.....Predicate....
            Func<decimal, decimal, decimal> totalAnnualSalary = (annualSalary, bouns) => annualSalary + (annualSalary * (bouns / 100));

            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { Id = 42, FirstName ="Rayhan",LastName = "Rana",AnnualSalary = totalAnnualSalary(100,10),Gender = 'M',IsManager = true});
            employees.Add(new Employee { Id = 777, FirstName ="Batashi",LastName = "Chowdhury",AnnualSalary = totalAnnualSalary(200, 200), Gender = 'F',IsManager = false});
            employees.Add(new Employee { Id = 007, FirstName ="Megh",LastName = "Bahi",AnnualSalary = totalAnnualSalary(300,30), Gender = 'M',IsManager = false});
            employees.Add(new Employee { Id = 777, FirstName ="Rain",LastName = "Strom",AnnualSalary = totalAnnualSalary(400, 40), Gender = 'F',IsManager = true});

            //List<Employee> employeesFiltered = FilterEmployees(employees, e => e.Gender == 'F');
            //List<Employee> employeesFiltered1 = FilterEmployees(employees, e => e.AnnualSalary >= 200);

            //List<Employee> employeesFiltered3 = employees.FilterEmployees(e => e.AnnualSalary > 100);\


            List<Employee> employeesFiltered3 = employees.Where(e => e.IsManager==true).ToList();

            foreach (Employee employee in employeesFiltered3)
            {
                displayEmployeeRecords(employee.Id,employee.FirstName,employee.LastName,employee.AnnualSalary,employee.Gender,employee.IsManager);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        /*static List<Employee> FilterEmployees(List<Employee> employees,Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();
            foreach(Employee emp in employees)
            {
                if (predicate(emp))
                {
                    employeesFiltered.Add(emp);
                }
            }
            return employeesFiltered;
        }*/
        
    }
    public static class Extensions
    {
        public static List<Employee> FilterEmployees(this List<Employee> employees,Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();
            foreach(Employee emp in  employees)
            {
                if(predicate(emp))
                {
                    employeesFiltered.Add(emp);
                }
            }
            return employeesFiltered;
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }
    public class MathClass
    {
        public int Sum(int a, int b) => a + b;
    }
}