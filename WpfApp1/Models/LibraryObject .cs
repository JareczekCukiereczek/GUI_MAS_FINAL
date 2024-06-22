using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{

    public class LibraryObject
    {

        public string Title { get; set; }//atrybut złożony
        public int NumberOfPages { get; set; }
        public string Type { get; set; }

        public string ISBN { get; set; }//atrybut obiektowy
        public string? Illustration { get; set; }//opcjonalny
        public double? Rating { get; set; }//opcjonalny
        public List<string> Languages { get; set; } = new List<string>();//atrybut powtarzalny
        public bool? Available { get; set; }

        private List<Borrow> Borrows { get; set; } // Lista wypożyczeń


        public Author Author { get; set; } 

        public TypeObject TypeObject { get; set; }

        public DateTime AddedDate { get; set; }
        private DateTime _salesDeadline;
        public DateTime SalesDeadline
        {
            get => _salesDeadline;
            set
            {
                if (value >= AddedDate)
                    _salesDeadline = value;
                else
                    Console.WriteLine("Deadline nie moze byc wczesniejszy niz data dodania.");
            }
        }

        public int DaysUntilDeadline => (int)(SalesDeadline - AddedDate).TotalDays;

        protected LibraryObject() { }


        public LibraryObject(string title)
        {
            Title = title;
            Borrows = new List<Borrow>();

        }

        public void setAuthor(Author autor)
        {
            Author = autor;
            autor.setBook(this);
        }


        public void AddBorrow(Borrow borrow)
        {
            Borrows.Add(borrow);
        }


        //kompozycja w wieloaspektowy

        private static List<TypeObject> AllTypeObjects = new();
        public void AddPartToInheritanceMultiAspect(TypeObject typeObject)
        {
           if(TypeObject == typeObject)
            {
                throw new Exception("TypeObject is typeObject");
            }
            TypeObject = typeObject; 
            AllTypeObjects.Add(typeObject);
        }
        public void RemovePartToInheritanceMultiAspect(TypeObject typeObject)
        {
            typeObject = null;
            AllTypeObjects.Remove(typeObject);
        }
        
    }
}

