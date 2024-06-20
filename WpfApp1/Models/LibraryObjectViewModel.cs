using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
    public class LibraryObjectViewModel
    {
        private const string FilePath = "books.json";
        public ObservableCollection<LibraryObject> LibraryObjects { get; set; }

        public LibraryObjectViewModel()
        {
            LibraryObjects = new ObservableCollection<LibraryObject>();
            LoadBooksFromFile();
        }

        private void LoadBooksFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            string json = File.ReadAllText(FilePath);
            List<LibraryObject> books = JsonConvert.DeserializeObject<List<LibraryObject>>(json);
            foreach (var book in books)
            {
                LibraryObjects.Add(book);
            }
        }
    }
}