using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public enum Legend
    {
        Simple,
        Detailed
    }
    public class Map //dynamic dziedziczenie
    {
        // Właściwości klasy Maps
        public string Scale { get; set; }
        public Legend MapLegend { get; set; } // enum do wyboru 2 opcje 

        public PaperObject paperObject { get; set; }

        private Map() { }   

        //dynamic dziedziczenie - te 2 konstruktory
        private Map(PaperObject paperObject, string scale, Legend mapLegend)
        {
            Scale = scale;
            MapLegend = mapLegend;
        }


        public static void AddMapToPaperObject(PaperObject paperObject, string scale, Legend mapLegend)
        {
            if (paperObject is null)
                throw new Exception("Paper object can't be empty");

            Map map = new Map(paperObject, scale, mapLegend);
            paperObject.AddMapShowDynamicInher(map);
        }
        


    }
}
