using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Library
    {
        private string Name { get; set; }
        public string Address { get; set; }
        public const int MAX_NUMBER_OF_SECTIONS = 5;


        private Dictionary<string, Member> Members { get; set; } // Kwalifikowana asocjacja -  przez MembershipID
        private List<Section> Sections { get; set; } // Kompozycja - biblioteka składa się z wielu sekcji, a sekcje nie mogą istnieć bez biblioteki.
        private static List<Section> allSections { get; set; } = new List<Section>();//Kompozycja - wszystkie nasze sekcje

        private List<Borrow> borrows;


        public Library(string name)
        {
            Name = name;
            Members = new Dictionary<string, Member>();
            Sections = new List<Section>();
            borrows = new List<Borrow>();
        }

        public void AddMember(Member member)
        {
            if (!Members.ContainsKey(member.MembershipID))
            {
                Members.Add(member.MembershipID, member);
            }
            else
            {
                Console.WriteLine("Taki member juz istnieje");
            }
        }

        public Member GetMemberByMembershipID(string membershipID)
        {
            if (Members.ContainsKey(membershipID))
            {
                return Members[membershipID];
            }
            else
            {
                Console.WriteLine($"Nie znaleziono członka z MembershipID: {membershipID}");
                return null;
            }
        }

        public void AddSection(Section section) //kompozycja i polaczenie zwrotne dla kompozycji
        {
            if (allSections.Contains(section))
            {
                throw new Exception("Sekcja dodana w innej bibliotece");
            }
            Sections.Add(section);
            allSections.Add(section);

        }
        public void RemoveSection(Section section)
        {
            Sections.Remove(section);
            allSections.Remove(section);

        }
        public void AddBorrow(Borrow borrow)
        {
            borrows.Add(borrow);
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            return borrows;
        }

        public void ListAllBorrows()
        {
            foreach (var borrow in borrows)
            {
                Console.WriteLine($"{borrow.Member.MembershipID} wypożyczył(a) '{borrow.LibraryObject.Title}' dnia {borrow.BorrowDate}");
            }
        }

    }
}
