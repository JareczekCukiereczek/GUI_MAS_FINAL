using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Models;
using System.IO;

namespace WpfApp1.Services
{
    public class AllObjectsService

    {
        //pliki 
        private const string FilePathTypeObject = "typeObjectsExtension.json";
        private const string FilePathAuthor = "AuthorsExtension.json";
        private const string FilePathBook = "BookExtension.json";
        private const string FilePathEmployee = "EmployeeExtension.json";
        private const string FilePathFantastincLibraryObject = "FantastincLibraryObjectExtension.json";
        private const string FilePathHuman  = "HumanExtension.json";
        private const string FilePathLibrary = "LibraryExtension.json";
        private const string FilePathLibraryObject = "LibraryObjectExtension.json";
        private const string FilePathMap = "MapExtension.json";
        private const string FilePathMember = "MembersExtension.json";
        private const string FilePathPaperObject = "PaperObjectsExtension.json";
        private const string FilePathSection = "SectionsExtension.json";
        private const string FilePathTechnicalObject = "TechnicalObjectsExtension.json";
       


        //metody serializacji i deserializacji

        public void setTypeObject(List<TypeObject> typeObjectsList)
        {
            string json = JsonConvert.SerializeObject(typeObjectsList, Formatting.Indented);
            File.WriteAllText(FilePathTypeObject, json);
        }
        public List<TypeObject> getTypeObject()
        {
            if (!File.Exists(FilePathTypeObject))
            {
                return new List<TypeObject>();
            }

            string json = File.ReadAllText(FilePathTypeObject);
            return JsonConvert.DeserializeObject<List<TypeObject>>(json) ?? new List<TypeObject>();
        }
    }
}
