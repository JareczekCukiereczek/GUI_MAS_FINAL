using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
   
    public class Member
    {
        public Human Human { get; set; }

        public string MembershipID { get; set; } //atrybut kwalifikacyjny

        public DateTime whenAdded { get; set; } = DateTime.Now;

        public bool? IsPremium { get; set; }
        private List<Borrow> Borrows { get; set; }   = new List<Borrow>();//lista wypozyczen
        private List<Library> libraries { get; set; } = new List<Library>();
        public const string BorrowsFilePathMember = "borrowsMember.json";

        //dziedziczenie z nadklasy
        public Member(Human human, string membershipID)
        {
            Human = human;
            MembershipID = membershipID;
        }

        public void AddBorrow(Borrow borrow)
        {
            Borrows.Add(borrow);
        }

        public IEnumerable<Borrow> GetBorrows()
        {
            return Borrows;
        }

        public void addLibrary(Library library)
        {
            libraries.Add(library);
        }

        public void ListBorrows()
        {
            foreach (var borrow in Borrows)
            {
                Console.WriteLine($"{MembershipID} wypożyczył(a) '{borrow.LibraryObject.Title}' dnia {borrow.BorrowDate}");
            }
        }

        //overlapping - kompozycja

        public static void CreatePartOfHumanShowOverlapping(Human human, string membershipId)
        {
            if (human == null)
            {
                throw new Exception("Human couldnt be null");
            }

            Member member = new Member(human, membershipId);
            member.Human= human;
            human.addMemberPart(member);
        }
        private List<Borrow> LoadBorrowsFromFile()
        {
            if (!File.Exists(BorrowsFilePathMember))
            {
                return new List<Borrow>();
            }

            string json = File.ReadAllText(BorrowsFilePathMember);
            return JsonConvert.DeserializeObject<List<Borrow>>(json);
        }

        public void SerializeBorrowsToFile(){
            string json = JsonConvert.SerializeObject(Borrows ,Formatting.Indented);
            File.WriteAllText(BorrowsFilePathMember, json);
        }
    } 
}
