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
        string recSaveData;
        private void lbxLoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRecipe = Globals.recLines[lbxLoadBox.SelectedIndex];
            //string selectedRecipe = Globals.recLines[lbxLoadBox.SelectedIndex];
            string[] recData = selectedRecipe.Split(',');

            txtSSRecipeName_Set.Text = recData[3];
            txtSSUserID_Set.Text = recData[4];
            txtSSScanID_Set.Text = recData[5];
            cbxSSWaferSize_Set.Text = recData[6];
            cbxSSEdgeReject_Set.Text = recData[7];
            cbxSSScanOfArea_Set.Text = recData[8];
            //cbxSSZoneScanType_Set.Text = recDate[9]; //add later...currently disabled
            if (recData[10] == "TRUE")
            {
                chboxAutoSave.Checked = true;
            }
            else
            {
                chboxAutoSave.Checked = false;
            }
            //recipeNameDefault = recData[11]; will go here
            txtSizeClass_Size1_Limit.Text = recData[12];
            txtSizeClass_Size2_Limit.Text = recData[13];
            txtSizeClass_Size3_Limit.Text = recData[14];
            txtSizeClass_Size4_Limit.Text = recData[15];
            txtSizeClass_Size5_Limit.Text = recData[16];
            txtSizeClass_Size6_Limit.Text = recData[17];
            txtSizeClass_Size7_Limit.Text = recData[18];
            txtSizeClass_Total_Limit.Text = recData[19];
            txtRecipeComments.Text = recData[20];
        }

        private void PopulateRecipeList()
        {
            string[] recipes = System.IO.File.ReadAllLines(Globals.dirRecipe + "\\SDA100rec.txt");
            foreach(string recipe in recipes)
            {
                Console.WriteLine(recipe);
                string[] recipeData = recipe.Split(',');
                string editDate = recipeData[0];
                string createDate = recipeData[1];
                string recipeName = recipeData[3];
                string userID = recipeData[4];
                string formattedEditDate = FormatDate(editDate);

                //string recipeTitle = recipeName + "   -   " +
                //                    formattedEditDate + "   -   " +
                //                    userID; 
                string[] tableRow = { recipeName, formattedEditDate, userID };
                dataGridView1.Rows.Add(tableRow);
                //lbxLoadBox.Items.Add(recipeTitle);
            }
        }

        private string FormatDate(string dateString)
        {
            string formattedDate = dateString.Substring(0, 4) + "/" +
                                    dateString.Substring(4, 2) + "/" +
                                    dateString.Substring(6, 2);
            return formattedDate;
        }

        private void chboxAutoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxAutoSave.Checked == true)
            {
                Globals.autoSave = "1";
            }
            else
            {
                Globals.autoSave = "0";
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {

            CreateRecipeString();

            System.IO.File.AppendAllText(Globals.dirRecipe + "\\SDA100rec.txt", recSaveData + Environment.NewLine);

            //using (System.IO.StreamWriter sw = System.IO.File.AppendText(@"C:\ScanBeta\SDA100rec.txt"))
            //{
            //    sw.WriteLine(recSaveData);
            //}
            //lbxLoadBox.DataSource = System.IO.File.ReadAllLines(Globals.dirRecipe + "\\SDA100rec.txt");
            OldAssWayOfCleaningUpRecipes();
            //lbxLoadBox.DataSource = System.IO.File.ReadAllLines(@"C:\ScanBeta\SDA100rec.txt");
            PopulateRecipeList();
        }

        private void btnRecipeLoad_Click(object sender, EventArgs e)
        {
            //Load currently selected recipe into the global recipe variables
            Globals.recipeOID = DateTime.Now.ToString("yyyyMMddHHmmss");
            Globals.editDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            Globals.recipeStatus = "Active";
            Globals.recipeName = txtSSRecipeName_Set.Text;
            Globals.userName = txtSSUserID_Set.Text;
            Globals.scanID = txtSSScanID_Set.Text;
            Globals.waferDiam = int.Parse(cbxSSWaferSize_Set.Text);
            Globals.edgeRej = int.Parse(cbxSSEdgeReject_Set.Text);
            Globals.scanArea = cbxSSScanOfArea_Set.Text;
            //Globals.zoneType; will use later
            //Globals.autoSave;
            //Globals.recipeNameDefault;
            Globals.rejectLimitS1 = txtSizeClass_Size1_Limit.Text;
            Globals.rejectLimitS2 = txtSizeClass_Size2_Limit.Text;
            Globals.rejectLimitS3 = txtSizeClass_Size3_Limit.Text;
            Globals.rejectLimitS4 = txtSizeClass_Size4_Limit.Text;
            Globals.rejectLimitS5 = txtSizeClass_Size5_Limit.Text;
            Globals.rejectLimitS6 = txtSizeClass_Size6_Limit.Text;
            Globals.rejectLimitS7 = txtSizeClass_Size7_Limit.Text;
            Globals.rejectLimitTotal = txtSizeClass_Total_Limit.Text;
            Globals.recipeComments = txtRecipeComments.Text;

            serialPort1.Write("." + Globals.waferDiam + "d");
            serialPort1.Write("." + Globals.edgeRej + "e");

            //Update the labels related to recipe on the Main screen
            lblCCRecipeName_Current.Text = Globals.recipeName;
            lblCCWaferSize_Current.Text = cbxSSWaferSize_Set.Text + "mm";

            lblCCEdgeReject_Current.Text = cbxSSEdgeReject_Set.Text + "mm";
            lblCCUserID_Current.Text = Globals.userName;
            lblCCScanID_Current.Text = Globals.scanID;
            lblSizeClass_PSize1_Limit.Text = Globals.rejectLimitS1;
            lblSizeClass_PSize2_Limit.Text = Globals.rejectLimitS2;
            lblSizeClass_PSize3_Limit.Text = Globals.rejectLimitS3;
            lblSizeClass_PSize4_Limit.Text = Globals.rejectLimitS4;
            lblSizeClass_PSize5_Limit.Text = Globals.rejectLimitS5;
            lblSizeClass_PSize6_Limit.Text = Globals.rejectLimitS6;
            lblSizeClass_PSize7_Limit.Text = Globals.rejectLimitS7;
            lblSizeClass_PSizeTotal_Limit.Text = Globals.rejectLimitTotal;
            CreateRecipeString();
            tabGroup.SelectedTab = tabMain;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string recEditData;
            recEditData = DateTime.Now.ToString("yyyyMMddHHmmss") + ","; //Updated
            recEditData += DateTime.Now.ToString("yyyyMMddHHmmss") + ","; //Created
            recEditData += "Active" + ",";
            recEditData += txtSSRecipeName_Set.Text + ",";
            recEditData += txtSSUserID_Set.Text + ",";
            recEditData += txtSSScanID_Set.Text + ",";
            recEditData += cbxSSWaferSize_Set.Text + ",";
            recEditData += cbxSSEdgeReject_Set.Text + ",";
            recEditData += cbxSSScanOfArea_Set.Text + ",";
            recEditData += "5" + ","; //static value since the text box is currently disabled
            if (chboxAutoSave.Checked == true)
            {
                recEditData += "TRUE" + ",";
                Globals.autoSave = "1";
            }
            else
            {
                recEditData += "FALSE" + ",";
                Globals.autoSave = "0";
            }
            recEditData += "text" + ","; //static value since we are deciding on if this is useful or not
            recEditData += txtSizeClass_Size1_Limit.Text + ",";
            recEditData += txtSizeClass_Size2_Limit.Text + ",";
            recEditData += txtSizeClass_Size3_Limit.Text + ",";
            recEditData += txtSizeClass_Size4_Limit.Text + ",";
            recEditData += txtSizeClass_Size5_Limit.Text + ",";
            recEditData += txtSizeClass_Size6_Limit.Text + ",";
            recEditData += txtSizeClass_Size7_Limit.Text + ",";
            recEditData += txtSizeClass_Total_Limit.Text + ",";
            recEditData += txtRecipeComments.Text + ";";

            //System.IO.File.AppendAllText(@"C:\ScanBeta\SDA100rec.txt", recEditData + Environment.NewLine);
            //reclines array gets populated on load
            Globals.recLines[lbxLoadBox.SelectedIndex] = recEditData;
            System.IO.File.Delete(Globals.dirRecipe + "\\SDA100rec.txt");
            System.Threading.Thread.Sleep(1000);
            for (int x = 0; x < lbxLoadBox.Items.Count; x++)
            {
                System.IO.File.AppendAllText(Globals.dirRecipe + "\\SDA100rec.txt", Globals.recLines[x] + Environment.NewLine);
            }
            lbxLoadBox.DataSource = System.IO.File.ReadAllLines(Globals.dirRecipe + "\\SDA100rec.txt");
            PopulateRecipeList();
        }
        public void CreateRecipeString()
        {
            recSaveData = DateTime.Now.ToString("yyyyMMddHHmmss") + ",";
            recSaveData += DateTime.Now.ToString("yyyyMMddHHmmss") + ",";
            recSaveData += "Active" + ",";
            recSaveData += txtSSRecipeName_Set.Text + ",";
            recSaveData += txtSSUserID_Set.Text + ",";
            recSaveData += txtSSScanID_Set.Text + ",";
            recSaveData += cbxSSWaferSize_Set.Text + ",";
            recSaveData += cbxSSEdgeReject_Set.Text + ",";
            recSaveData += cbxSSScanOfArea_Set.Text + ",";
            recSaveData += "5" + ","; //static value since the text box is currently disabled
            if (chboxAutoSave.Checked == true)
            {
                recSaveData += "TRUE" + ",";
                Globals.autoSave = "1";
            }
            else
            {
                recSaveData += "FALSE" + ",";
                Globals.autoSave = "0";
            }
            recSaveData += "text" + ","; //static value since we are deciding on if this is useful or not
            recSaveData += txtSizeClass_Size1_Limit.Text + ",";
            recSaveData += txtSizeClass_Size2_Limit.Text + ",";
            recSaveData += txtSizeClass_Size3_Limit.Text + ",";
            recSaveData += txtSizeClass_Size4_Limit.Text + ",";
            recSaveData += txtSizeClass_Size5_Limit.Text + ",";
            recSaveData += txtSizeClass_Size6_Limit.Text + ",";
            recSaveData += txtSizeClass_Size7_Limit.Text + ",";
            recSaveData += txtSizeClass_Total_Limit.Text + ",";
            recSaveData += txtRecipeComments.Text + ";";
        }
        private void OldAssWayOfCleaningUpRecipes()
        {
            lbxLoadBox.Items.Clear();
            foreach (string recipe in Globals.recLines)
            {
                string[] reclinesParsed = recipe.Split(',');
                lbxLoadBox.Items.Add(reclinesParsed[5] + "\t - \t" + reclinesParsed[0]);
            }
        }
    }
    
}
