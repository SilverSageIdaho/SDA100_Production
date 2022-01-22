using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SDA100
{
    public partial class mainForm : Form
    {
     
        public void btnXYM_Front_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "F");
        }

        private void btnXYM_Left_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "L");
        }

        private void btnXYM_Right_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "R");
        }

        private void btnXYM_Back_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "B");
        }

        private void btnZM_Up_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "U");
        }

        private void btnZM_Down_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("." + txt_moveData.Text + "D");
        }
        
        
        private void btnMaint_StepValue1_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "1";
        }
        private void btnMaint_StepValue10_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "10";
        }

        private void btnMaint_StepValue100_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "100";
        }

        private void btnMaint_StepValue500_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "500";
        }

        private void btnMaint_StepValue1000_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "1000";
        }

        private void btnMaint_StepValue0_Click(object sender, EventArgs e)
        {
            txt_moveData.Text = "0";
        }

        private void btnMaint_SendString_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write(txtMaint_SendString.Text);
            txtMaint_SendString.Text = "";
        }
        private void btnXYM_Home_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("H");
        }

        private void btnMaint_HomeZ_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("h");
        }
        private void btnMaint_ParkXY_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("P");
        }

        private void btnMaint_ParkZ_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("p");
        }
        
        private void btn_Prefocus_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("i");
        }

        private void btnMaint_Focus_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("f");
        }

        private void btnXYM_DoorStatus_Click(object sender, EventArgs e)
        {
            if (Globals.doorOpenFlag == 1)
            {
                ScanPort._serialPort.Write("o");
                btnXYM_DoorStatus.Text = "Close Door";
                Globals.doorOpenFlag = 0;
                Globals.doorCloseFlag = 1;
            }
            else
            {
                ScanPort._serialPort.Write("n");
                btnXYM_DoorStatus.Text = "Open Door";
                Globals.doorOpenFlag = 1;
                Globals.doorCloseFlag = 0;
            }
        }

        private void btnXYM_VacuumStatus_Click(object sender, EventArgs e)
        {
            if (Globals.vacChuckFlag == 0)
            {
                ScanPort._serialPort.Write("O");
                btnXYM_VacuumStatus.Text = "Chuck Vac Off";
                Globals.vacChuckFlag = 1;

            }
            else
            {
                ScanPort._serialPort.Write("N");
                btnXYM_VacuumStatus.Text = "Chuck Vac On";
                Globals.vacChuckFlag = 0;

            }
        }
        private void btnSyS_ReadPHA_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("Q");
        }
        public void UpdateSystemStatusLabels()
        {
            if (Globals.mxFrontLimitFlag == 0)
            {
                lblSyS_FrontLimitX_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_FrontLimitX_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.mxBackLimitFlag == 0)
            {
                lblSyS_BackLimitX_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_BackLimitX_Display.BackColor = Color.LawnGreen;
            }
            if (Globals.myLeftLimitFlag == 0)
            {
                lblSyS_LeftLimitY_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_LeftLimitY_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.myRightLimitFlag == 0)
            {
                lblSyS_RightLimitY_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_RightLimitY_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.mzTopLimitFlag == 0)
            {
                lblSyS_TopLimitZ_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_TopLimitZ_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.mzBottomLimitFlag == 0)
            {
                lblSyS_BottomLimitZ_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_BottomLimitZ_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.vacMainFlag == 0)
            {
                lblSyS_MainVacuum_Display.Text = "Off";
                lblSyS_MainVacuum_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_MainVacuum_Display.Text = "On";
                lblSyS_MainVacuum_Display.BackColor = Color.LawnGreen;
            }

            if (Globals.vacChuckFlag == 0)
            {
                lblSyS_ChuckVacuum_Display.Text = "Off";
                lblSyS_ChuckVacuum_Display.BackColor = Color.Red;
            }
            else
            {
                lblSyS_ChuckVacuum_Display.Text = "On";
                lblSyS_ChuckVacuum_Display.BackColor = Color.LawnGreen;

            }

            if (Globals.doorOpenFlag == 0)
            {
                lblSys_DoorStatus_Display.Text = "Open";
                lblSys_DoorStatus_Display.BackColor = Color.Red;
                btnXYM_DoorStatus.Text = "Close Door";
            }
            else
            {
                lblSys_DoorStatus_Display.Text = "Closed";
                lblSys_DoorStatus_Display.BackColor = Color.LawnGreen;
                btnXYM_DoorStatus.Text = "Open Door";
            }

            txtSyS_XStagePosition.Text = Convert.ToString(Globals.mxPosAbsVal);
            txtSyS_YStagePosition.Text = Convert.ToString(Globals.myPosAbsVal);
            txtSyS_ZStagePosition.Text = Convert.ToString(Globals.mzPosAbsVal);
            txtSyS_AutoFocusValue.Text = Convert.ToString(Globals.autoFocusVal);            
        }

        private void btnSyS_RefreshStatus_Click(object sender, EventArgs e)
        {
            ScanPort._serialPort.Write("m");
        }
    }
}
