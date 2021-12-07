using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SerialPort serialPort1;
        private ErrorHandler errorHandler = new ErrorHandler();

        //static AutoResetEvent autoReset = new AutoResetEvent(false);
        //static ManualResetEvent manReset = new ManualResetEvent(false);
                

        public string filePath;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            //Thread.CurrentThread.Name = "Form Load";
            // *** Find the Scanner Com Port by testing for "?" => "!" ****
            ScanPort.ScanComPorts();
            
            serialPort1 = new SerialPort();

            if (!Globals.teensyComPortOK)
            {
                MessageBox.Show("Error", "No COM port found");
            }
            else
            {
                serialPort1.PortName = Globals.teensyComPort;
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                serialPort1.ReadBufferSize = 16384;
                serialPort1.Open();

                //splits ini.txt string to an array, and assigns them to global variables
                AssignIniGlobals();

                //populates ini values on ini tab
                DisplayIniText();

                serialPort1.Write("." + Globals.mapRes + "r");
                Console.WriteLine("." + Globals.mapRes + "r");
                //autoReset.WaitOne(); //Crap Dustin is messing with

                serialPort1.Write("." + Globals.waferDiam + "d");
                Console.WriteLine("." + Globals.waferDiam + "d");

                serialPort1.Write("." + Globals.edgeRej + "e");
                Console.WriteLine("." + Globals.edgeRej + "e");

                serialPort1.Write("." + Globals.sectorSteps + "S");
                Console.WriteLine("." + Globals.sectorSteps + "S");

                serialPort1.Write("." + Globals.trackSteps + "T");
                Console.WriteLine("." + Globals.trackSteps + "T");

                serialPort1.Write("." + Globals.parkY + "y");
                Console.WriteLine("." + Globals.parkY + "y");

                serialPort1.Write("." + Globals.parkX + "x");
                Console.WriteLine("." + Globals.parkX + "x");

                serialPort1.Write("." + Globals.parkZ + "z");
                Console.WriteLine("." + Globals.parkZ + "z");

                serialPort1.Write("." + Globals.preFocusZ + "u");
                Console.WriteLine("." + Globals.preFocusZ + "u");

                serialPort1.Write("." + Globals.preFocusX + "v");
                Console.WriteLine("." + Globals.preFocusX + "v");

                serialPort1.Write("." + Globals.preFocusY + "w");
                Console.WriteLine("." + Globals.preFocusY + "w");

                serialPort1.Write("m");
                serialPort1.Write("h");
                serialPort1.Write("H");
                serialPort1.Write("m");

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

        private void AssignIniGlobals()
        {
            string iniString = System.IO.File.ReadAllText(@"C:\ScanBeta\INI\SDA100ini.txt");
            string[] iniData = iniString.Split(',');
            Globals.iniOID = iniData[0];
            Globals.mapRes = int.Parse(iniData[1]);
            Globals.waferDiam = int.Parse(iniData[2]);
            Globals.edgeRej = int.Parse(iniData[3]);
            Globals.sectorSteps = iniData[4];
            Globals.trackSteps = iniData[5];
            Globals.parkY = iniData[6];
            Globals.parkX = iniData[7];
            Globals.parkZ = iniData[8];
            Globals.preFocusX = iniData[9];
            Globals.preFocusY = iniData[10];
            Globals.preFocusZ = iniData[11];
            Globals.pSize1Label = iniData[12];
            Globals.pSize2Label = iniData[13];
            Globals.pSize3Label = iniData[14];
            Globals.pSize4Label = iniData[15];
            Globals.pSize5Label = iniData[16];
            Globals.pSize6Label = iniData[17];
            Globals.pSize7Label = iniData[18];
            Globals.afTimeOut = iniData[19];
            Globals.dirData = iniData[20];
            Globals.dirRecipe = iniData[21];
            Globals.dirINI = iniData[22];
            Globals.dirSummary = iniData[23];
            Console.WriteLine(Globals.iniOID, Globals.mapRes, Globals.waferDiam);
        }

        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Globals.inData = serialPort1.ReadLine();
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

                BeginInvoke(new EventHandler(MapDefectData));
            }
            else if (Globals.inData.Contains("!"))
            {
                if(Globals.inData.Substring(0, 2) == "!f")
                {
                    Console.WriteLine("inData FOCUS: {0}", Globals.inData);
                    Globals.z_focus = Globals.inData.Substring(2, Globals.inData.Length - 2);
                }
                else if(Globals.inData.Contains("!H"))
                {
                    serialPort1.Write("m");
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
                //        case 'O': serialPort1.Write("N");
                //                  //Globals.vacChuckFlag = 0;
                //                  Globals.errorMessage = "No wafer detected";
                //            break;
                //        case 'o': Globals.errorMessage = "Door failed to open";
                //                  Globals.doorCloseFlag = 1;
                //            Console.WriteLine("ERROR o");
                //                  //serialPort1.Write("n");
                //            break;
                //        case 'n': Globals.errorMessage = "Door failed to close";
                //                  Globals.doorCloseFlag = 0;
                //                  //serialPort1.Write("o"); //Open door if failed to close?
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
                //BeginInvoke?
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
                //using (System.IO.StreamWriter sw = System.IO.File.CreateText(Globals.filePath + ".csv"))
                //{
                //    sw.WriteLine(csvData);
                //}
                serialPort1.Write("P");
                serialPort1.Write("o");
                serialPort1.Write("N");
                                
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

            if(Globals.errorMessage != null)
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
                //sw.Write("INI Info: ");
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
                serialPort1.Write("O"); //Turn chuck vac on
                CheckForComResponse("O");
                serialPort1.Write("n"); //Close door
                CheckForComResponse("n");
                serialPort1.Write("i"); //copy ini(uvw) to XYZ
                CheckForComResponse("i");
                serialPort1.Write("f"); //focus Z
                CheckForComResponse("f");
                serialPort1.Write("G"); //Start scan                 
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            serialPort1.Write("g"); // STOP Stage
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            if (btnLoad.Text == "LOAD")
            {            
                serialPort1.Write("P");   // Park Stage at preScan position
                CheckForComResponse("P");
                serialPort1.Write("p");     //Park z stage above focus
                serialPort1.Write("o");     // Open door
                CheckForComResponse("o");
                serialPort1.Write("N");     //Turn chuck vac off
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
        }

        private void tabRecipe_Focus(object sender, EventArgs e)
        {
            OldAssWayOfCleaningUpRecipes();
        }
    }
}
