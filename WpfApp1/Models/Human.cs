using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Year { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }

        public Member Member { get; private set; }
        public Author Author { get; private set; }
        public Employee Employee { get; private set; }


        //kompozycja
        public static List<Member> AllMembers = new List<Member>();

        public static List<Author> AllAuthors = new List<Author>();
        public static List<Employee> AllEmployees = new List<Employee>();


        public static List<Member> members = new List<Member>();

        public static List<Author> authors = new List<Author>();
        public static List<Employee> employees = new List<Employee>();




        //overlapping


        public Human(string name, string surname, int year, string address, Gender gender)
        {
            Name = name;
            Surname = surname;
            Year = year;
            Address = address;
            Gender = gender;
        }


        //overlapping
        public void addEmployeePart(Employee emp)
        {
            if (employees.Contains(emp))
                throw new Exception("You can't have Employee 2 time");

            if (AllEmployees.Contains(emp))
                throw new Exception("This Employee is connected with other Human");

            employees.Add(emp);
            AllEmployees.Add(emp);
        }

        public void addAuthorPart(Author author)
        {
            if (authors.Contains(author))
                throw new Exception("You can't have Author 2 time");

            if (AllAuthors.Contains(author))
                throw new Exception("This Author is connected with other Human");

            authors.Add(author);
            AllAuthors.Add(author);
        }

        public void addMemberPart(Member member)
        {
            if (members.Contains(member))
                throw new Exception("You can't have Member 2 time");

            if (AllMembers.Contains(member))
                throw new Exception("This Member is connected with other Human");

            members.Add(member);
            AllMembers.Add(member);
        }

        public void RemoveEmployePart(Employee emp)
        {
            employees.Remove(emp);
            AllEmployees.Remove(emp);
        }
        public void RemoveAuthorPart(Author auth)
        {
            authors.Remove(auth);
            AllAuthors.Remove(auth);
        }
        public void RemoveMemberPart(Member mem)
        {
            members.Remove(mem);
            AllMembers.Remove(mem);
        }

    }
}
