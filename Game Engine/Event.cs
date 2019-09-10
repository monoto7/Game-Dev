using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
    [Serializable]
    public class Event
    {
        List<EventConvoHandler> conversation;
        public List<EventConvoHandler> Conversation { get => conversation; set => conversation = value; }
        //the list of ECH's the event contains

        Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> startStates;
        public Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> StartStates { get => startStates; set => startStates = value; }
        //int is the value being sent? dict is the usual statcheck stuff, see ECH for more description

        Dictionary<int, string> eventImages;
        public Dictionary<int, string> EventImages { get => eventImages; set => eventImages = value; }
        //int is the state being recieved, the string is the imagepath
        Dictionary<int, string> startText;
        public Dictionary<int, string> StartText { get => startText; set => startText = value; }
        //int is the state being recieved, string is the text to display
        Dictionary<int, KeyValuePair<string, string>> acceptStates;
        public Dictionary<int, KeyValuePair<string, string>> AcceptStates { get => acceptStates; set => acceptStates = value; }
        //int is the state being recieved, kvp key string is the destination type e.g a map, kvp value string is the destination itself e.g TestMap1
        Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>> alterStates;
        public Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>> AlterStates { get => alterStates; set => alterStates = value; }
        //int is the state being recieved, kvp key int is the amount a state is changing by/being set to, kvpvaluekey is the stat being altered, kvpvaluevalue is whether its set or not, true = set, false = add
        public Event()
        {

        }


        public Event(List<EventConvoHandler> pConversation, Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> pStartStates, Dictionary<int, KeyValuePair<string, string>> pAcceptStates, Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>> pAlterStates, Dictionary<int, string> pStartText, Dictionary<int, string> images)
        {
            AcceptStates = pAcceptStates;
            StartStates = pStartStates;
            Conversation = pConversation;
            AlterStates = pAlterStates;
            StartText = pStartText;
            EventImages = images;
        }

        public List<EventConvoHandler> GetButtons(int state)
        {
            List<EventConvoHandler> Buttons = new List<EventConvoHandler>();
            foreach (EventConvoHandler CurConvoPart in Conversation)
            {
                foreach(int acceptState in CurConvoPart.Acceptance_States)
                {
                    if (acceptState == state)
                    {
                        Buttons.Add(CurConvoPart);
                    }
                }
            }
            return Buttons;
            //returns the ECH's that have the same acceptstate as the sendstate
        }
        public KeyValuePair<string, string> StateCheck(int pSentState, ref Character CharacterAlt)
        {
            AlterCheck(pSentState, ref CharacterAlt);
            return AcceptCheck(pSentState);
            //checks alterchecks, imagechecks and if this state is an acceptstate
        }
        public void AlterCheck(int pSentState, ref Character CharacterAlt)
        {
            foreach(KeyValuePair<int, KeyValuePair<int, KeyValuePair<string, bool>>> AlterState in AlterStates)
            {
                if(AlterState.Key == pSentState)
                {
                    if (AlterState.Value.Value.Value)
                    {
                        CharacterAlt.ChangeBody(AlterState.Value.Key, AlterState.Value.Value.Key);
                    }
                    else
                    {
                        CharacterAlt.SetBody(AlterState.Value.Key, AlterState.Value.Value.Key);
                    }
                }
            }
            //checks if this state is one where stats are altered, if so, alters those stats
        }
        
        public KeyValuePair<string, string> AcceptCheck(int pSentState)
        {
           foreach(KeyValuePair<int, KeyValuePair<string, string>> AcceptState in AcceptStates)
            {
                if (AcceptState.Key == pSentState)
                {
                    return AcceptState.Value;
                }

            }
            return new KeyValuePair<string, string>(null, null);
            //basically checks if the current state is one that ends the event, the return null,null is effectively acting as a boolean false here
        }
      public KeyValuePair<int, string> GetStartState(Character CharCheck)
        {
            foreach (KeyValuePair<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> StatChecks in startStates)
            {
                if (CharCheck.ValueChecks(StatChecks.Value))
                {
                    return new KeyValuePair<int, string>(StatChecks.Key, StartText[StatChecks.Key]);
                }
                //does the statcheck for each startstate to decide which one is the correct, goes by the first one that matches, this is really easy to fuck up and make certain states inaccessible, was mainly me being lazy and just ripping the usual ECH stuff, might make a default start state thing later
            }
            return new KeyValuePair<int, string>(-1, "Err");
            //this should seriously never show up, otherwise the event doesn't have an acting default state, or the character may not have the stats in question to check them? NOT FULLY TESTED
        }
        //int parameter = 0;
        //int curEvent = 0;
        //public Dictionary<string, int> TestCase(int Routing, Character MainChar)
        //{
        //    Dictionary<string, int> Variables = new Dictionary<string, int>();
        //    switch (curEvent)
        //    {
        //        case 0:
        //            switch (Routing)
        //            {
        //                case 0:
        //                    Variables.Add("Engage", 1);
        //                    Variables.Add("Back up", 4);
        //                    Variables.Add("You see a fucko", 5);
        //                    break;
        //                case 1:
        //                    Variables.Add("Stall", 1);
        //                    Variables.Add("Attackerino", 2);
        //                    Variables.Add("Defenderino", 3);
        //                    Variables.Add(@"'bring it on' says the fucko, wat u do", 5);
        //                    break;
        //                case 2:
                            
                            
        //                    parameter++;
        //                    if (parameter > 4) {
        //                        Variables.Add("A Delicious Dinner Meal", 1);
        //                        Variables.Add(@"fucko a deado", 5);
        //                        curEvent = 1;
        //                    }
        //                    else
        //                    {
        //                        Variables.Add("Push Forward", 1);
        //                        Variables.Add(@"U attack, now press for damage, 'o fuk' says the fucko", 5);
        //                    }
                           
        //                    break;
        //                case 3:
        //                    Variables.Add("Shield Bash", 2);
        //                    Variables.Add("Break Away", 1);
        //                    Variables.Add(@"U prepare to defend, the fucko attacks but misses, what a fuckin dip, wat do", 5);
        //                    break;
        //                case 4:
        //                    Variables.Add("Confront", 0);
        //                    Variables.Add(@"in the distance, something looking gay tbh", 5);
        //                    break;
                            
        //            }
        //            break;
        //        case 1:
        //            switch (Routing)
        //            {
        //                case 0:
        //                    Variables.Add("Consume his organs", 0);
        //                    Variables.Add("Take a break", 1);
        //                    Variables.Add("Organ consumption going A OK", 5);
        //                    break;
        //                case 1:
        //                    Variables.Add("Lets Consume some more", 0);
        //                    Variables.Add("fuck that", 1);
        //                    Variables.Add("Maybe he wasnt such a fucko", 5);
        //                    break;

        //            }
        //            break;
        //    }
        //    return Variables;
        //}
        //old method for reference, might decide 'fuck this' and go back to using it, since its so much fucking nicer(for a small amount of events, this would become unmanageable after a certain point)
    }
}
