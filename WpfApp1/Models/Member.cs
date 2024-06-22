using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
   
    public class Member: IEmployee
    {
        public Human Human { get; set; }

        public string MembershipID { get; set; } //atrybut kwalifikacyjny

        public DateTime whenAdded { get; set; } = DateTime.Now;

        public bool? IsPremium { get; set; }
        private List<Borrow> Borrows { get; set; }   = new List<Borrow>();//lista wypozyczen
        private List<Library> libraries { get; set; } = new List<Library>();
        public const string BorrowsFilePathMember = "borrowsMember.json";

        private const string AuthorsFilePath = "authorsMemberExtension.json";
        private const string LibraryObjectsFilePath = "library_objectsMemberExtension.json";
        private const string BooksFilePath = "booksMemberExtension.json";


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

            const string AuthorBookConnectionsFilePath = "author_book_connectionsMemberExtension.json";
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
            const string MembersFilePath = "membersMemberExtension.json";
            if (!File.Exists(MembersFilePath))
            {
                return new List<Member>();
            }

            string json = File.ReadAllText(MembersFilePath);
            return JsonConvert.DeserializeObject<List<Member>>(json);
        }

        private void SaveMembersToFile(List<Member> members)
        {
            const string MembersFilePath = "membersMemberExtension.json";
            string json = JsonConvert.SerializeObject(members, Formatting.Indented);
            File.WriteAllText(MembersFilePath, json);
        }
        public virtual string GetObjectType()
        {
            return this.GetType().Name;
        }
    } 
}
