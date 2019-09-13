using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
    //POI class, also subject to change to be more robust
    [Serializable]
    class POI
    {
        int x;
        int y;
        string type;
        string destination;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public string Type { get => type; set => type = value; }
        public string Destination { get => destination; set => destination = value; }
        public POI(int pX, int pY, string pType, string pDestination)
        {
            X = pX;
            Y = pY;
            Type = pType;
            Destination = pDestination;
         
        }

        
    }
}
