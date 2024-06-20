using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Models
{ 
    public class Book //dynamic dziedziczenie
    {
        public string CoverType { get; set; }
        public string ShortSummary { get; set; }

        public PaperObject paperObject { get; set; }

        //dynamic dziedziczenie - kompozycja
        private Book(PaperObject paperObject,string coverType,string shortSummary) 
        {
            CoverType = coverType;
            ShortSummary = shortSummary;
        }

        public static void AddBookToPaperObject(PaperObject paperObject, string coverType, string shortSummary)
        {
            if (paperObject is null)
                throw new Exception("Paper object can't be empty");

            Book book = new Book(paperObject, coverType, shortSummary);
            paperObject.AddBookShowDynamicInher(book);
        }
    }
}

