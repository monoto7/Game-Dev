using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Game_Engine_Player
{
    static class MapHandler
    {
     //Similar to EventHnandler.cs, just for maps
     //I would not recommend using this.
        public static Map MapGet(string ChosenMap)
        {
            Map MapCreate;
            MapCreate = null;
            switch (ChosenMap)
            {
                case "Test":
                    MapCreate = new Map("Test/Test.png");
                    MapCreate.CreatePOI(10, 10, "Map", "Test2");
                    MapCreate.CreatePOI(50, 50, "Event", "Test");
                    break;
                case "Test2":
                    MapCreate = new Map("Test/Test2.png");
                    MapCreate.CreatePOI(20, 40, "Map", "Test");
                    
                    break;
                default:
                    MapCreate = new Map("Main/Main.png");
                    MapCreate.CreatePOI(10, 10, "Map", "Test");
                    break;
                }
            return MapCreate;
        }
        
    }
}
