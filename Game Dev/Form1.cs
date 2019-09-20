using System;
using System.Runtime.Serialization;
using System.Collections;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Engine_Player;

using System.Xml;
using System.Xml.Serialization;

using System.IO;
//Below is the source code for the event creation software.
namespace Game_Dev
{
    public partial class Form1 : Form
    {
        bool ComplexChecked;
        List<int> EchAStateList;
        Dictionary<int, string> EchSendText;
        int SendState;
        Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> chckSend_StateDictionary;
        List<string> StateCheckList;
        List<int> ChckSendStateList;
        Event EventCreate;
        List<EventConvoHandler> ECHList;
        Dictionary<int, KeyValuePair<string, string>> FinishDictionary;
        List<int> FinishList;
        Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>> AlterDictionary;
        List<int> AlterList;
        Dictionary<int, string> ImageDictionary;
        List<int> ImageList;
        Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> StartDictionary;
        List<int> StartList;
        Dictionary<int, string> StartText;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Defining objects for use. After the UI revamp most of these if not all will be moved to a proper function to make this cleaner.
            StartList = new List<int>();
            StartText = new Dictionary<int, string>();
            StartDictionary = new Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>>();
            StateCheckList = new List<string>();
            ChckSendStateList = new List<int>();
            FinishList = new List<int>();
            AlterList = new List<int>();
            ImageList = new List<int>();
            SendState = -1;
            EchSendText = new Dictionary<int, string>();
            EchAStateList = new List<int>();
            chckSend_StateDictionary = new Dictionary<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>>();
            FinishDictionary = new Dictionary<int, KeyValuePair<string, string>>();
            AlterDictionary = new Dictionary<int, KeyValuePair<int, KeyValuePair<string, bool>>>();
            ImageDictionary = new Dictionary<int, string>();
            ECHList = new List<EventConvoHandler>();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtbxUpperStat_TextChanged(object sender, EventArgs e)
        {
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            gbxStateCheck.Visible = !gbxStateCheck.Visible;
            ComplexChecked = ComplexChck.Checked;
        }

        private void btnAddSendState_Click(object sender, EventArgs e)
        {
            //Lazy try catches are used throughout, not the best practice for bugfixing, nor good for responsive feedback to users, but this is on the backburner as an issue.
            try { 
            
                if (!StartChck.Checked)
                {
                    if (ComplexChck.Checked)
                    {
                        chckSend_StateDictionary.Add(Convert.ToInt32(txtbxSendState.Text), null);
                        EchSendText.Add(Convert.ToInt32(txtbxSendState.Text), rtxbxSendText.Text);
                        RefreshState();
                    }
                    else
                    {
                        SendState = Convert.ToInt32(txtbxSendState.Text);
                        RefreshState();
                        EchSendText.Clear();
                        EchSendText.Add(SendState, rtxbxSendText.Text);
                    }
                }
                else
                {
                    StartDictionary.Add(Convert.ToInt32(txtbxSendState.Text), null);


                StartText.Add(Convert.ToInt32(txtbxSendState.Text), rtxbxSendText.Text);
                    RefreshState();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }
        }
        private void btnCreateEch_Click(object sender, EventArgs e)
        {
            //Theoretically this allows for duplicate ECH's to be added, since it doesn't update old ECH's, but this has potential uses. Classic 'feature not a bug' arguement :)
            try
            {
                EventConvoHandler ECHAdd;
                if (ComplexChck.Checked)
                {
                    ECHAdd = new EventConvoHandler(EchAStateList, chckSend_StateDictionary, txtbxECHText.Text, EchSendText);
                }
                else
                {
                    ECHAdd = new EventConvoHandler(EchAStateList, SendState, txtbxECHText.Text, EchSendText);
                }
                ECHList.Add(ECHAdd);            
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }
            RefreshECH();
            RefreshNewEch();
        }
        private void RefreshNewEch()
        {
            //This is meant to clean up the UI whenever a new ECH is created. Though I believe there are still a few things missing.
            EchAStateList.Clear();
            chckSend_StateDictionary.Clear();
            RefreshState();
            RefreshStateChecks();
            RefreshAState();
        }

        private void btnDeleteEch_Click(object sender, EventArgs e)
        {
            if (lstbxECH.SelectedIndex != -1)
            {
                ECHList.RemoveAt(lstbxECH.SelectedIndex);
                RefreshECH();
            }
        }
        private void RefreshECH()
        {
            //The refresh functions are mainly used for scalable UI and data handling. The majority of them are quite simple, but make changes to the underlying logic behind ECH's simple.
            //The below refreshes the list box of ECH's.
            lstbxECH.Items.Clear();
            foreach (EventConvoHandler ECH in ECHList)
            {

                string tempstring = ECH.ButtonText + "-";
                foreach (int AcceptState in ECH.Acceptance_States)
                {
                    tempstring += AcceptState.ToString();
                }
                lstbxECH.Items.Add(tempstring);
            }
        }
        private void RefreshStart()
        {

        }
        private void RefreshState()
        {
            //refreshes the 'send states' of an associated ECH
            lstbxState.Items.Clear();
            if (!StartChck.Checked)
            {
                ChckSendStateList.Clear();
                if (ComplexChck.Checked)
                {
                    foreach (KeyValuePair<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> chckSendState in chckSend_StateDictionary)
                    {
                        string tempstring = chckSendState.Key.ToString() + "-" + EchSendText[chckSendState.Key];
                        lstbxState.Items.Add(tempstring);
                        ChckSendStateList.Add(chckSendState.Key);
                    }
                }
                else
                {
                    if (SendState != -1)
                    {
                        lstbxState.Items.Add(SendState);
                    }
                }
                if(lstbxState.Items.Count == 0)
                {
                    ComplexChck.Enabled = true;
                }
                else
                {
                    ComplexChck.Enabled = false;
                }
            }
            else
            {
                StartList.Clear();
                foreach (KeyValuePair<int, Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>> chckSendState in StartDictionary)
                {

                    string tempstring = chckSendState.Key.ToString() + "-" + StartText[chckSendState.Key];
                    lstbxState.Items.Add(tempstring);
                    StartList.Add(chckSendState.Key);
                }


            }
           
        }
        private void RefreshFState()
        {
            //handles refreshing the finish state area
            lstbxFState.Items.Clear();
            FinishList.Clear();
            foreach (KeyValuePair<int, KeyValuePair<string, string>> Fstate in FinishDictionary)
            {
                string tempstring = Fstate.Key.ToString() + "-" + Fstate.Value.Key + "-" + Fstate.Value.Value;
                lstbxFState.Items.Add(tempstring);
                FinishList.Add(Fstate.Key);
            }
        }
        private void RefreshLState()
        {
            //handles refreshing the alter state area
            lstbxLState.Items.Clear();
            AlterList.Clear();
            foreach (KeyValuePair<int, KeyValuePair<int, KeyValuePair<string, bool>>> LState in AlterDictionary)
            {
                string tempstring = LState.Key + "-" + LState.Value.Value.Key;
                lstbxLState.Items.Add(tempstring);
                AlterList.Add(LState.Key);
            }
        }
        private void RefreshAState()
        {
            //handles refreshing the accept state area
            lstbxAState.Items.Clear();
            foreach (int AState in EchAStateList)
            {
                string tempstring = AState.ToString();
                lstbxAState.Items.Add(tempstring);
            }
        }
        private void RefreshIState()
        {
            //handles refreshing the image state area.
            lstbxIState.Items.Clear();
            ImageList.Clear();
            foreach (KeyValuePair<int, string> ImageState in ImageDictionary)
            {
                string tempstring = ImageState.Key + "-" + ImageState.Value;
                lstbxIState.Items.Add(tempstring);
                ImageList.Add(ImageState.Key);
            }
        }
        private void RefreshStateChecks()
        {
            //Handles the refreshing of the stat check area of the software.
            StateCheckList.Clear();
            lstbxStateChecks.Items.Clear();
            if (StartChck.Checked)
            {
                if (StartList.Count != 0 && lstbxState.SelectedIndex != -1)
                {
                    if (StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)] != null)
                    {

                        foreach (KeyValuePair<string, KeyValuePair<string, KeyValuePair<int, int>>> StateCheck in StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)])
                        {
                            string tempstring = StateCheck.Key + "-" + StateCheck.Value.Key + "-" + StateCheck.Value.Value.Key.ToString() + "-" + StateCheck.Value.Value.Value.ToString();
                            StateCheckList.Add(StateCheck.Key);
                            lstbxStateChecks.Items.Add(tempstring);
                        }
                    }
                    else
                    {
                        txtbxStatCheckName.Text = "";
                        cmbxCheckCompare.SelectedIndex = -1;
                        txtbxUpperStat.Text = 0.ToString();
                        txtbxLowerStat.Text = 0.ToString();
                    }

                }
                if (lstbxState.SelectedIndex != -1)
                {
                    txtbxStatCheckName.Text = "";
                    cmbxCheckCompare.SelectedIndex = -1;
                    txtbxUpperStat.Text = 0.ToString();
                    txtbxLowerStat.Text = 0.ToString();
                }
            }
            else
            {
                if (ChckSendStateList.Count != 0 && lstbxState.SelectedIndex != -1)
                {
                    if (chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)] != null)
                    {

                        foreach (KeyValuePair<string, KeyValuePair<string, KeyValuePair<int, int>>> StateCheck in chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)])
                        {
                            string tempstring = StateCheck.Key + "-" + StateCheck.Value.Key + "-" + StateCheck.Value.Value.Key.ToString() + "-" + StateCheck.Value.Value.Value.ToString();
                            StateCheckList.Add(StateCheck.Key);
                            lstbxStateChecks.Items.Add(tempstring);
                        }
                    }
                    else
                    {
                        txtbxStatCheckName.Text = "";
                        cmbxCheckCompare.SelectedIndex = -1;
                        txtbxUpperStat.Text = 0.ToString();
                        txtbxLowerStat.Text = 0.ToString();
                    }

                }
                if (lstbxState.SelectedIndex != -1)
                {
                    txtbxStatCheckName.Text = "";
                    cmbxCheckCompare.SelectedIndex = -1;
                    txtbxUpperStat.Text = 0.ToString();
                    txtbxLowerStat.Text = 0.ToString();
                }
            }
        }

        private void btnAddAState_Click(object sender, EventArgs e)
        {
            try
            {
                EchAStateList.Add(Convert.ToInt32(txtbxAcceptanceStates.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }
            RefreshAState();
        }

        private void btnDeleteAState_Click(object sender, EventArgs e)
        {
  
            if (lstbxAState.SelectedIndex != -1)
            {
                EchAStateList.RemoveAt(lstbxAState.SelectedIndex);
                RefreshAState();
            }
        }

        private void cmbxCheckCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Functionalised for scalability here, namely to follow the format of the other checkboxes.
            cmbxCheckCompareChange();
        }
        private void cmbxCheckCompareChange()
        {
            //Hard index referencing isn't ideal for future change, but string comparisons aren't ideal either.
            //I'll probably have to update this when I revamp the UI
            if (cmbxCheckCompare.SelectedIndex == 3)
            {
                txtbxLowerStat.Show();
            }
            else
            {
                txtbxLowerStat.Hide();
            }
        }

        private void btnAddCheck_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, int> Values = new KeyValuePair<int, int>(Convert.ToInt32(txtbxUpperStat.Text), Convert.ToInt32(txtbxLowerStat.Text));
                KeyValuePair<string, KeyValuePair<int, int>> Comparison = new KeyValuePair<string, KeyValuePair<int, int>>(cmbxCheckCompare.Text, Values);
                if (!StartChck.Checked)
                {
                    if (chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)] == null)
                    {
                        chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)] = new Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>();
                    }
                    chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)].Add(txtbxStatCheckName.Text, Comparison);
                }
                else
                {
                    if (StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)] == null)
                    {
                        StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)] = new Dictionary<string, KeyValuePair<string, KeyValuePair<int, int>>>();
                    }
                    StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)].Add(txtbxStatCheckName.Text, Comparison);
                }
            }
            catch(Exception)
            {

            }
            RefreshStateChecks();
        }

        private void btnDeleteCheck_Click(object sender, EventArgs e)
        {
            if (lstbxStateChecks.SelectedIndex != -1)
            {
                if (StartChck.Checked)
                {
                    StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)].Remove(StateCheckList.ElementAt(lstbxStateChecks.SelectedIndex));
                }
                else
                {
                    chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)].Remove(StateCheckList.ElementAt(lstbxStateChecks.SelectedIndex));
                }
                RefreshStateChecks();
            }
        }

        private void btnDeleteSendState_Click(object sender, EventArgs e)
        {
            if (!StartChck.Checked)
            {
                if (lstbxState.SelectedIndex != -1)
                {
                    if (SendState == -1)
                    {
                        chckSend_StateDictionary.Remove(ChckSendStateList.ElementAt(lstbxState.SelectedIndex));
                        EchSendText.Remove(ChckSendStateList.ElementAt(lstbxState.SelectedIndex));

                    }
                    else
                    {
                        EchSendText.Remove(SendState);
                        SendState = -1;                        
                    }
                }

            }
            else
            {
                StartDictionary.Remove(StartList[lstbxState.SelectedIndex]);
            }
            RefreshState();
            if (lstbxState.Items.Count == 0)
            {
                ComplexChck.Enabled = true;
            }
        }

        private void lstbxStateChecks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxStateChecks.SelectedIndex != -1)
            {
                KeyValuePair<string, KeyValuePair<int, int>> CurCheck;
                if (StartChck.Checked)
                {
                    CurCheck = StartDictionary[StartList.ElementAt(lstbxState.SelectedIndex)][StateCheckList.ElementAt(lstbxStateChecks.SelectedIndex)];
                }
                else
                {
                    CurCheck = chckSend_StateDictionary[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)][StateCheckList.ElementAt(lstbxStateChecks.SelectedIndex)];
                }
                txtbxStatCheckName.Text = StateCheckList.ElementAt(lstbxStateChecks.SelectedIndex);
                txtbxUpperStat.Text = CurCheck.Value.Key.ToString();
                txtbxLowerStat.Text = CurCheck.Value.Value.ToString();
                cmbxCheckCompare.SelectedItem = CurCheck.Key;
                cmbxCheckCompareChange();
            }
        }

        private void lstbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxState.SelectedIndex != -1)
            {
                if (ComplexChck.Checked)
                {

                    if (StartChck.Checked)


                    {
                        rtxbxSendText.Text = StartText[StartList.ElementAt(lstbxState.SelectedIndex)];
                        txtbxSendState.Text = StartList.ElementAt(lstbxState.SelectedIndex).ToString();
                    }
                    else
                    {
                        rtxbxSendText.Text = EchSendText[ChckSendStateList.ElementAt(lstbxState.SelectedIndex)];
                        txtbxSendState.Text = ChckSendStateList.ElementAt(lstbxState.SelectedIndex).ToString();
                    }
                }
                else
                {
                    txtbxSendState.Text = SendState.ToString();

                    rtxbxSendText.Text = EchSendText[SendState];
                }
                RefreshStateChecks();
            }
        }

        private void lstbxECH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //The below code was at one point extremely long winded up until the inclusion of the 'refresh' functions.
            if (lstbxECH.SelectedIndex != -1)
            {
                ComplexChck.Checked = ECHList[lstbxECH.SelectedIndex].Complex;
                if(ECHList[lstbxECH.SelectedIndex].Complex){
                    chckSend_StateDictionary = ECHList[lstbxECH.SelectedIndex].ChckSend_State;
                    ChckSendStateList = chckSend_StateDictionary.Keys.ToList<int>();
                }
                else
                {
                    SendState = ECHList[lstbxECH.SelectedIndex].Send_State;
                }
                EchSendText = ECHList[lstbxECH.SelectedIndex].SendText;
                txtbxECHText.Text = ECHList[lstbxECH.SelectedIndex].ButtonText;
                EchAStateList = ECHList[lstbxECH.SelectedIndex].Acceptance_States;
                RefreshAState();
                RefreshState();
            }
        }

        private void btnAddFState_Click(object sender, EventArgs e)
        {
            //Due to the relative lack of information, addition is easy, as there aren't a great deal of things to consider.
            try
            {
                FinishDictionary.Add(Convert.ToInt32(txtbxFState.Text), new KeyValuePair<string, string>(cmbxFstateType.Text, txtbxFStateDestination.Text));
            }
            catch(Exception)
            {
                MessageBox.Show("invalid input");
            }
            RefreshFState();
        }

        private void btnDeleteFState_Click(object sender, EventArgs e)
        {
            //due to F states only having one type, deletion is extremely simple.
            if (lstbxFState.SelectedIndex != -1)
            {
                FinishDictionary.Remove(FinishList[lstbxFState.SelectedIndex]);
                RefreshFState();
            }
        }

        private void StartChck_CheckedChanged(object sender, EventArgs e)
        {
            //Due to the nature of the start state being complex, but not having accept states, the interface logic is slightly more involved.
            gbxAcceptState.Visible = !gbxAcceptState.Visible;
            if (StartChck.Checked)
            {
                bool ComplexSave = ComplexChecked;
                ComplexChck.Checked = true;
                ComplexChecked = ComplexSave;
                ComplexChck.Enabled = false;
            }
            else
            {
                ComplexChck.Checked = ComplexChecked;
            }
            RefreshState();
            RefreshStateChecks();
            lstbxECH.Enabled = !lstbxECH.Enabled;
            if(lstbxState.Items.Count == 0 && StartChck.Checked != true)
            {            
                ComplexChck.Enabled = true;
            }
        }

        private void btnAddLState_Click(object sender, EventArgs e)
        {
            //Adds alter states to the alter dictionary, not called A state since accept states have that and are more relevant from a coding perspective
            try
            {

                AlterDictionary.Add(Convert.ToInt32(txtbxAState.Text), new KeyValuePair<int, KeyValuePair<string, bool>>(Convert.ToInt32(txtbxAStateValue.Text), new KeyValuePair<string, bool>(txtbxAStateStat.Text, chckbxAStateSet.Checked)));
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }
            RefreshLState();
            
        }

        private void btnDeleteLState_Click(object sender, EventArgs e)
        {
            if (lstbxLState.SelectedIndex != -1)
            {
                AlterDictionary.Remove(AlterList[lstbxLState.SelectedIndex]);
                RefreshLState();
            }
        }

        private void btnAddIState_Click(object sender, EventArgs e)
        {
            try
            {
                ImageDictionary.Add(Convert.ToInt32(txtbxIState.Text), txtbxIStateImage.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }
            RefreshIState();
        }

        private void btnDeleteIstate_Click(object sender, EventArgs e)
        {
            if (lstbxIState.SelectedIndex != -1)
            {
                ImageDictionary.Remove(ImageList[lstbxIState.SelectedIndex]);
                RefreshIState();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataContractSerializer xsSubmit = new DataContractSerializer(typeof(Event));
                var subEvent = new Event(ECHList, StartDictionary, FinishDictionary, AlterDictionary, StartText, ImageDictionary);
                var serializer = new DataContractSerializer(typeof(Event));
                string xmlString;
                using (var sw = new StringWriter())
                {
                    using (var writer = new XmlTextWriter(sw))
                    {
                        writer.Formatting = Formatting.Indented;
                        serializer.WriteObject(writer, subEvent);
                        writer.Flush();
                        xmlString = sw.ToString();
                        File.WriteAllText(txtbxEventName.Text + ".xml", xmlString);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input/some other error");
            }
        }

        private void btnLoadEvent_Click(object sender, EventArgs e)
        {
            DataContractSerializer xsSubmit = new DataContractSerializer(typeof(Event));

            var serializer = new DataContractSerializer(typeof(Event));

            using (var sw = new StreamReader(txtbxLoadFileName.Text + ".xml"))
            {
                using (var reader = new XmlTextReader(sw))
                {
                    var subEvent = serializer.ReadObject(reader) as Event;
                    ECHList = subEvent.Conversation;
                    FinishDictionary = subEvent.AcceptStates;
                    AlterDictionary = subEvent.AlterStates;
                    StartDictionary = subEvent.StartStates;
                    ImageDictionary = subEvent.EventImages;

                    StartText = subEvent.StartText;
                    txtbxEventName.Text = txtbxLoadFileName.Text;
                    RefreshAState();
                    RefreshLState();
                    RefreshFState();
                    RefreshIState();

                    RefreshECH();
                    RefreshState();
                }
            }
        }

        private void lstbxLState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxLState.SelectedIndex != -1)
            {
                txtbxAStateValue.Text = AlterDictionary[AlterList.ElementAt(lstbxLState.SelectedIndex)].Key.ToString();
                txtbxAStateStat.Text = AlterDictionary[AlterList.ElementAt(lstbxLState.SelectedIndex)].Value.Key;
                chckbxAStateSet.Checked = AlterDictionary[AlterList.ElementAt(lstbxLState.SelectedIndex)].Value.Value;
                txtbxAState.Text = AlterList.ElementAt(lstbxLState.SelectedIndex).ToString();
            }
        }

        private void lstbxFState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxFState.SelectedIndex != -1)
            {
                txtbxFStateDestination.Text = FinishDictionary[FinishList.ElementAt(lstbxFState.SelectedIndex)].Key;
                cmbxFstateType.SelectedValue = FinishDictionary[FinishList.ElementAt(lstbxFState.SelectedIndex)].Value;
                txtbxFState.Text = FinishList.ElementAt(lstbxFState.SelectedIndex).ToString();
            }
        }

        private void lstbxIState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxIState.SelectedIndex != -1)
            {
                txtbxIState.Text = ImageList.ElementAt(lstbxIState.SelectedIndex).ToString();
                txtbxIStateImage.Text = ImageDictionary[ImageList.ElementAt(lstbxIState.SelectedIndex)];
            }
        }

        private void lstbxAState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxAState.SelectedIndex != -1)
            {
                txtbxAcceptanceStates.Text = EchAStateList.ElementAt(lstbxAState.SelectedIndex).ToString();
            }
        }

        
    }
}
