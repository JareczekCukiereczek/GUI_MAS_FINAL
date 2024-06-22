using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class Program
    {
        private const string FilePathTypeObject = "typeObjectsExtension.json";
        private const string FilePathLibraryObjects = "LibraryObjectExtension.json";
        private const string FilePathPaperObject = "PaperObjectsExtension.json";
        private const string FilePathMap = "MapExtension.json";
        private const string FilePathEmployee = "EmployeeExtension.json";


        public static void X()
        {
            //========================================================================================================Library-Section
            // Tworzenie biblioteki i dodawanie sekcji
            Library library1 = new Library("Biblioteka Miejska na Woli");
            //bibliotek bez sekcji istnieje ale sekcja bez biblioteki nie istnieje
            Library library2 = new Library("Biblioteka Miejska na Bemowie");

            List<Library> libraries = new List<Library>();
            libraries.Add(library1);
            libraries.Add(library2);
            

            Section.createSection(library1, "Nazwa");

            AllObjectsService allObjectsService = new AllObjectsService();
            allObjectsService.saveLibrary(libraries);


            var loaded = allObjectsService.getLibrary();

            foreach (var library in loaded)
            {
                Console.WriteLine(library);
            }



            Human human = new Human("Kuba", "Jaros", 2001, "Wola", Gender.Male);

            Member member1 = new Member(human, "001");

            library1.AddMember(member1);

            Member foundMember1 = library1.GetMemberByMembershipID("001");
            if (foundMember1 != null)
            {
                Console.WriteLine($"Znaleziono członka: {foundMember1}");
            }

            // Dodawanie członków do biblioteki - asocjacja kwalifikowana pomiędzy library a member z wykorzystaniem atrybutu membershipID który jednoznacznie identyfikuje membera
            library1.AddMember(member1); // Kwalifikowana asocjacja: Członkowie są identyfikowani przez MembershipID

            //========================================================================================================LibraryObject-TypeObject


            LibraryObject libraryObject1 = new LibraryObject("Fajnie");
            LibraryObject libraryObject2 = new LibraryObject("zdac masy");

            List<LibraryObject> listLibraryObjects = new List<LibraryObject>();
            listLibraryObjects.Add(libraryObject1);
            listLibraryObjects.Add(libraryObject2);

            TypeObject.createTechObTech("monthly",libraryObject1,"spec1",TechnicalLevel.Advanced);
            allObjectsService.saveLibraryObject(listLibraryObjects);

            var loaded1 = allObjectsService.getLibraryObject();

            foreach (var library in loaded1)
            {
                Console.WriteLine(library);
            }
            //========================================================================================================PaperObject-Book
            PaperObject paperObject1 = new PaperObject("Test0", "A4");
            PaperObject paperObject2 = new PaperObject("Test2", "A3");

            List<PaperObject> paperObjectsBooks = new List<PaperObject>();

            paperObjectsBooks.Add(paperObject1);
            paperObjectsBooks.Add(paperObject2);

            Book.AddBookToPaperObject(paperObject1, "Hard", "Zajebista");
            Book.AddBookToPaperObject(paperObject2, "Slim", "Nudna");

            allObjectsService.savePaperObject(paperObjectsBooks);
            var loaded2 = allObjectsService.getPaperObject();

            foreach (var obj in loaded1)
            {
                Console.WriteLine(obj);
            }

            //========================================================================================================PaperObject-Maps

            PaperObject paperObject3 = new PaperObject("Testcik", "A2");
            PaperObject paperObject4 = new PaperObject("Test4", "A1");

            List<PaperObject> paperObjectsMap = new List<PaperObject>();
            paperObjectsMap.Add(paperObject3); 
            paperObjectsMap.Add(paperObject4);

            Map.AddMapToPaperObject(paperObject3, "1:100", Legend.Detailed);
            Map.AddMapToPaperObject(paperObject4, "1:10", Legend.Simple);

            allObjectsService.savePaperObjectMap(paperObjectsMap);
            var loaded3 = allObjectsService.getPaperObjectMap();

            foreach (var objec in loaded3)
            {
                Console.WriteLine(objec);
            }
            //========================================================================================================Human-Employee

            Human humanEmployee = new Human("Pracownik", "Jeden", 2002, "Ochota", Gender.Female);

            List<Human> humanListEmployee = new List<Human>();

            humanListEmployee.Add(humanEmployee);

            Employee.CreatePartOfEmployeeShowOverlapping(humanEmployee, 007, 2000);
            allObjectsService.saveEmployee(humanListEmployee);

            //========================================================================================================Dynamic
            Console.WriteLine("Dziedziczenie dynamiczne");
            PaperObject paperObject = new PaperObject("Test1","A4");

            Book.AddBookToPaperObject(paperObject, "Hardcover", "Podusmowanie");
            //zamiana na mape
            paperObject.ChangeBookToMap("1:1000", Legend.Detailed);
            Console.WriteLine($"PaperObject jest teraz mapa: {paperObject.Map.Scale} legenda do tego- {paperObject.Map.MapLegend}");

            //ponowna zamaiana na book
            paperObject.ChangeMapToBook("Papierowa", "Nowe podsumowanie");
            Console.WriteLine($"PaperObject jest teraz book: {paperObject.Book.CoverType} podsumowanie- {paperObject.Book.ShortSummary}");

            //========================================================================================================Overlapping
            List<string> charact = new List<string>();
            LibraryObject libek1 = new LibraryObject("overlapping");
            LibraryObject libek2 = new LibraryObject("overlapping");
            TypeObject.createTechObTech("monthly", libek1, "spec1",TechnicalLevel.Advanced);
            TypeObject.createFantaObTech("daily", libek2, charact,Setting.ImagineLands);


            //=========================================================================================================Wieloaskept
            LibraryObject libek2wieloaspekt = new LibraryObject("wieloaspekt");
            PaperObject ppp = new PaperObject("Test","A5");//aspektem PaperObject
            TypeObject.createFantaObTech("monthly", ppp, charact, Setting.ImagineLands);//aspekt TypeObject



            //=========================================================================================================Wielodziedziczenie

            Human humek = new Human("Testowy", "Testowy1", 2000, "Bielany", Gender.Male);
            EmployeeMember employeeMember = new EmployeeMember(humek, "009");
            Human pisarz = new Human("Testowy1", "Testowy2", 2001, "Bielany", Gender.Female);
            Author autorek = new Author(pisarz, "Andrzej", "nowak", 20001, "Wola", Gender.Female);
            employeeMember.AddAuthor(autorek);// metoda z employee
            Library biblioteczka = new Library("Bemowska");
            employeeMember.addLibrary(biblioteczka);//metoda z member


            //=========================================================================================================Polimofrizm
            Human humanek = new Human("Trans","Test",2005,"Praga",Gender.Female);

            Member member = new Member(human, "M001");
            
            EmployeeMember employeeMember10 = new EmployeeMember(human, "EM001");
            Console.WriteLine("Typ obiektu Member: " + member.GetObjectType());
            Console.WriteLine("Typ obiektu EmployeeMember: " + employeeMember.GetObjectType());

        }

    }
}
