﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Game_Engine_Player
{
    public class Datapull
    {
        //Ideally all content pulling would've been handled here, but for a lot of things its almost pointless.
        public List<List<string>> GetDescriptions()
        {
            List<List<string>> AllDescriptions = new List<List<string>>();
            StreamReader S;
            string filepath = @"Content/Descriptions/";
            List<string> bodyparts = new List<string>();
            DirectoryInfo d = new DirectoryInfo(filepath);
            foreach (var file in d.GetFiles("*.txt"))
            {
                bodyparts.Add(file.Name.Substring(0, file.Name.LastIndexOf(".")));
                List<string> partDesciptions = new List<string>();
                S = new StreamReader(file.FullName);
                while (S.Peek() != -1)
                {
                    partDesciptions.Add(S.ReadLine());
                }
                AllDescriptions.Add(partDesciptions);
            }
            AllDescriptions.Add(bodyparts);
            return AllDescriptions;

        }
        public List<System.Drawing.Image> GetImage(Dictionary<string, int> Parts)
        {
            List<List<string>> AllDescriptions = new List<List<string>>();
            List<System.Drawing.Image> bodyparts = new List<System.Drawing.Image>();
            foreach (KeyValuePair<string, int> KV in Parts)
            {
                string filepath = @"Content/Images/" + KV.Key + "/" + KV.Value + ".png";
                bodyparts.Add(System.Drawing.Image.FromFile(filepath));
            }
            return bodyparts;
        }
        public Event GetEvent(String EventName)
        {
            string filepath = @"Modules/Events/" + EventName + ".xml";
            Event EventPull;

            DataContractSerializer xsSubmit = new DataContractSerializer(typeof(Event));
            var serializer = new DataContractSerializer(typeof(Event));
            using (var sw = new StreamReader(filepath))
            {
                using (var reader = new XmlTextReader(sw))
                {
                    EventPull = serializer.ReadObject(reader) as Event;

                }
            }
            return EventPull;
        }

    }
}
