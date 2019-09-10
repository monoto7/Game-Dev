using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Engine_Player
{
    public partial class MainWindow : Form
    {

        int CurEvent;
        Datapull Data;
        Character MainChar;
        Descriptions Desc;
        Dictionary<string, POI> MapPOI;
        Dictionary<string, EventConvoHandler> EventConvo;
        Event CurrentEvent;
        Bitmap ButtonWide;
        Bitmap ButtonWideHover;
        Bitmap BackgroundGeneral;
        Bitmap ButtonGeneral;
        Bitmap ButtonGeneralHover;
        Bitmap ButtonFourBy;
        Bitmap ButtonFourByHover; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonFourBy = new Bitmap(@"Images\UI\elements\button 4x1.png");
            ButtonFourByHover = new Bitmap(@"Images\UI\elements\button 4x1_ho.png");
            ButtonGeneral = new Bitmap(@"Images\UI\elements\button.png");
            ButtonGeneralHover = new Bitmap(@"Images\UI\elements\button_ho.png");
            BackgroundGeneral = new Bitmap(@"Images\UI\elements\background patternResize.png");
            pnlMainMenu.BackgroundImage = new Bitmap(@"Images\UI\main menu bg.png");
            ButtonWide = new Bitmap(@"Images\UI\elements\button wide.png");
            ButtonWideHover = new Bitmap(@"Images\UI\elements\button wide_ho.png");
            btnMainMenuOptions.BackgroundImage = ButtonFourBy;
            btnMainMenuStartGame.BackgroundImage = ButtonFourBy;
            btnMainMenuLoadGame.BackgroundImage = ButtonFourBy;
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //}
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    EventConvo = new Dictionary<string, EventConvoHandler>();
        //    Data = new Datapull();
        //    Desc = new Descriptions(Data);
        //    MainChar = new Character("temp");
        //    MainChar.AddPart("ass", 2);
        //    MainChar.AddPart("titty", 2);
        //    DrawImage(pnlTest, MainChar);
        //    btnTest.Text = MainChar.SingleDesc(Desc, "ass");
        //    testdesc.Text = MainChar.FullDesc(Desc);
        //    Map MapCreate = new Map("Test/Test.png");
        //    MapCreate.CreatePOI(10, 10, "Map", "Test2");
        //    MapRefresh(MapCreate);
        //}

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            //double height = pnlCentre.Height;
            //double width = pnlCentre.Width;
            //height = height / 400;
            //width = width / 796;
            //Size temp = testdesc.Size;
            //btnTest.Location = new Point(Convert.ToInt32(380 * width) - 70, Convert.ToInt32(108 * height) - 10);
            //testdesc.Size = new Size(Convert.ToInt32(150 * width), Convert.ToInt32(144 * height));
            //testdesc.Location = new Point(Convert.ToInt32((595 + (testdesc.Width / 2) * width) - 75), Convert.ToInt32((98 + (testdesc.Height / 2) * height) - 72));

        }

        private void pnlCentre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnWide_MouseEnter(object sender, EventArgs e)
        {
            Control CurButton = sender as Control;
            RadioButton CurRdBtn = sender as RadioButton;
            if (CurRdBtn != null && CurRdBtn.Checked)
            {

            }
            else
            {
                CurButton.BackgroundImage = ButtonWideHover;
            }
            
        }
        private void btnWide_MouseLeave(object sender, EventArgs e)
        {
            Control CurButton = sender as Control;
            RadioButton CurRdBtn = sender as RadioButton;
            if(CurRdBtn != null && CurRdBtn.Checked)
            {
                
            }
            else
            {
                CurButton.BackgroundImage = ButtonWide;
            }
            
        }
        private void btnFourBy_MouseEnter(object sender, EventArgs e)
        {
            Control CurButton = sender as Control;
            CurButton.BackgroundImage = ButtonFourByHover;
        }
        private void btnFourBy_MouseLeave(object sender, EventArgs e)
        {
            Control CurButton = sender as Control;
            CurButton.BackgroundImage = ButtonFourBy;
        }


        private void btnMainMenuStartGame_Click(object sender, EventArgs e)
        {
            ToggleTopBar(true);
            
            pnlMainMenu.Hide();
            // FLPnlCharCreate.BackgroundImage = new 
            
            pnlCharCreate.Visible = true;
            pnlCharViewFull.Visible = true;
            pnlCharViewFull.BringToFront();

        }
        private void ToggleTopBar(Boolean Toggle)
        {
            btnTopclose.BackgroundImage = ButtonGeneral;
            btnTopminimise.BackgroundImage = ButtonGeneral;
            btnTopsave.BackgroundImage = ButtonGeneral;
            btnTopoptions.BackgroundImage = ButtonGeneral;
            btnTopclose.Visible = Toggle;
            btnTopminimise.Visible = Toggle;
            btnTopoptions.Visible = Toggle;
            btnTopsave.Visible = Toggle;
        }

        private void pnlCharCreate_VisibleChanged(object sender, EventArgs e)
        {
            
            Panel Curpanel = sender as Panel;
            Curpanel.BackgroundImage = BackgroundGeneral;
            //panelchange(Curpanel.Controls);
            rdbtnCharCreateAss1.BackgroundImage = ButtonWide;
            rdbtnCharCreateAss2.BackgroundImage = ButtonWide;
            rdbtnCharCreateAss3.BackgroundImage = ButtonWide;
            rdbtnCharCreateAss4.BackgroundImage = ButtonWide;
            rdbtnCharCreateBreasts1.BackgroundImage = ButtonWide;
            rdbtnCharCreateBreasts2.BackgroundImage = ButtonWide;
            rdbtnCharCreateBreasts3.BackgroundImage = ButtonWide;
            rdbtnCharCreateBreasts4.BackgroundImage = ButtonWide;
            rdbtnCharCreatePenis1.BackgroundImage = ButtonWide;
            rdbtnCharCreatePenis2.BackgroundImage = ButtonWide;
            rdbtnCharCreatePenis3.BackgroundImage = ButtonWide;
            rdbtnCharCreatePenis4.BackgroundImage = ButtonWide;
            btnCharCreateFinish.BackgroundImage = ButtonFourBy;


        }
        private void panelchange(Control.ControlCollection controls)
        {
            foreach(Control c in controls)
            {
                if (c is RadioButton)
                {
                    c.BackgroundImage = ButtonWide;
                }
                if (c is Button)
                {
                    c.BackgroundImage = ButtonWide;
                }
                if (c is Panel)
                {
                    c.BackgroundImage = BackgroundGeneral;
                    panelchange(c.Controls);
                }
            }
        }

        private void btnGeneral_MouseEnter(object sender, EventArgs e)
        {
            Button Curbutton = sender as Button;
            Curbutton.BackgroundImage = ButtonGeneralHover;
            
        }
        private void btnGeneral_MouseLeave(object sender, EventArgs e)
        {
            Button Curbutton = sender as Button;
            Curbutton.BackgroundImage = ButtonGeneral;

        }

        private void btnTopminimise_Click(object sender, EventArgs e)
        {

        }

        private void btnTopclose_Click(object sender, EventArgs e)
        {

        }

        private void pnlInventory_VisibleChanged(object sender, EventArgs e)
        {
            pnlInventory.BackgroundImage = BackgroundGeneral;
            pnlInventoryViewInventory.BackgroundImage = new Bitmap(@"Images\UI\elements\panel background inventory.png"); }
                private void MainWindow_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMainMenuLoadGame_Click(object sender, EventArgs e)
        {
            pnlLoad.Visible =  !pnlLoad.Visible;
            pnlOptions.Visible = false;
        }

        private void btnMainMenuOptions_Click(object sender, EventArgs e)
        {       
            pnlOptions.Visible = !pnlOptions.Visible;
            pnlLoad.Visible = false;
        }

        private void BtnWideSelected(object sender, EventArgs e)
        {
            RadioButton CurButton = sender as RadioButton;
            if(CurButton.Checked)
            {
                CurButton.BackgroundImage = new Bitmap(@"Images\UI\elements\button wide_sel.png");  
            }
            else
            {
                CurButton.BackgroundImage = ButtonWide;
            }
        }

        private void pnlCharViewFull_VisibleChanged(object sender, EventArgs e)
        {
            Control CurControl = sender as Control;
            if (pnlCharViewFull.Visible)
            {
                CurControl.BackgroundImage = new Bitmap(@"Images\UI\elements\panel char view.png");
                pnlCharViewText.BackgroundImage = new Bitmap(@"Images\UI\elements\char description.png");
            }
        }

        private void pnlEventView_VisibleChanged(object sender, EventArgs e)
        {
            pnlEventView.BackgroundImage = BackgroundGeneral;
            pnlEventViewEvent.BackgroundImage = new Bitmap(@"Images\UI\elements\panel background inventory.png");
            btnEventViewInventory.BackgroundImage = new Bitmap(@"Images\UI\elements\char frame.png");
            pnlEventViewTextLarge.BackgroundImage = new Bitmap(@"Images\UI\elements\textbox trans_big.png");
            pnlEventViewTextSmall.BackgroundImage = new Bitmap(@"Images\UI\elements\textbox trans_small.png");
        }

        private void btnCharCreateFinish_Click(object sender, EventArgs e)
        {
            pnlEventView.Visible = true;
            pnlCharCreate.Visible = false;
            pnlCharViewFull.Visible = false;
        }

        private void btnEventViewInventory_Click(object sender, EventArgs e)
        {
            pnlCharViewFull.Visible = true;
            pnlInventory.Visible = true;
            pnlEventView.Visible = false;
        }
        //private void MainWindow_ResizeEnd(Object sender, EventArgs e)
        //{
        //    pnlMainMenu.Size = this.Size;
        //}
        //private void DrawImage(Panel curPanel, Character curChar)
        //{
        //    curPanel.Controls.Clear();
        //    List<Image> CurImages = Data.GetImage(curChar.GetBody());
        //    Graphics g = Graphics.FromImage(CurImages[0]);
        //    g.DrawImage(CurImages[1], new Point(0, 0));
        //    PictureBox CurImage = new PictureBox
        //    {
        //        Name = "Kay",
        //        Image = CurImages[0],
        //        Size = new Size(493, 493),
        //        Location = new Point(0, 0)
        //    };


        //    curPanel.Controls.Add(CurImage);


        //}
        private void EventStart(Event CurEvent)
        {
            KeyValuePair<int, string> StartState = CurEvent.GetStartState(MainChar);
            // rtxbxEvent.Text = StartState.Value;
            CurrentEvent = CurEvent;
            EventRefresh(StartState.Key);
        }
        private void EventButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            EventConvoHandler ECHPress = EventConvo[button.Name];
            KeyValuePair<int, string> SendTextState = ECHPress.Activate(MainChar);
           // rtxbxEvent.Text = SendTextState.Value;
            EventConvo.Clear();
            EventRefresh(SendTextState.Key);
        }


        //private void MapButtonClick(object sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    if (MapPOI[button.Name].Type == "Event")
        //    {
        //        EventStart(EventHandler.EventGet(MapPOI[button.Name].Destination));
        //    }
        //    else if (MapPOI[button.Name].Type == "Map")
        //    {
        //        MapRefresh(MapHandler.MapGet(MapPOI[button.Name].Destination));
        //    }
        //}
        //private void MapRefresh(Map CurMap)
        //{
        //    MapPOI.Clear();
        //    PanelMap.Controls.Clear();
        //    PanelMap.BackgroundImage = new Bitmap(CurMap.Imagepath);
        //    foreach(POI CurPoint in CurMap.Points)
        //    {
        //        Button CurButton = new Button
        //        {
        //            Name = CurPoint.Destination + CurPoint.Type,
        //            BackgroundImage = new Bitmap(@"content/icons/IMAGEPOI.png"),
        //            Size = new Size(10, 10),
        //            Location = new Point(CurPoint.X, CurPoint.Y)

        //        };
        //        CurButton.Click += new System.EventHandler(MapButtonClick);
        //        CurButton.FlatStyle = FlatStyle.Flat;
        //        CurButton.FlatAppearance.BorderSize = 0;
        //        MapPOI.Add(CurPoint.Destination + CurPoint.Type, CurPoint);
        //        PanelMap.Controls.Add(CurButton);
        //    }
        //}
        private void EventRefresh(int SendState)
        {
            EventConvo.Clear();
            int ButtonCount = 0;
            int panelheight = pnlEventViewEventButtons.Size.Height / 2;
            int width = Convert.ToInt32(pnlEventViewEventButtons.Size.Width * 0.9);
            int placementX = Convert.ToInt32(pnlEventViewEventButtons.Size.Width - (pnlEventViewEventButtons.Size.Width * 0.7));
            KeyValuePair<string, string> AcceptStateCheck = CurrentEvent.StateCheck(SendState, ref MainChar);
            if (AcceptStateCheck.Key == null)
            {
                foreach (EventConvoHandler ECH in CurrentEvent.Conversation)
                {
                    if (ECH.Acceptance_States.Contains(SendState))
                    {
                        EventConvo.Add(ECH.ButtonText, ECH);
                    }
                }
                int height = (panelheight) / EventConvo.Count();
                foreach (EventConvoHandler CurECH in EventConvo.Values)
                {
                    Button CurButton = new Button
                    {
                        Name = CurECH.ButtonText,
                        Text = CurECH.ButtonText,
                        Size = new Size(width, height),
                        Location = new Point(placementX, panelheight + height * ButtonCount)

                    };
                    CurButton.FlatStyle = FlatStyle.Flat;
                    CurButton.Click += new System.EventHandler(EventButtonClick);
                    ButtonCount++;
                    pnlEventViewEventButtons.Controls.Add(CurButton);
                }
            }
            else if (AcceptStateCheck.Key == "Event")
            {
                EventStart(EventHandler.EventGet(MapPOI[AcceptStateCheck.Key].Destination));
            }
            else if (AcceptStateCheck.Key == "Map")
            {

            }
        }

        //private void pnlT_Paint(object sender, PaintEventArgs e)
        //{

        //}
        //private void Button_Paint(object sender, PaintEventArgs e)
        //{

        //    e.Graphics.RotateTransform(45.0F);
        //    e.Graphics.FillRectangle(new SolidBrush(Color.GreenYellow), new Rectangle(5, 5, 50, 70));
        //    e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(10,10,30,40));

        //}
    }
}
