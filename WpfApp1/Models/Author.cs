using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WpfApp1.Models
{
    public class Author
    {

        public string Biography { get; set; }

        public bool? ReceivedNobel { get; set; }

        private List<LibraryObject> libraryObjects = new List<LibraryObject>();

        public List<Author> authorList = new List<Author>();
        public LibraryObject libraryObject { get; set; }

        public Human Human { get; set; }

        public Author(Human human, string name, string surname, int year, string address, Gender gender)
        {
            Human = human;

        }

        public void setBook(LibraryObject libraryObject)
        {
            if (libraryObjects.Contains(libraryObject))
            {
                return;
            }
            libraryObjects.Add(libraryObject);
            libraryObject.setAuthor(this);

        }


        public IEnumerable<LibraryObject> GetBooks()
        {
            return libraryObjects;
        }
        public void PrintAllBooks()
        {
            foreach (var paperObject in GetBooks())
            {
                Console.WriteLine(paperObject.ToString);
            }
        }


        //overlapping - kompozycja
        public static void CreatePartOfAuthorShowOverlapping(Human human, string name, string surname, int year, string address, Gender gender)
        {
            if (human == null)
            {
                throw new Exception("Human couldnt be null");
            }
            Author author = new Author(human, name, surname, year, address, gender);
            human.addAuthorPart(author);
        }

    }
}