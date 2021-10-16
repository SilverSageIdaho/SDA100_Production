using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDA100
{
    public partial class mainForm : Form
    {
        public void lbxScanDataFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] eScanData = System.IO.File.ReadAllLines(lbxScanDataFiles.SelectedItem.ToString());
            string[] erecData = eScanData[0].Split(',');

            Emulator.erecipeOID = erecData[0];
            Emulator.eeditDateTime = erecData[1];
            Emulator.erecipeStatus = erecData[2];
            Emulator.erecipeName = erecData[3];
            Emulator.euserName = erecData[4];
            Emulator.escanID = erecData[5];
            Emulator.ewaferDiam = int.Parse(erecData[6]);
            Emulator.eedgeRej = int.Parse(erecData[7]);
            Emulator.escanArea = erecData[8];
            Emulator.ezoneType = erecData[9];
            Emulator.eautoSave = erecData[10];
            Emulator.erecipeNameDefault = erecData[11]; //is this still necessary?
            Emulator.erejectLimitS1 = erecData[12];
            Emulator.erejectLimitS2 = erecData[13];
            Emulator.erejectLimitS3 = erecData[14];
            Emulator.erejectLimitS4 = erecData[15];
            Emulator.erejectLimitS5 = erecData[16];
            Emulator.erejectLimitS6 = erecData[17];
            Emulator.erejectLimitS7 = erecData[18];
            Emulator.erejectLimitTotal = erecData[19];
            Emulator.erecipeComments = erecData[20];

            lbleSizeClass_PSize1_Limit.Text = Emulator.erejectLimitS1;
            lbleSizeClass_PSize2_Limit.Text = Emulator.erejectLimitS2;
            lbleSizeClass_PSize3_Limit.Text = Emulator.erejectLimitS3;
            lbleSizeClass_PSize4_Limit.Text = Emulator.erejectLimitS4;
            lbleSizeClass_PSize5_Limit.Text = Emulator.erejectLimitS5;
            lbleSizeClass_PSize6_Limit.Text = Emulator.erejectLimitS6;
            lbleSizeClass_PSize7_Limit.Text = Emulator.erejectLimitS7;
            lbleSizeClass_PSizeTotal_Limit.Text = Emulator.erejectLimitTotal;

            lbleCCRecipeName_Value.Text = Emulator.erecipeName;
            lbleCCWaferSize_Value.Text = Emulator.ewaferDiam + "mm";

            lbleCCEdgeReject_Value.Text = cbxSSEdgeReject_Set.Text + "mm";
            lbleCCUserID_Value.Text = Emulator.euserName;
            lbleCCScanID_Value.Text = Emulator.escanID;

            string[] einiData = eScanData[1].Split(',');

            Emulator.einiOID = einiData[0];
            Emulator.emapRes = int.Parse(einiData[1]);
            //Emulator.ewaferDiam = int.Parse(einiData[2]); //Supplied with the recipe data
            //Emulator.eedgeRej = int.Parse(einiData[3]);
            Emulator.esectorSteps = einiData[4];
            Emulator.etrackSteps = einiData[5];
            Emulator.eparkY = einiData[6];
            Emulator.eparkX = einiData[7];
            Emulator.eparkZ = einiData[8];
            Emulator.ecenterY = einiData[9];
            Emulator.ecenterX = einiData[10];
            Emulator.epSize1Label = einiData[11];
            Emulator.epSize2Label = einiData[12];
            Emulator.epSize3Label = einiData[13];
            Emulator.epSize4Label = einiData[14];
            Emulator.epSize5Label = einiData[15];
            Emulator.epSize6Label = einiData[16];
            Emulator.epSize7Label = einiData[17];
            Emulator.eafTimeOut = einiData[18];
            Emulator.edirData = einiData[19];
            Emulator.edirRecipe = einiData[20];
            Emulator.edirINI = einiData[21];
            Emulator.edirErrorLog = einiData[22];
            EEdgeReject();
            EMapDefectData(eScanData);
        }
    }
}
