using System;

namespace WpfApp1
{
    public enum Benefits
    {
        SportCard,
        LifeInsurance
    }

    public class EmployeeMember : Employee
    {
        public int Bonus { get; set; } = 10; // Bonus ustawiony na 10%
        public Benefits EmployeeBenefits { get; set; }

        public override void ShowAllUsers()
        {
            base.ShowAllUsers();
            Console.WriteLine($"Bonus: {Bonus}%");
            Console.WriteLine($"Benefits: {EmployeeBenefits}");
        }
    }
}
