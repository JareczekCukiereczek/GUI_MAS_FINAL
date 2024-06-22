using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
 
    public enum TechnicalLevel
    {
        Basic,
        Advanced
    }
    public class TechnicalLibraryObject
    {
        public string Specialization { get; set; }
        public TechnicalLevel TechLevel { get; set; }//enum do wyboru
        private TypeObject TypeObject { get; set; }

        private TechnicalLibraryObject()
        {

        }
        //dziedz.wieloaspekt + kompozycja do TypeObject
        private TechnicalLibraryObject(TypeObject typeobject, string specialization, TechnicalLevel technicalLevel)
        {
            TypeObject = typeobject;
            Specialization = specialization;
            TechLevel = technicalLevel;
        }

        public static void addTechnicalToTypeObject(TypeObject typeObject, string specialization, TechnicalLevel technicalLevel)
        {
            if (typeObject is null)
                throw new Exception("typeObject can't be null");

            TechnicalLibraryObject technic = new TechnicalLibraryObject(typeObject, specialization, technicalLevel);
            typeObject.AddTechnicalLibObject(technic);
        }

    }
}
