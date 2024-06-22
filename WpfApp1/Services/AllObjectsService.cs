using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApp1.Models;
using System.IO;
using System.Diagnostics;

namespace WpfApp1.Services
{
    public class AllObjectsService

    {
        //pliki 
        private const string FilePathTypeObject = "typeObjectsExtension.json";
        private const string FilePathBook = "BookExtension.json";
        private const string FilePathEmployee = "EmployeeExtension.json";
        private const string FilePathFantastincLibraryObject = "FantastincLibraryObjectExtension.json";
        private const string FilePathLibrary = "LibraryExtension.json";
        private const string FilePathMap = "MapExtension.json";
        private const string FilePathPaperObject = "PaperObjectsExtension.json";
        private const string FilePathSection = "SectionsExtension.json";
        private const string FilePathTechnicalObject = "TechnicalObjectsExtension.json";
        private const string FilePathLibraryObjects = "LibraryObjectExtension.json";




        //metody serializacji i deserializacji 
        //===================================================================================TypeObject

        public void saveTypeObject(List<TypeObject> typeObjectsList)
        {
            string json = JsonConvert.SerializeObject(typeObjectsList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
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
        //===================================================================================Book

        public void saveBook(List<Book> bookList)
        {
            string json = JsonConvert.SerializeObject(bookList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathBook, json);
        }
        public List<Book> getBook()
        {
            if (!File.Exists(FilePathBook))
            {
                return new List<Book>();
            }

            string json = File.ReadAllText(FilePathBook);
            return JsonConvert.DeserializeObject<List<Book>>(json) ?? new List<Book>();
        }

        //===================================================================================Employee


        public void saveEmployee(List<Human> empList)
        {
            string json = JsonConvert.SerializeObject(empList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathEmployee, json);
        }
        public List<Human> getEmployee()
        {
            if (!File.Exists(FilePathEmployee))
            {
                return new List<Human>();
            }

            string json = File.ReadAllText(FilePathEmployee);
            return JsonConvert.DeserializeObject<List<Human>>(json) ?? new List<Human>();
        }

        //===================================================================================FantasticLibraryObject

        public void saveFantastincLibraryObject(List<FantasticLibraryObject> fantasticList)
        {
            string json = JsonConvert.SerializeObject(fantasticList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathFantastincLibraryObject, json);
        }
        public List<FantasticLibraryObject> getFantastincLibraryObject()
        {
            if (!File.Exists(FilePathFantastincLibraryObject))
            {
                return new List<FantasticLibraryObject>();
            }

            string json = File.ReadAllText(FilePathFantastincLibraryObject);
            return JsonConvert.DeserializeObject<List<FantasticLibraryObject>>(json) ?? new List<FantasticLibraryObject>();
        }
        //===================================================================================Library


        public void saveLibrary(List<Library> LibrarycList)
        {
            string json = JsonConvert.SerializeObject(LibrarycList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathLibrary, json);
        }
        public List<Library> getLibrary()
        {
            if (!File.Exists(FilePathLibrary))
            {
                return new List<Library>();
            }

            string json = File.ReadAllText(FilePathLibrary);
            return JsonConvert.DeserializeObject<List<Library>>(json) ?? new List<Library>();
        }
        //===================================================================================Map


        public void savePaperObjectMap(List<PaperObject> mapList)
        {
            string json = JsonConvert.SerializeObject(mapList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathMap, json);
        }
        public List<PaperObject> getPaperObjectMap()
        {
            if (!File.Exists(FilePathMap))
            {
                return new List<PaperObject>();
            }

            string json = File.ReadAllText(FilePathMap);
            return JsonConvert.DeserializeObject<List<PaperObject>>(json) ?? new List<PaperObject>();
        }

        //===================================================================================PaperObject


        public void savePaperObject(List<PaperObject> PaperObjectList)
        {
            string json = JsonConvert.SerializeObject(PaperObjectList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathPaperObject, json);
        }
        public List<PaperObject> getPaperObject()
        {
            if (!File.Exists(FilePathPaperObject))
            {
                return new List<PaperObject>();
            }

            string json = File.ReadAllText(FilePathPaperObject);
            return JsonConvert.DeserializeObject<List<PaperObject>>(json) ?? new List<PaperObject>();
        }

        //===================================================================================Section

        public void saveSection(List<Section> SectionList)
        {
            string json = JsonConvert.SerializeObject(SectionList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathSection, json);
        }
        public List<Section> getSection()
        {
            if (!File.Exists(FilePathSection))
            {
                return new List<Section>();
            }

            string json = File.ReadAllText(FilePathSection);
            return JsonConvert.DeserializeObject<List<Section>>(json) ?? new List<Section>();
        }

        //===================================================================================TechnicalLibraryObject

        public void saveTechnicalObject(List<TechnicalLibraryObject> TechnicalObjectnList)
        {
            string json = JsonConvert.SerializeObject(TechnicalObjectnList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathTechnicalObject, json);
        }
        public List<TechnicalLibraryObject> getTechnicalObject()
        {
            if (!File.Exists(FilePathTechnicalObject))
            {
                return new List<TechnicalLibraryObject>();
            }

            string json = File.ReadAllText(FilePathTechnicalObject);
            return JsonConvert.DeserializeObject<List<TechnicalLibraryObject>>(json) ?? new List<TechnicalLibraryObject>();
        }

        public void saveLibraryObject(List<LibraryObject> libraryObjectList)
        {
            string json = JsonConvert.SerializeObject(libraryObjectList, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText(FilePathLibraryObjects, json);
        }
        public List<LibraryObject> getLibraryObject()
        {
            if (!File.Exists(FilePathLibraryObjects))
            {
                return new List<LibraryObject>();
            }

            string json = File.ReadAllText(FilePathLibraryObjects);
            return JsonConvert.DeserializeObject<List<LibraryObject>>(json) ?? new List<LibraryObject>();
        }
    }
}
