using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Borrow
    {
        public Member Member { get; set; }
        public LibraryObject LibraryObject { get; set; }

        public int BorrowID { get; set; }
        public DateTime BorrowDate { get; set; } // Asocjacja z atrybutem - asocjacja pomiędzy Member a Book
                                                 //klasa pośrednicząca pomiędzy nimi to Borrow która dodaje atrybut borrowDate

        private static Random random = new Random();
        private static HashSet<int> existingBorrowIDs = new HashSet<int>();
        public Borrow(Member member, LibraryObject libraryObject, DateTime borrowDate, int borrowID)
        {
            Member = member;
            LibraryObject = libraryObject;
            BorrowDate = borrowDate;
            BorrowID = borrowID;
            member.AddBorrow(this); // Dodanie wypożyczenia do listy wypożyczeń membera
            libraryObject.AddBorrow(this); // Dodanie wypożyczenia do listy wypożyczeń books

        }
        

    }
}
