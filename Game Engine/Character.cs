using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
   public class Character
    {
        string Name;
        int age;
        Dictionary<string, int> bodyparts;
        public Character(string CharName)
        {
            Name = CharName;
            bodyparts = new Dictionary<string, int>();
        }
        public string SingleDesc(Descriptions Desc, string bodypart)
        {
            return Desc.GetDescriptor(bodypart, bodyparts[bodypart]);
        }
        public void AddPart(string name, int size)
        {
            bodyparts.Add(name, size);
        }
        public string FullDesc(Descriptions Desc)
        {
            string description = Name + " \n";
            foreach (KeyValuePair<string, int> a in bodyparts)
            {
                description += "You have a " + Desc.GetDescriptor(a.Key, a.Value) + "\n";
            }
            return description;
        }
        public Dictionary<string, int> GetBody()
            {
            return bodyparts;
            }
        public void SetBody(int Size, string Part)
        {
            bodyparts[Part] = Size;
        }
        public void ChangeBody(int Size, string Part)
        {
            bodyparts[Part] += Size;
        }
        public bool ValueChecks(Dictionary<string, KeyValuePair<string, KeyValuePair<int,int>>> TestPairs)
        {
            int SuccessfulChecks = 0;
            foreach(KeyValuePair<string, KeyValuePair<string, KeyValuePair<int,int>>> TestPair in TestPairs)
            {
                if(TestPair.Value.Key == "GREATER")
                {
                    if (bodyparts[TestPair.Key] > TestPair.Value.Value.Key)
                    {
                        SuccessfulChecks++;
                    }
                }
                else if(TestPair.Value.Key == "LESSER")
                {
                    if (bodyparts[TestPair.Key] < TestPair.Value.Value.Key)
                    {
                        SuccessfulChecks++;
                    }
                }
                else if (TestPair.Value.Key == "BETWEEN")
                {
                    if (bodyparts[TestPair.Key] > TestPair.Value.Value.Value && bodyparts[TestPair.Key] < TestPair.Value.Value.Key)
                    {
                        SuccessfulChecks++;
                    }
                }
                else
                {
                    if (bodyparts[TestPair.Key] == TestPair.Value.Value.Value)
                    {
                        SuccessfulChecks++;
                    }
                }
            }
            if(SuccessfulChecks == TestPairs.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
