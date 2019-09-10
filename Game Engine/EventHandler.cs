using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine_Player
{
    static class EventHandler
    {
        public static Event EventGet(string ChosenMap)
        {
            Event EventCreate;
            EventCreate = null;
            switch (ChosenMap)
            {
                case "Test":
                    List<EventConvoHandler> ECHList = new List<EventConvoHandler>();
                    List<int> pAcceptanceStates = new List<int>();
                    pAcceptanceStates.Add(2);
                    pAcceptanceStates.Add(3);
                    Dictionary<int, string> pSendText = new Dictionary<int, string>();
                    pSendText.Add(4, "You Punch Him");
                    pSendText.Add(5, "You Miss");
                    KeyValuePair<int, int> UpperLowerValues = new KeyValuePair<int, int>(3, -1);
                    KeyValuePair<string, KeyValuePair<int, int>> CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("GREATER",UpperLowerValues);
                    Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>> AttributeCheck = new Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>();
                    AttributeCheck.Add("ass", CheckValues);
                    Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> pSendState = new Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>>();
                    pSendState.Add(4, AttributeCheck);
                    UpperLowerValues = new KeyValuePair<int, int>(4, -1);
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("LESSER", UpperLowerValues);
                    AttributeCheck.Clear();
                    AttributeCheck.Add("ass",CheckValues);
                    pSendState.Add(5, AttributeCheck);
                    EventConvoHandler Cur = new EventConvoHandler(pAcceptanceStates,pSendState,"Punch",pSendText);
                    ECHList.Add(Cur);
                    pSendText.Clear();
                    List<int> pAcceptanceStates1 = new List<int>();
                    pAcceptanceStates1.Add(5);
                    pSendText.Add(2, "You recover");
                    pSendText.Add(3, "You fail to recover");
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("GREATER", UpperLowerValues);
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(2, AttributeCheck);
                    AttributeCheck.Clear();
                    UpperLowerValues = new KeyValuePair<int, int>(5, -1);
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("LESSER", UpperLowerValues);
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(3, AttributeCheck);
                    AttributeCheck.Clear();
                    Cur = new EventConvoHandler(pAcceptanceStates1, pSendState, "Recover", pSendText);
                    pSendState.Clear();
                    ECHList.Add(Cur);
                    pSendText.Clear();
                    List<int> pAcceptanceStates2 = new List<int>();
                    pAcceptanceStates2.Add(2);
                    pSendText.Add(2, "You Kick Him");
                    pSendText.Add(5, "You fail to kick");
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("GREATER", UpperLowerValues);
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(2, AttributeCheck);
                    AttributeCheck.Clear();
                    UpperLowerValues = new KeyValuePair<int, int>(5, -1);
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("LESSER", UpperLowerValues);
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(5, AttributeCheck);
                    Cur = new EventConvoHandler(pAcceptanceStates2, pSendState, "Kick", pSendText);
                    pSendState.Clear();
                    ECHList.Add(Cur);
                    ECHList.Add(Cur);
                    pSendText.Clear();
                    List<int> pAcceptanceStates3 = new List<int>();
                    pAcceptanceStates3.Add(4);
                    pSendText.Add(1, "You Kill Him");
                    pSendText.Add(2, "You fail to kill");
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("GREATER", UpperLowerValues);
                    AttributeCheck.Clear();
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(1, AttributeCheck);
                    AttributeCheck.Clear();
                    UpperLowerValues = new KeyValuePair<int, int>(5, -1);
                    CheckValues = new KeyValuePair<string, KeyValuePair<int, int>>("LESSER", UpperLowerValues);
                    AttributeCheck.Add("size", CheckValues);
                    pSendState.Add(7, AttributeCheck);
                    Cur = new EventConvoHandler(pAcceptanceStates3, pSendState, "Kill Him", pSendText);
                    ECHList.Add(Cur);
                    KeyValuePair<int, int> StartStateCheck = new KeyValuePair<int, int>(10, 1);
                    KeyValuePair<string, KeyValuePair<int, int>> StartStateChecks = new KeyValuePair<string, KeyValuePair<int, int>>("BETWEEN", StartStateCheck);
                    Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>> pStartState = new Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>();
                    pStartState.Add("ass", StartStateChecks);
                    Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> pStartStates = new Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>>();
                    pStartStates.Add(3,pStartState);
                    Dictionary<int, KeyValuePair<string, string>> pAcceptStates = new Dictionary<int, KeyValuePair<string, string>>();
                    KeyValuePair<string, string> AcceptState = new KeyValuePair<string, string>("Map", "Test");
                    pAcceptStates.Add(7, AcceptState);
                    Dictionary<int, string> StartText = new Dictionary<int, string>();
                    StartText.Add(3, "FIGHTO");
                    //EventCreate = new Event(ECHList,pStartStates, pAcceptStates,null, StartText);
                    //Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>> pAlterStates = new Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>>();
                    //KeyValuePair<string, bool> bodyset = new KeyValuePair<string, bool>("head", false);
                    //KeyValuePair<int, KeyValuePair<string, bool>> AlterState = new KeyValuePair<int, KeyValuePair<string, bool>>(1, bodyset);
                    //pAlterStates.Add(3,AlterState);
                    //EventCreate = new Event(ECHList, pStartStates, pAcceptStates, pAlterStates, StartText);
                    break;
                

            }
            return EventCreate;
        }
    }
}
