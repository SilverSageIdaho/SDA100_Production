/*Comment*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SDA100
{
    public partial class mainForm : Form
    {
        string iniSaveData;
        string iniBackupData;
        string PIN = DateTime.Now.ToString("yyyyMMddHH");
        Regex regex = new Regex(@" ^\d{10}$");
        bool isAuth = false;   //user authorization boolean
        
        public void DisplayIniText()
        {
            Console.WriteLine(PIN);
            if (Globals.iniOID != null)
            {
                Console.WriteLine("iniOID not null, values loaded | " + Globals.iniOID);
                TxtIni_MapRes.Text = Convert.ToString(Globals.mapRes);
                TxtIni_WaferDiam.Text = Convert.ToString(Globals.waferDiam);
                TxtIni_EdgeRej.Text = Convert.ToString(Globals.edgeRej);
                TxtIni_SectorSteps.Text = Convert.ToString(Globals.sectorSteps);
                TxtIni_TrackSteps.Text = Convert.ToString(Globals.trackSteps);
                TxtIni_ParkY.Text = Convert.ToString(Globals.parkY);
                TxtIni_ParkX.Text = Convert.ToString(Globals.parkX);
                TxtIni_ParkZ.Text = Convert.ToString(Globals.parkZ);
                TxtIni_PrefocusY.Text = Convert.ToString(Globals.preFocusY);
                TxtIni_PrefocusX.Text = Convert.ToString(Globals.preFocusX);
                TxtIni_PrefocusZ.Text = Convert.ToString(Globals.preFocusZ);

                TxtIni_EditMapRes.Text = Convert.ToString(Globals.mapRes);
                TxtIni_EditWaferDiam.Text = Convert.ToString(Globals.waferDiam);
                TxtIni_EditEdgeRej.Text = Convert.ToString(Globals.edgeRej);
                TxtIni_EditSectorSteps.Text = Convert.ToString(Globals.sectorSteps);
                TxtIni_EditTrackSteps.Text = Convert.ToString(Globals.trackSteps);
                TxtIni_EditParkY.Text = Convert.ToString(Globals.parkY);
                TxtIni_EditParkX.Text = Convert.ToString(Globals.parkX);
                TxtIni_EditParkZ.Text = Convert.ToString(Globals.parkZ);
                TxtIni_EditPrefocusY.Text = Convert.ToString(Globals.preFocusY);
                TxtIni_EditPrefocusX.Text = Convert.ToString(Globals.preFocusX);
                TxtIni_EditPrefocusZ.Text = Convert.ToString(Globals.preFocusZ);
            }
            else
            {
                Console.WriteLine("OID is null - ini values not loaded" + Globals.iniOID);
            }
        }

        private void BtnIni_Save_Click(object sender, EventArgs e)
        {
            CreateIniString();
            UpdateIniGlobals(); 
            SendIniValues();
            

            if (chbox_SetStartupDefaults.Checked == true)
            {
                
                Console.WriteLine(iniSaveData);

                File.Delete(@"C:\ScanBeta\INI\SDA100ini.bkp.txt");
                //System.Threading.Thread.Sleep(1000);                  //Is this needed?
                File.AppendAllText(@"C:\ScanBeta\INI\SDA100ini.bkp.txt",
                                    iniBackupData);
                File.Delete(@"C:\ScanBeta\INI\SDA100ini.txt");
                File.AppendAllText(@"C:\ScanBeta\INI\SDA100ini.txt",
                                    iniSaveData);
                
                iniSaveData = null;
                iniBackupData = null;
                DisplayIniText();
            }
            
        }

        //private void EditLockout()
        //{
        //    if(TxtIni_PIN == null && )
        //    { }
        //}

        private void BtnIni_Edit_Click(object sender, EventArgs e)
        {
            //TxtIni_PIN.Enabled = true;
            //TxtIni_PIN.Visible = true;
            //BtnIni_SubmitPIN.Visible = true;
            isAuth = true;
            TxtIni_PIN.Enabled = false;
            TxtIni_PIN.Visible = false;
            BtnIni_SubmitPIN.Visible = false;
            BtnIni_SubmitPIN.Enabled = false;
            BtnIni_Edit.Enabled = false;
            BtnIni_Save.Enabled = true;
            TxtIni_EditMapRes.ReadOnly = false;
            TxtIni_EditWaferDiam.ReadOnly = false;
            TxtIni_EditEdgeRej.ReadOnly = false;
            TxtIni_EditSectorSteps.ReadOnly = false;
            TxtIni_EditTrackSteps.ReadOnly = false;
            TxtIni_EditParkY.ReadOnly = false;
            TxtIni_EditParkX.ReadOnly = false;
            TxtIni_EditParkZ.ReadOnly = false;
            TxtIni_EditPrefocusY.ReadOnly = false;
            TxtIni_EditPrefocusX.ReadOnly = false;
            TxtIni_EditPrefocusZ.ReadOnly = false;

        }

        private void BtnIni_SubmitPIN_Click(object sender, EventArgs e)
        {
            if (TxtIni_PIN.Text == PIN)
            {
                isAuth = true;
                TxtIni_PIN.Enabled = false;
                TxtIni_PIN.Visible = false;
                BtnIni_SubmitPIN.Visible = false;
                BtnIni_SubmitPIN.Enabled = false;
                BtnIni_Edit.Enabled = false;
                BtnIni_Save.Enabled = true;
                TxtIni_EditMapRes.ReadOnly = false;
            }

        }
        public void CreateIniString()
        {
            iniSaveData = Globals.iniOID + ",";
            iniSaveData += TxtIni_EditMapRes.Text + ",";
            iniSaveData += TxtIni_EditWaferDiam.Text + ",";
            iniSaveData += TxtIni_EditEdgeRej.Text + ",";
            iniSaveData += TxtIni_EditSectorSteps.Text + ",";
            iniSaveData += TxtIni_EditTrackSteps.Text + ",";
            iniSaveData += TxtIni_EditParkY.Text + ",";
            iniSaveData += TxtIni_EditParkX.Text + ",";
            iniSaveData += TxtIni_EditParkZ.Text + ",";
            iniSaveData += TxtIni_EditPrefocusX.Text + ",";
            iniSaveData += TxtIni_EditPrefocusY.Text + ",";
            iniSaveData += TxtIni_EditPrefocusZ.Text + ",";
            iniSaveData += Globals.pSize1Label + ",";
            iniSaveData += Globals.pSize2Label + ",";
            iniSaveData += Globals.pSize3Label + ",";
            iniSaveData += Globals.pSize4Label + ",";
            iniSaveData += Globals.pSize5Label + ",";
            iniSaveData += Globals.pSize6Label + ",";
            iniSaveData += Globals.pSize7Label + ",";
            iniSaveData += Globals.afTimeOut + ",";
            iniSaveData += Globals.dirData + ",";
            iniSaveData += Globals.dirRecipe + ",";
            iniSaveData += Globals.dirINI + ",";
            iniSaveData += Globals.dirSummary;

            iniBackupData = Globals.iniOID + ",";
            iniBackupData += TxtIni_MapRes.Text + ",";
            iniBackupData += TxtIni_WaferDiam.Text + ",";
            iniBackupData += TxtIni_EdgeRej.Text + ",";
            iniBackupData += TxtIni_SectorSteps.Text + ",";
            iniBackupData += TxtIni_TrackSteps.Text + ",";
            iniBackupData += TxtIni_ParkX.Text + ",";
            iniBackupData += TxtIni_ParkY.Text + ",";            
            iniBackupData += TxtIni_ParkZ.Text + ",";
            iniBackupData += TxtIni_PrefocusX.Text + ",";
            iniBackupData += TxtIni_PrefocusY.Text + ",";
            iniBackupData += TxtIni_PrefocusZ.Text + ",";
            iniBackupData += Globals.pSize1Label + ",";
            iniBackupData += Globals.pSize2Label + ",";
            iniBackupData += Globals.pSize3Label + ",";
            iniBackupData += Globals.pSize4Label + ",";
            iniBackupData += Globals.pSize5Label + ",";
            iniBackupData += Globals.pSize6Label + ",";
            iniBackupData += Globals.pSize7Label + ",";
            iniBackupData += Globals.afTimeOut + ",";
            iniBackupData += Globals.dirData + ",";
            iniBackupData += Globals.dirRecipe + ",";
            iniBackupData += Globals.dirINI + ",";
            iniBackupData += Globals.dirSummary;
        }

        public void UpdateIniGlobals()
        {
            //Globals.iniOID = iniData[0];
            Globals.mapRes = int.Parse(TxtIni_EditMapRes.Text);
            Globals.waferDiam = int.Parse(TxtIni_EditWaferDiam.Text);
            Globals.edgeRej = int.Parse(TxtIni_EditEdgeRej.Text);
            Globals.sectorSteps = TxtIni_EditSectorSteps.Text;
            Globals.trackSteps = TxtIni_EditTrackSteps.Text;
            Globals.parkX = TxtIni_EditParkX.Text;
            Globals.parkY = TxtIni_EditParkY.Text;            
            Globals.parkZ = TxtIni_EditParkZ.Text;
            Globals.preFocusX = TxtIni_EditPrefocusX.Text;
            Globals.preFocusY = TxtIni_EditPrefocusX.Text;
            Globals.preFocusZ = TxtIni_EditPrefocusX.Text;            
        }
    }
}
