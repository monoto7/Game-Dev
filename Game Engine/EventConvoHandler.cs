using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: COMMENT
namespace Game_Engine_Player
{
    [Serializable]
    public class EventConvoHandler
    {
        List<int> acceptance_States;
        public List<int> Acceptance_States { get => acceptance_States; set => acceptance_States = value; }

        bool complex;
        public bool Complex { get => complex; set => complex = value; }

        Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> chckSend_State;
        public Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> ChckSend_State { get => chckSend_State; set => chckSend_State = value; }

        int send_State;
        public int Send_State { get => send_State; set => send_State = value; }

        string buttonText;
        public string ButtonText { get => buttonText; set => buttonText = value; }


        Dictionary<int, string> sendText;
        public Dictionary<int, string> SendText { get => sendText; set => sendText = value; }

        public EventConvoHandler()
        {
        }
            public EventConvoHandler(List<int> pAcceptance_States,int pSend_State, string pButtonText, Dictionary<int, string> pSendText)
        {
            Acceptance_States = new List<int>(pAcceptance_States);
            Send_State = pSend_State;
            ButtonText = pButtonText;
            SendText = new Dictionary<int, string>(pSendText);
            Complex = false;
        }


        public EventConvoHandler(List<int> pAcceptance_States, Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> pChckSend_State, string pButtonText, Dictionary<int, string> pSendText)
        {
            Acceptance_States = new List<int>(pAcceptance_States);
            ChckSend_State = new Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>>(pChckSend_State);
            ButtonText = pButtonText;
            SendText = new Dictionary<int, string>(pSendText);
            complex = true;
        }

        public KeyValuePair<int, string> Activate(Character CharCheck)
        {
            if (complex)
            {
                foreach(KeyValuePair<int,Dictionary<string, KeyValuePair<string, KeyValuePair<int,int>>>> StatChecks in ChckSend_State){
                    if (CharCheck.ValueChecks(StatChecks.Value))
                    {
                        return new KeyValuePair<int, string>(StatChecks.Key, SendText[StatChecks.Key]);
                    }
                }
                return new KeyValuePair<int, string>(-1, "Err");
            }
            else
            {
                return new KeyValuePair<int, string>(Send_State, SendText[Send_State]);
            }
        }
        
    }
}
