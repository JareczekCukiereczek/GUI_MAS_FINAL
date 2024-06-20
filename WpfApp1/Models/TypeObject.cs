using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public  class TypeObject
    {

        //dziedzicz.wieloaspektowe
        public String PublicationFrequency;

        private LibraryObject libraryObject;

        private TechnicalLibraryObject TechnicalLibraryObject;
        private FantasticLibraryObject FantasticLibraryObject;



        private TypeObject(LibraryObject libraryobject,String publicationFrequency)
        {
            PublicationFrequency = publicationFrequency;
        }
        //dziedzicz.wieloaspektowe - kompozycja do LibraryObject

        public static void createTypeObjectInhMultiAspect(string publicationFrequency, LibraryObject libraryobject)
        {
            if (libraryobject == null)
            {
                throw new Exception("TypeObject can't be empty");
            }
            TypeObject typeObject = new TypeObject(libraryobject,publicationFrequency);
            libraryobject.AddPartToInheritanceMultiAspect(typeObject);
        }




        //overlapping FantasticLibraryObject a TechnicalLibraryObject


        private static List<TechnicalLibraryObject> allTechnicalLibraryObject = new();
        private static List<FantasticLibraryObject> allFantasticlLibraryObject = new();


        public void AddTechnicalLibObject(TechnicalLibraryObject technicalLibraryObject)
        {
            if (TechnicalLibraryObject == technicalLibraryObject)
                throw new Exception("TechnicalLibraryObject is technicalLibraryObject");

            if (allTechnicalLibraryObject.Contains(technicalLibraryObject))
                throw new Exception("TechnicalLibObj is connected with other TypeObject");

            TechnicalLibraryObject = technicalLibraryObject;
            allTechnicalLibraryObject.Add(technicalLibraryObject);
        }

        public void AddFantasticLibObject(FantasticLibraryObject fantasticLibraryObject)
        {
            if (FantasticLibraryObject == fantasticLibraryObject)
                throw new Exception("FantasticLibraryObject is fantasticLibraryObject");

            if (allFantasticlLibraryObject.Contains(fantasticLibraryObject))
                throw new Exception("FantasticLibObj is connected with other TypeObject");

            FantasticLibraryObject = fantasticLibraryObject;
            allFantasticlLibraryObject.Add(fantasticLibraryObject);
        }


        public void RemoveTechnical(TechnicalLibraryObject tech)
        {
            tech = null;
            allTechnicalLibraryObject.Remove(tech);
        }
        public void RemoveFantastic(FantasticLibraryObject fanta)
        {
            fanta= null;
            allFantasticlLibraryObject.Remove(fanta);
        }



    }
}
