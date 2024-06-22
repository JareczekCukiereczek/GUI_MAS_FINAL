using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{

    public enum Setting
    {
        ImagineLands,
        FuturisticLands
    }

    public class FantasticLibraryObject
    {

        private List<string> MainCharacters { get; set; }
        public Setting WorldSetting { get; set; } //enum z wyborem miejsca
        private TypeObject TypeObject;

        private FantasticLibraryObject()
        {

        }


        //dziedz.wieloaspekt
        private FantasticLibraryObject(TypeObject typeObject, List<string> maincharacters, Setting worldsetting)
        {
            TypeObject = typeObject;
            MainCharacters = new List<string>(); //lsita głównych bohaterów
            WorldSetting = worldsetting;
        }

        public static void addFantasticToTypeObject(TypeObject typeObject, List<string> maincharacters, Setting worldsetting)
        {
            if (typeObject is null)
                throw new Exception("typeObject can't be null");

            FantasticLibraryObject fanta = new FantasticLibraryObject(typeObject, maincharacters, worldsetting);
            typeObject.AddFantasticLibObject(fanta);
        }

    }
}
