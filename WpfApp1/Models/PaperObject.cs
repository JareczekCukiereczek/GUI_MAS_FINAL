using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{
   
    public class PaperObject
    {
        public string Format { get; set; }
        public Book Book { get; set; }
        public Map Map { get; set; }
        
        private PaperObject() { }   

        public PaperObject(string format)
        {
            Format = format;

        }


        //dziedzicz.dynamiczne za pomocą kompozycji 

        private static List<Book> AllBooks = new();
        private static List<Map> AllMaps = new();



        public void AddBookShowDynamicInher(Book book)
        {
            if (book == null)
                throw new Exception("Book is book");

            if (AllBooks.Contains(book))
                throw new Exception("Book is already connected with other PaperObject");
            if(Map is  not null)
            {
                throw new Exception("can't be null ");
            }

        

            Book = book;
            AllBooks.Add(book);
        }

        public void AddMapShowDynamicInher(Map map)
        {
            if (map == null)
                throw new Exception("Map is map");

            if (AllMaps.Contains(map))
                throw new Exception("Map is already connected with other PaperObject");
            if (Book is not null)
            {
                throw new Exception("can't be null");
            }

            Map = map;
            AllMaps.Add(map);
        }

        public void RemoveBook(Book book)
        {
            Book = null;
            AllBooks.Remove(book);

        }

        public void RemoveMap(Map map)
        {
            Map = null;
            AllMaps.Remove(map);
        }




        public void ChangeBookToMap(string scale, Legend mapLegend)
        {
            if (Book is null) { 
                throw new Exception("Book cannot be null");
            }
            RemoveBook(Book);
            Map.AddMapToPaperObject(this, scale, mapLegend);
 
        }

        public void ChangeMapToBook(string coverType, string shortSummary)
        {
            if (Map is null){
                throw new Exception("book nie moze byc pusty");
            }
            RemoveMap(Map);
            Book.AddBookToPaperObject(this, coverType, shortSummary);


        }

    }
}
