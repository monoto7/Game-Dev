using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
   public class Descriptions
    {
        //Code for assigning descriptions to body parts, currently in development.
        Dictionary<string, List<string>> AllDesc;
        public Descriptions(Datapull Data)
        {
            AllDesc = new Dictionary<string, List<string>>();
            int count = 0;
            List<List<string>> TempData = Data.GetDescriptions();
            List<string> BodyParts = TempData.Last();
            TempData.RemoveAt(TempData.IndexOf(TempData.Last()));
            foreach (List<string> TempList in TempData)
            {
                AllDesc.Add(BodyParts[count], TempList);
                count++;
            }

        }
        public string GetDescriptor(string bodypart, int size)
        {
            return AllDesc[bodypart][size];
        }
    }
}
