using System;

namespace WpfApp1
{
    public class Employee : Human
    {
        public int EmployeeID { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public decimal Salary { get; set; }

        public override void ShowAllUsers()
        {
            Console.WriteLine($"Name: {Name}, Surname: {Surname}, Year: {Year}, Address: {Address}, Gender: {Gender}, EmployeeID: {EmployeeID}, DateOfEmployment: {DateOfEmployment.ToShortDateString()}, Salary: {Salary}");
        }
    }
}
