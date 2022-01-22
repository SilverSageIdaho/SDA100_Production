using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;

namespace SDA100
{
    public partial class mainForm : Form
    {
        public int trackDefectCnt1;
        public int trackDefectCnt2;
        public int trackDefectCnt3;
        public int trackDefectCnt4;
        public int trackDefectCnt5;
        public int trackDefectCnt6;
        public int trackDefectCnt7;

        public int scanDefectCnt1;
        public int scanDefectCnt2;
        public int scanDefectCnt3;
        public int scanDefectCnt4;
        public int scanDefectCnt5;
        public int scanDefectCnt6;
        public int scanDefectCnt7;

        //double prctComplete;

        Bitmap bmp = new Bitmap(500, 500);
        Bitmap ebmp = new Bitmap(500, 500);

        //static SerialPort ScanPort._serialPort;
        private ErrorHandler errorHandler = new ErrorHandler();

        static AutoResetEvent autoReset = new AutoResetEvent(false);
        //static ManualResetEvent manReset = new ManualResetEvent(false);
                

        //public string filePath;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.Name = "Form Load";
            // *** Find the Scanner Com Port by testing for "?" => "!" ****
            ScanPort.ScanComPorts();
            
            //ScanPort._serialPort = new SerialPort();

            if (!Globals.teensyComPortOK)
            {
                MessageBox.Show("Error", "No COM port found");
            }
            else
            {
                //ScanPort._serialPort.PortName = Globals.teensyComPort;
                //ScanPort._serialPort.BaudRate = 115200;
                //ScanPort._serialPort.DataBits = 8;
                //ScanPort._serialPort.StopBits = StopBits.One;
                //ScanPort._serialPort.Parity = Parity.None;
                //ScanPort._serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                //ScanPort._serialPort.ReadBufferSize = 16384;
                //ScanPort._serialPort.Open();
                
                //splits ini.txt string to an array, and assigns them to global variables
                ScanPort.AssignIniGlobals();
                ScanPort.SendIniValues();
                //populates ini values on ini tab
                DisplayIniText();


                //autoReset.WaitOne(); //Crap Dustin is messing with
                //Console.WriteLine("Right after send:" + Thread.CurrentThread.ManagedThreadId);
                //Console.WriteLine("Thread Name: " + Thread.CurrentThread.Name);
                ScanPort._serialPort.Write("." + Globals.mapRes + "r");
                Console.WriteLine("." + Globals.mapRes + "r");
                Globals.inData = ScanPort.SendReceiveCommands("r");
                txtr_Startup.Text += "." + Globals.mapRes + "r" + ":\t";
                if (Globals.inData.StartsWith("!r"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.waferDiam + "d");
                Console.WriteLine("." + Globals.waferDiam + "d");
                Globals.inData = ScanPort.SendReceiveCommands("d");
                txtr_Startup.Text += "." + Globals.waferDiam + "d" + ":\t";
                if (Globals.inData.StartsWith("!d"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.edgeRej + "e");
                Console.WriteLine("." + Globals.edgeRej + "e");
                Globals.inData = ScanPort.SendReceiveCommands("e");
                txtr_Startup.Text += "." + Globals.edgeRej + "e" + ":\t";
                if (Globals.inData.StartsWith("!e"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.sectorSteps + "S");
                Console.WriteLine("." + Globals.sectorSteps + "S");
                Globals.inData = ScanPort.SendReceiveCommands("S");
                txtr_Startup.Text += "." + Globals.sectorSteps + "S" + ":\t";
                if (Globals.inData.StartsWith("!S"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.trackSteps + "T");
                Console.WriteLine("." + Globals.trackSteps + "T");
                Globals.inData = ScanPort.SendReceiveCommands("T");
                txtr_Startup.Text += "." + Globals.trackSteps + "T" + ":\t";
                if (Globals.inData.StartsWith("!T"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.parkY + "y");
                Console.WriteLine("." + Globals.parkY + "y");
                Globals.inData = ScanPort.SendReceiveCommands("y");
                txtr_Startup.Text += "." + Globals.parkY + "y" + ":\t";
                if (Globals.inData.StartsWith("!y"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.parkX + "x");
                Console.WriteLine("." + Globals.parkX + "x");
                Globals.inData = ScanPort.SendReceiveCommands("x");
                txtr_Startup.Text += "." + Globals.parkX + "x" + ":\t";
                if (Globals.inData.StartsWith("!x"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.parkZ + "z");
                Console.WriteLine("." + Globals.parkZ + "z");
                Globals.inData = ScanPort.SendReceiveCommands("z");
                txtr_Startup.Text += "." + Globals.parkZ + "y" + ":\t";
                if (Globals.inData.StartsWith("!z"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.preFocusZ + "u");
                Console.WriteLine("." + Globals.preFocusZ + "u");
                Globals.inData = ScanPort.SendReceiveCommands("u");
                txtr_Startup.Text += "." + Globals.preFocusZ + "u" + ":\t";
                if (Globals.inData.StartsWith("!u"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.preFocusX + "v");
                Console.WriteLine("." + Globals.preFocusX + "v");
                Globals.inData = ScanPort.SendReceiveCommands("v");
                txtr_Startup.Text += "." + Globals.preFocusX + "v" + ":\t";
                if (Globals.inData.StartsWith("!v"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                ScanPort._serialPort.Write("." + Globals.preFocusY + "w");
                Console.WriteLine("." + Globals.preFocusY + "w");
                Globals.inData = ScanPort.SendReceiveCommands("w");
                txtr_Startup.Text += "." + Globals.preFocusY + "w" + ":\t";
                if (Globals.inData.StartsWith("!w"))
                {
                    txtr_Startup.Text += Globals.inData + Environment.NewLine;
                }
                else
                {
                    txtr_Startup.Text += "No Response" + Environment.NewLine;
                }

                //ScanPort._serialPort.Write("." + Globals.preFocusY + "w");
                //Console.WriteLine("." + Globals.preFocusY + "w");
                //Globals.inData = ScanPort.SendReceiveCommands("w");
                //txtr_Startup.Text += Globals.inData + Environment.NewLine;

                ScanPort._serialPort.Write("m");
                ScanPort._serialPort.Write("h");
                ScanPort._serialPort.Write("H");
                ScanPort._serialPort.Write("m");

                ScanPort._serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                btnRun.Enabled = false;
                //need to add the autofocus time out here when the command is available

                //string recString = System.IO.File.ReadAllText(@"C:\ScanBeta\SDA100rec.txt");
                //string[] recData = iniString.Split(',');
                Globals.recLines = System.IO.File.ReadAllLines(Globals.dirRecipe + "\\SDA100rec.txt");
                Globals.dataFileList = System.IO.Directory.GetFiles(Globals.dirData, "*.txt");
                //lbxLoadBox.Text = "New Recipe";
                //lbxLoadBox.DataSource = System.IO.File.ReadAllLines(Globals.dirRecipe + "\\SDA100rec.txt");
                dataGridView1.Hide();
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Recipe Name";
                dataGridView1.Columns[1].Name = "Edit Date";
                dataGridView1.Columns[2].Name = "User ID";
                //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(2, 255, 0, 0);
                PopulateRecipeList();                
            }
        }

        //private void AssignIniGlobals()
        //{
        //    string iniString = System.IO.File.ReadAllText(@"C:\ScanBeta\INI\SDA100ini.txt");
        //    string[] iniData = iniString.Split(',');
        //    Globals.iniOID = iniData[0];
        //    Globals.mapRes = int.Parse(iniData[1]);
        //    Globals.waferDiam = int.Parse(iniData[2]);
        //    Globals.edgeRej = int.Parse(iniData[3]);
        //    Globals.sectorSteps = iniData[4];
        //    Globals.trackSteps = iniData[5];
        //    Globals.parkY = iniData[6];
        //    Globals.parkX = iniData[7];
        //    Globals.parkZ = iniData[8];
        //    Globals.preFocusX = iniData[9];
        //    Globals.preFocusY = iniData[10];
        //    Globals.preFocusZ = iniData[11];
        //    Globals.pSize1Label = iniData[12];
        //    Globals.pSize2Label = iniData[13];
        //    Globals.pSize3Label = iniData[14];
        //    Globals.pSize4Label = iniData[15];
        //    Globals.pSize5Label = iniData[16];
        //    Globals.pSize6Label = iniData[17];
        //    Globals.pSize7Label = iniData[18];
        //    Globals.afTimeOut = iniData[19];
        //    Globals.dirData = iniData[20];
        //    Globals.dirRecipe = iniData[21];
        //    Globals.dirINI = iniData[22];
        //    Globals.dirSummary = iniData[23];
        //    Console.WriteLine(Globals.iniOID, Globals.mapRes, Globals.waferDiam);
        //}

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Globals.inData = ScanPort._serialPort.ReadLine();
            if (Globals.inData.Contains("<"))
            {
                OpenFile();
            }
            else if (Globals.inData.Contains("$"))
            {
                Globals.scanTrack = Globals.inData;

                using (System.IO.StreamWriter sw = System.IO.File.AppendText(Globals.filePath))
                {
                    sw.WriteLine(Globals.scanTrack);                
                }

                //BeginInvoke(new EventHandler(MapDefectData));
                Invoke(new EventHandler(MapDefectData));
            }
            else if (Globals.inData.Contains("!"))
            {
                if(Globals.inData.Substring(0, 2) == "!f")
                {
                    Console.WriteLine("inData FOCUS: {0}", Globals.inData);
                    Globals.z_focus = Globals.inData.Substring(2, Globals.inData.Length - 2);
                }
                if (Globals.inData.Substring(0, 2) == "!Q")
                {
                    Console.WriteLine("inData PHA: {0}", Globals.inData);
                    Globals.pha = Globals.inData.Substring(2, Globals.inData.Length - 2);
                }
                else if(Globals.inData.Contains("!H"))
                {
                    ScanPort._serialPort.Write("m");
                }
                //*************************************
                //ERROR HANDLING 
                //*************************************

                //Errors will match this regular expression
                //Regex regex = new Regex("^![A-Za-z]{1}0{1}\r{1}$");

                //if(regex.IsMatch(Globals.inData))
                //{
                //    Console.WriteLine("Indata error: {0}", Globals.inData);
                //    char letter = Globals.inData[1];
                //    //int maxFailedAttempts = 3;
                //    switch (letter)
                //    {
                //        case 'O': ScanPort._serialPort.Write("N");
                //                  //Globals.vacChuckFlag = 0;
                //                  Globals.errorMessage = "No wafer detected";
                //            break;
                //        case 'o': Globals.errorMessage = "Door failed to open";
                //                  Globals.doorCloseFlag = 1;
                //            Console.WriteLine("ERROR o");
                //                  //ScanPort._serialPort.Write("n");
                //            break;
                //        case 'n': Globals.errorMessage = "Door failed to close";
                //                  Globals.doorCloseFlag = 0;
                //                  //ScanPort._serialPort.Write("o"); //Open door if failed to close?
                //            break;
                //        case 'H': Globals.errorMessage = "Failed to get to Home";
                //            break;
                //        default: Globals.errorMessage = "Unknown error";
                //            break;
                //    }

                //} //else
                //{
                Globals.scanReply = Globals.inData;
                //autoReset.Set(); //Crap Dustin is messing with
                //Console.WriteLine("Inside \"!\":" + Thread.CurrentThread.ManagedThreadId);
                //Console.WriteLine("Thread Name: " + Thread.CurrentThread.Name);
                BeginInvoke(new EventHandler(ResponseData));
                //}
                //*************************************
                //ERROR HANDLING
                //*************************************
                
            }
            else if (Globals.inData.Contains("*"))
            {
                Globals.statusMessage = Globals.inData;
                BeginInvoke(new EventHandler(MachineStatus));
            }
            else if (Globals.inData.Contains(">"))
            {
                Console.WriteLine("Saw the >!");
                BeginInvoke(new EventHandler(ProgressBarStatus));
                string csvData = Globals.editDateTime + "," + Globals.recipeName + "," + Globals.scanID + "," + scanDefectCnt1 + "," + scanDefectCnt2 + "," + scanDefectCnt3 + "," + scanDefectCnt4 + "," + scanDefectCnt5 + "," + scanDefectCnt6 + "," + scanDefectCnt7;
                System.IO.File.AppendAllText(Globals.dirSummary + "\\ScanSummary.csv", csvData + Environment.NewLine);
                
                ScanPort._serialPort.Write("P");
                ScanPort._serialPort.Write("o");
                ScanPort._serialPort.Write("N");
                                
            }
            else if (Globals.inData.Contains("%"))
            {
                BeginInvoke(new EventHandler(ProgressBarStatus));
            }
            else
            {
                BeginInvoke(new EventHandler(DisplayErrorMessage));
            }
        }

        private void ProgressBarStatus(object sender, EventArgs e)
        {
            string prctComplete;
            if (Globals.inData.Contains(">"))
            {
                prctComplete = 100.ToString();
            }
            else
            {
                prctComplete = Globals.inData.Remove(Globals.inData.Length - 2, 2);
            }
            //prctComplete = (Convert.ToDouble(Globals.inData)) * 100;
            Console.WriteLine(prctComplete + "%");
            progressBar.Value = Convert.ToInt32(prctComplete);
        }
        private void DisplayErrorMessage(object sender, EventArgs e)
        {
            Console.WriteLine("Unknown Response: " + Globals.scanUnknownMessage);
        }

        private void MachineStatus(object sender, EventArgs e)
        {
            ScanPort.UpdateStatus();
            UpdateSystemStatusLabels();
            Console.WriteLine("Machine Status: " + Globals.statusMessage);
            
        }

        private void ResponseData(object sender, EventArgs e)
        {
            //Console.WriteLine("Inside Response Data: " + Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Thread Name: " + Thread.CurrentThread.Name);
            Console.WriteLine("Response Data: " + Globals.scanReply); 
                        
            label16.Text = Globals.z_focus;
            txtSyS_ReadPHA.Text = Globals.pha;

            if (Globals.errorMessage != null)
            {
                string title = "ERROR";
                MessageBox.Show(Globals.errorMessage, title);
                Globals.errorMessage = null;
            }
        }

        private void OpenFile()
        {
            string folderName = Globals.dirData;
            string fileName = Globals.recipeName + "_" + Globals.scanID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";

            Globals.filePath = System.IO.Path.Combine(folderName, fileName);
            using (System.IO.StreamWriter sw = System.IO.File.CreateText(Globals.filePath))
            {
                sw.WriteLine(recSaveData);
                sw.WriteLine(System.IO.File.ReadAllText(Globals.dirINI + "\\SDA100ini.txt"));
            }
        }        

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (lblCCRecipeName_Current.Text == "None")
            {
                string message = "No Recipe selected.";
                string title = "IMPORTANT!";
                MessageBox.Show(message, title);
            }
            else
            {
                lblSizeClass_PSize1_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize2_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize3_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize4_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize5_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize6_Limit.ForeColor = Color.Green;
                lblSizeClass_PSize7_Limit.ForeColor = Color.Green;
                
                EdgeReject();

                trackDefectCnt1 = 0;
                trackDefectCnt2 = 0;
                trackDefectCnt3 = 0;
                trackDefectCnt4 = 0;
                trackDefectCnt5 = 0;
                trackDefectCnt6 = 0;
                trackDefectCnt7 = 0;

                scanDefectCnt1 = 0;
                scanDefectCnt2 = 0;
                scanDefectCnt3 = 0;
                scanDefectCnt4 = 0;
                scanDefectCnt5 = 0;
                scanDefectCnt6 = 0;
                scanDefectCnt7 = 0;

                PostHistData();
                ScanPort._serialPort.Write("O"); //Turn chuck vac on
                CheckForComResponse("O");
                ScanPort._serialPort.Write("n"); //Close door
                CheckForComResponse("n");
                ScanPort._serialPort.Write("i"); //copy ini(uvw) to XYZ and move to that position
                CheckForComResponse("i");
                ScanPort._serialPort.Write("f"); //focus Z
                CheckForComResponse("f");
                ScanPort._serialPort.Write("G"); //Start scan                 
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("g"); // STOP Stage
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (btnLoad.Text == "LOAD")
            {            
                ScanPort._serialPort.Write("P");   // Park Stage at preScan position
                CheckForComResponse("P");
                ScanPort._serialPort.Write("p");     //Park z stage above focus
                ScanPort._serialPort.Write("o");     // Open door
                CheckForComResponse("o");
                ScanPort._serialPort.Write("N");     //Turn chuck vac off
                CheckForComResponse("N");
                btnLoad.Text = "READY";
                btnRun.Enabled = true;

                btnLoad.Enabled = false;
                btnRun.BackColor = Color.FromArgb(0, 192, 0);
                btnLoad.BackColor = Color.Gray;
                btnLoad.Font = new Font(FontFamily.GenericSansSerif, btnLoad.Font.Size - 2, FontStyle.Bold);
                tabGroup.SelectedTab = tabRecipe;
            }            
        }

        private void CheckForComResponse(string command)
        {
            bool gotResponse = false;
            int errorCounter = 1000000;
            do
            {
                if (Globals.scanReply.Contains(command))
                {
                    Console.WriteLine(Globals.scanReply);
                    gotResponse = true;
                }
                errorCounter--;
                if (errorCounter == 0)
                {
                    Console.WriteLine($"The {command} command didn't return a confirmation.");
                    break;
                }
            } while (!gotResponse);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabData_Focus(object sender, EventArgs e)
        {
            foreach (string dataLine in Globals.dataFileList)
            {
                string dataLineParsed = dataLine.Remove(0, 18);
                lbxScanDataFiles.Items.Add(dataLineParsed);
            }
            ScanPort._serialPort.Write("m");
        }

        private void tabRecipe_Focus(object sender, EventArgs e)
        {
            OldAssWayOfCleaningUpRecipes();
        }        
    }
}
