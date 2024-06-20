using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public interface IEmployee
    {
        void RemoveMembers();
        void AddAuthor(Author author);
        void AddLibraryObject(LibraryObject libraryObject);
        void ConnectAuthorWithLibraryObject(Author author, LibraryObject libraryObject);
        void AddBook(LibraryObject book);
        void RemoveBook(LibraryObject book);
    }
}
