using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
    public class Employee : IEmployee
    {
        // Właściwości klasy Employee
        public int EmployeeID { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int Salary { get; set; }
        public Human Human { get; set; }
        private Author Author { get; set; }
        private const string AuthorsFilePath = "authorsEmployeeExtension.json";
        private const string LibraryObjectsFilePath = "library_objectsEmployeeExtension.json";
        private const string BooksFilePath = "booksEmployeeExtension.json";

        //dziedziczenie z nadklasy
        private Employee(Human human, int employeeID, int salary, string name, string surname, int year, string address, Gender gender)
        {
            Human = human;
            EmployeeID = employeeID;
            Salary = salary;

        }

        //overlapping - kompozycja
        public static void CreatePartOfEmployeeShowOverlapping(Human human, int employeeID, int salary, string name, string surname, int year, string address, Gender gender)
        {
            if (human == null)
            {
                throw new Exception("Human couldnt be null");
            }
            Employee emp = new Employee(human, employeeID, salary, name, surname, year, address, gender);
            human.addEmployeePart(emp);
        }

        

        //implementacja metod z  interfejsu
        private List<Author> LoadAuthorsFromFile()
        {
            if (!File.Exists(AuthorsFilePath))
            {
                return new List<Author>();
            }

            string json = File.ReadAllText(AuthorsFilePath);
            return JsonConvert.DeserializeObject<List<Author>>(json);
        }

        private void SaveAuthorsToFile(List<Author> authors)
        {
            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            File.WriteAllText(AuthorsFilePath, json);
        }

        private List<LibraryObject> LoadLibraryObjectsFromFile()
        {
            if (!File.Exists(LibraryObjectsFilePath))
            {
                return new List<LibraryObject>();
            }

            string json = File.ReadAllText(LibraryObjectsFilePath);
            return JsonConvert.DeserializeObject<List<LibraryObject>>(json);
        }

        private void SaveLibraryObjectsToFile(List<LibraryObject> libraryObjects)
        {
            string json = JsonConvert.SerializeObject(libraryObjects, Formatting.Indented);
            File.WriteAllText(LibraryObjectsFilePath, json);
        }

        private List<LibraryObject> LoadBooksFromFile()
        {
            if (!File.Exists(BooksFilePath))
            {
                return new List<LibraryObject>();
            }

            string json = File.ReadAllText(BooksFilePath);
            return JsonConvert.DeserializeObject<List<LibraryObject>>(json);
        }

        private void SaveBooksToFile(List<LibraryObject> books)
        {
            string json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(BooksFilePath, json);
        }

        // Implementacja metod z interfejsu
        public void AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            List<Author> authors = LoadAuthorsFromFile();
            authors.Add(author);
            SaveAuthorsToFile(authors);
        }

        public void AddBook(LibraryObject book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            List<LibraryObject> books = LoadBooksFromFile();
            books.Add(book);
            SaveBooksToFile(books);
        }

        public void AddLibraryObject(LibraryObject libraryObject)
        {
            if (libraryObject == null)
                throw new ArgumentNullException(nameof(libraryObject));

            List<LibraryObject> libraryObjects = LoadLibraryObjectsFromFile();
            libraryObjects.Add(libraryObject);
            SaveLibraryObjectsToFile(libraryObjects);
        }

        public void ConnectAuthorWithLibraryObject(Author author, LibraryObject libraryObject)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));
            if (libraryObject == null)
                throw new ArgumentNullException(nameof(libraryObject));

            author.setBook(libraryObject);
            SaveAuthorBookConnectionToFile(author, libraryObject);
        }

        private void SaveAuthorBookConnectionToFile(Author author, LibraryObject book)
        {
            var connection = new
            {
                Member = new
                {
                    Human = new
                    {
                        Name = author.Human.Name,
                        Surname = author.Human.Surname,
                        Year = author.Human.Year,
                        Address = author.Human.Address,
                        Gender = author.Human.Gender
                    },
                },
                LibraryObject = new
                {
                    book.Title,
                    book.NumberOfPages,
                    book.Type,
                    book.ISBN,
                    book.Illustration,
                    book.Rating,
                    book.Languages,
                    book.Available,
                }
            };

            const string AuthorBookConnectionsFilePath = "author_book_connectionsEmployeeExtension.json";
            List<object> connections;
            if (File.Exists(AuthorBookConnectionsFilePath))
            {
                string json = File.ReadAllText(AuthorBookConnectionsFilePath);
                connections = JsonConvert.DeserializeObject<List<object>>(json) ?? new List<object>();
            }
            else
            {
                connections = new List<object>();
            }

            connections.Add(connection);
            string updatedJson = JsonConvert.SerializeObject(connections, Formatting.Indented);
            File.WriteAllText(AuthorBookConnectionsFilePath, updatedJson);
        }

        public void RemoveBook(LibraryObject book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            List<LibraryObject> books = LoadBooksFromFile();
            LibraryObject bookToRemove = books.FirstOrDefault(b => b.ISBN == book.ISBN);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                SaveBooksToFile(books);
            }
        }

        public void RemoveMembers()
        {
            List<Member> members = LoadMembersFromFile();
            members.Clear();
            SaveMembersToFile(members);
        }

        private List<Member> LoadMembersFromFile()
        {
            const string MembersFilePath = "membersEmployeeExtension.json";
            if (!File.Exists(MembersFilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(MembersFilePath);
            return JsonConvert.DeserializeObject<List<Member>>(json);
        }

        private void SaveMembersToFile(List<Member> members)
        {
            const string MembersFilePath = "membersEmployeeExtension.json";
            string json = JsonConvert.SerializeObject(members, Formatting.Indented);
            File.WriteAllText(MembersFilePath, json);
        }
    }
}
