// See https://aka.ms/new-console-template for more information

using HRAdministrationAPI;
using System.Collections;
using System.Linq;
using System;

namespace SchoolHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    class Program
    {
        public static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);

            /*foreach(IEmployee employee in employees)
            {
                totalSalaries += employee.Salary;
            }

            Console.WriteLine($"Total Annual Slaries(Including Bonus): {totalSalaries}");
            */

            Console.WriteLine($"Total Annual Slaries(Including Bonus): {employees.Sum(tk => tk.Salary)}");




            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees)
        {

            IEmployee teacher1 = EmployessFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Rayhan", "Chowdhury", 40000);
            IEmployee teacher2 = EmployessFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jakir", "Badal", 50000);
            IEmployee headOfDepartment = EmployessFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Jabed", "Hussain", 60000);
            IEmployee deputyMaster = EmployessFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Rakib", "Jahid", 70000);
            IEmployee headMaster = EmployessFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Khaled", "Sohel", 80000);

            employees.Add(teacher1);
            employees.Add(teacher2);
            employees.Add(headOfDepartment);
            employees.Add(headMaster);
            employees.Add(deputyMaster);



           /* IEmployee teacher1 = new Teacher
            {
                Id = 1,
                Firstname = "Rayhan",
                Lastname = "Chowdhury",
                Salary = 100000
            };
            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher
            {
                Id = 2,
                Firstname = "Jakir",
                Lastname = "Hossain",
                Salary = 200000
            };
            employees.Add(teacher2);

            IEmployee headOfDepartment = new HeadOfDepartment
            {
                Id = 3,
                Firstname = "Shahab",
                Lastname = "Uddin",
                Salary = 40000000
            };
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = new DeputyHeadMaster
            {
                Id = 4,
                Firstname = "Abdul",
                Lastname = "Kaiyum",
                Salary = 450000
            };
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = new HeadMaster
            {
                Id = 5,
                Firstname = "Sohel",
                Lastname = "Chowdhury",
                Salary = 690000
            };
            employees.Add(headMaster);
*/

        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }

    }
    public class HeadOfDepartment : EmployeeBase 
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }
    public class  DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }
    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }

    public static class EmployessFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType,int id,string firstname, string lastname, decimal salary)
        {
            IEmployee employee = null;

            switch(employeeType)
            {
                case EmployeeType.Teacher:
                    //employee = new Teacher { Id = id, Firstname = firstname, Lastname = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                   // employee = new HeadOfDepartment { Id = id, Firstname = firstname, Lastname = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee,HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    //employee = new DeputyHeadMaster { Id = id, Firstname = firstname, Lastname = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee,DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    //employee = new HeadMaster { Id = id, Firstname = firstname, Lastname = lastname, Salary = salary };
                    employee = FactoryPattern<IEmployee,HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.Firstname = firstname;
                employee.Lastname = lastname;
                employee.Salary = salary;
            }
            else
            {
                throw new NullReferenceException();
            }

            return employee;
        }
    }

}
