using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SDA100
{
    public partial class mainForm : Form
    {
        public void btnXYM_Front_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_Set.Text + "F");
        }

        private void btnXYM_Left_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_Set.Text + "L");
        }

        private void btnXYM_Right_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_Set.Text + "R");
        }

        private void btnXYM_Back_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_Set.Text + "B");
        }

        private void btnXYM_Home_Click(object sender, EventArgs e)
        {
            serialPort1.Write("H");
        }

        private void btnXYM_Park_Click(object sender, EventArgs e)
        {
            serialPort1.Write("P");
        }

        private void btnXYM_Center_Click(object sender, EventArgs e)
        {
            serialPort1.Write("i");
            serialPort1.Write("I");
        }

        private void btnXYM_DoorStatus_Click(object sender, EventArgs e)
        {
            if (Globals.doorOpenFlag == 1)
            {
                serialPort1.Write("o");
                //btnXYM_DoorStatus.Text = "Close Door";
                //Globals.doorOpenFlag = 0;
                //Globals.doorCloseFlag = 1;                
            }
            else
            {
                serialPort1.Write("n");
                //btnXYM_DoorStatus.Text = "Open Door";
                //Globals.doorOpenFlag = 1;
                //Globals.doorCloseFlag = 0;                
            }
        }

        private void btnXYM_VacuumStatus_Click(object sender, EventArgs e)
        {
            if (Globals.vacChuckFlag == 0)
            {
                serialPort1.Write("O");
                btnXYM_VacuumStatus.Text = "Chuck Vac Off";
                //Globals.vacChuckFlag = 1;

            }
            else
            {
                serialPort1.Write("N");
                btnXYM_VacuumStatus.Text = "Chuck Vac On";
                //Globals.vacChuckFlag = 0;

            }
        }

        private void btnXYM_SetX_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_SetX.Text + "X");
        }

        private void btnXYM_SetY_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_SetY.Text + "Y");
        }

        private void btnXYM_SetZ_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtXYM_SetZ.Text + "Z");
        }

        private void btnZM_Up_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtZM_Set.Text + "U");
        }

        private void btnZM_Down_Click(object sender, EventArgs e)
        {
            serialPort1.Write("." + txtZM_Set.Text + "D");
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
        }

        private void btnSyS_RefreshStatus_Click(object sender, EventArgs e)
        {
            serialPort1.Write("m");
        }
    }
}
