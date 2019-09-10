using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
    [Serializable]
    class Map
    {
        string imagepath;
        public string Imagepath { get => imagepath; set => imagepath = value; }
        public List<POI> Points { get => points; set => points = value; }
        List<POI> points = new List<POI>();
        public Map(string pImagePath)
        {
            Imagepath = @"content/maps/" + pImagePath;
        }
        public void AddPOI(POI pPOI)
        {
            Points.Add(pPOI);
        }
        public void CreatePOI(int pX, int pY, string pType, string pDestination)
        {
            POI POICreate = new POI(pX, pY, pType, pDestination);
            Points.Add(POICreate);
        }

    }
}
