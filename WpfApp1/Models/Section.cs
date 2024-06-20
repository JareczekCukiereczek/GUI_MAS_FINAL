using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Section
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime dateCreation { get; set; }

        public string shortDescription { get; set; }
        private List<LibraryObject> libraryObjects { get; set; }

        private Library _library;
        private List<Library> libraries { get; set; } // Kompozycja - biblioteka składa się z wielu sekcji, a sekcje nie mogą istnieć bez biblioteki.


        private List<Book> books;


        private Section(string name)
        {
            Name = name;
            libraryObjects = new List<LibraryObject>();
        }


        public void AddBook(LibraryObject libraryObject)
        {
            if (!libraryObjects.Contains(libraryObject))
            {
                libraryObjects.Add(libraryObject);
                Console.WriteLine($"Książka '{libraryObject.Title}' została dodana do sekcji {Name}");
            }
        }
        public void RemoveBook(LibraryObject libraryObject)
        {
            if (libraryObjects.Contains(libraryObject))
            {
                libraryObjects.Remove(libraryObject);
                Console.WriteLine($"Książka '{libraryObject.Title}' została usunięta z sekcji {Name}");
            }
        }
        public void SetLibrary(Library library)
        {
            _library = library;
        }

        public static void createSection(Library library, string name)
        {
            if (library == null)
            {
                throw new Exception("Calosc nie istenieje");
            }

            Section section = new Section(name);
            library.AddSection(section);
            section.SetLibrary(library);

        }

        public Library GetLibrary()
        {
            return _library;
        }

        public IEnumerable<LibraryObject> GetBooks()
        {
            return libraryObjects;
        }

    }
}
