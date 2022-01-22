using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SDA100
{
    public partial class mainForm : Form
    {
        private void MapDefectData(object sender, EventArgs e)
        {
            const char DELIM = ';';
            string[] sectors = Globals.scanTrack.Split(DELIM);
            for (int y = 0; y < (sectors.Length - 1); y++)
            {
                string[] DefectVal = sectors[y].Split(',');
                int[] DefectValInt = Array.ConvertAll(DefectVal, int.Parse);
                for (int z = 0; z < DefectVal.Length; z++)
                {
                    switch (DefectValInt[2])
                    {
                        case 0:
                            break;
                        case 1:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.Blue);
                            trackDefectCnt1++;
                            break;
                        case 2:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.BlueViolet);
                            trackDefectCnt2++;
                            break;
                        case 3:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.Fuchsia);
                            trackDefectCnt3++;
                            break;
                        case 4:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.Red);
                            trackDefectCnt4++;
                            break;
                        case 5:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.Orange);
                            trackDefectCnt5++;
                            break;
                        case 6:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.Yellow);
                            trackDefectCnt6++;
                            break;
                        case 7:
                            bmp.SetPixel(DefectValInt[1], DefectValInt[0], Color.LightGreen);
                            trackDefectCnt7++;
                            break;
                    }
                }
                pictureBox1.Image = bmp;

            }
            // total track counts into the wafer scan counts after
            // each track is processed. Then clear track counts
            // and update Histogram bars.
            // scanDefectCnt passes values to the MaxHeight calculator 
            scanDefectCnt1 += trackDefectCnt1;
            scanDefectCnt2 += trackDefectCnt2;
            scanDefectCnt3 += trackDefectCnt3;
            scanDefectCnt4 += trackDefectCnt4;
            scanDefectCnt5 += trackDefectCnt5;
            scanDefectCnt6 += trackDefectCnt6;
            scanDefectCnt7 += trackDefectCnt7;

            trackDefectCnt1 = 0;
            trackDefectCnt2 = 0;
            trackDefectCnt3 = 0;
            trackDefectCnt4 = 0;
            trackDefectCnt5 = 0;
            trackDefectCnt6 = 0;
            trackDefectCnt7 = 0;

            PostHistData();
        }
        public int GetMax(int val1, int val2)
        {
            if (val1 > val2)
            {
                return val1;
            }
            return val2;
        }
        public void PostHistData()
        {
            const int maxTextHeight = 100;
            int maxHeight = 0;
            int maxHeightBar = 0;


            def1.Size = new Size(50, scanDefectCnt1);
            maxHeight = def1.Height;

            def2.Size = new Size(50, scanDefectCnt2);
            maxHeight = GetMax(maxHeight, def2.Height);

            def3.Size = new Size(50, scanDefectCnt3);
            maxHeight = GetMax(maxHeight, def3.Height);

            def4.Size = new Size(50, scanDefectCnt4);
            maxHeight = GetMax(maxHeight, def4.Height);

            def5.Size = new Size(50, scanDefectCnt5);
            maxHeight = GetMax(maxHeight, def5.Height);

            def6.Size = new Size(50, scanDefectCnt6);
            maxHeight = GetMax(maxHeight, def6.Height);

            def7.Size = new Size(50, scanDefectCnt7);
            maxHeight = GetMax(maxHeight, def7.Height);

            // processor to SNAP histogram Y Axis to fixed ranges
            if (maxHeight <= 50)
            {
                maxHeightBar = 50;
            }
            else if ((maxHeight > 50) && (maxHeight <= 100))
            {
                maxHeightBar = 100;
            }
            else if ((maxHeight > 100) && (maxHeight <= 250))
            {
                maxHeightBar = 250;
            }

            else if ((maxHeight > 250) && (maxHeight <= 500))
            {
                maxHeightBar = 500;
            }
            else if ((maxHeight > 500) && (maxHeight <= 1000))
            {
                maxHeightBar = 1000;
            }

            else if ((maxHeight > 1000) && (maxHeight <= 2500))
            {
                maxHeightBar = 2500;
            }
            else if ((maxHeight > 2500) && (maxHeight <= 5000))
            {
                maxHeightBar = 5000;
            }
            else if ((maxHeight > 5000) && (maxHeight <= 10000))
            {
                maxHeightBar = 10000;
            }
            else if ((maxHeight > 1000) && (maxHeight <= 25000))
            {
                maxHeightBar = 25000;
            }
            else if ((maxHeight > 25000) && (maxHeight <= 50000))
            {
                maxHeightBar = 50000;
            }
            else
            {
                maxHeightBar = 100000;
            }

            lblMaxHeightBar.Text = maxHeightBar.ToString();
            lblMidHeightBar.Text = (maxHeightBar / 2).ToString();
            lblMinHeightBar.Text = ("0");

            lblScanDefectCnt1.Text = scanDefectCnt1.ToString();
            lblSizeClass_PSize1_Count.Text = scanDefectCnt1.ToString();
            if (scanDefectCnt1 > int.Parse(Globals.rejectLimitS1))
            {
                lblSizeClass_PSize1_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt2.Text = scanDefectCnt2.ToString();
            lblSizeClass_PSize2_Count.Text = scanDefectCnt2.ToString();
            if (scanDefectCnt2 > int.Parse(Globals.rejectLimitS2))
            {
                lblSizeClass_PSize2_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt3.Text = scanDefectCnt3.ToString();
            lblSizeClass_PSize3_Count.Text = scanDefectCnt3.ToString();
            if (scanDefectCnt3 > int.Parse(Globals.rejectLimitS3))
            {
                lblSizeClass_PSize3_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt4.Text = scanDefectCnt4.ToString();
            lblSizeClass_PSize4_Count.Text = scanDefectCnt4.ToString();
            if (scanDefectCnt4 > int.Parse(Globals.rejectLimitS4))
            {
                lblSizeClass_PSize4_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt5.Text = scanDefectCnt5.ToString();
            lblSizeClass_PSize5_Count.Text = scanDefectCnt5.ToString();
            if (scanDefectCnt5 > int.Parse(Globals.rejectLimitS5))
            {
                lblSizeClass_PSize5_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt6.Text = scanDefectCnt6.ToString();
            lblSizeClass_PSize6_Count.Text = scanDefectCnt6.ToString();
            if (scanDefectCnt6 > int.Parse(Globals.rejectLimitS6))
            {
                lblSizeClass_PSize6_Limit.ForeColor = Color.Red;
            }
            lblScanDefectCnt7.Text = scanDefectCnt7.ToString();
            lblSizeClass_PSize7_Count.Text = scanDefectCnt7.ToString();
            if (scanDefectCnt7 > int.Parse(Globals.rejectLimitS7))
            {
                lblSizeClass_PSize7_Limit.ForeColor = Color.Red;
            }
            lblSizeClass_Total_Count.Text = (scanDefectCnt1 + scanDefectCnt2 + scanDefectCnt3
                + scanDefectCnt4 + scanDefectCnt5 + scanDefectCnt6 + scanDefectCnt7).ToString();
            if ((scanDefectCnt1 + scanDefectCnt2 + scanDefectCnt3
                + scanDefectCnt4 + scanDefectCnt5 + scanDefectCnt6 + scanDefectCnt7)
                > int.Parse(Globals.rejectLimitTotal))
            {
                lblSizeClass_PSize1_Limit.ForeColor = Color.Red;
            }

            //good to scale now replace def height with scaled height
            def1.Height = def1.Height * maxTextHeight / maxHeightBar;
            def2.Height = def2.Height * maxTextHeight / maxHeightBar;
            def3.Height = def3.Height * maxTextHeight / maxHeightBar;
            def4.Height = def4.Height * maxTextHeight / maxHeightBar;
            def5.Height = def5.Height * maxTextHeight / maxHeightBar;
            def6.Height = def6.Height * maxTextHeight / maxHeightBar;
            def7.Height = def7.Height * maxTextHeight / maxHeightBar;

            int disHisx = disHis.Location.X;
            int disHisy = disHis.Location.Y;
            int disHisHeight = disHis.Size.Height;
            int disHisWidth = disHis.Size.Width;

            int def1Am = def1.Size.Height;
            int def1x = def1.Location.X;
            int def1y = def1.Location.Y;

            int def2Am = def2.Size.Height;
            int def2x = def2.Location.X;
            int def2y = def2.Location.Y;

            int def3Am = def3.Size.Height;
            int def3x = def3.Location.X;
            int def3y = def3.Location.Y;

            int def4Am = def4.Size.Height;
            int def4x = def4.Location.X;
            int def4y = def4.Location.Y;

            int def5Am = def5.Size.Height;
            int def5x = def5.Location.X;
            int def5y = def5.Location.Y;

            int def6Am = def6.Size.Height;
            int def6x = def6.Location.X;
            int def6y = def6.Location.Y;

            int def7Am = def7.Size.Height;
            int def7x = def7.Location.X;
            int def7y = def7.Location.Y;

            int disYPoint = disHisy + disHisHeight;

            int bSyPoint1 = disYPoint - def1Am;
            int bSyPoint2 = disYPoint - def2Am;
            int bSyPoint3 = disYPoint - def3Am;
            int bSyPoint4 = disYPoint - def4Am;
            int bSyPoint5 = disYPoint - def5Am;
            int bSyPoint6 = disYPoint - def6Am;
            int bSyPoint7 = disYPoint - def7Am;

            def1.Location = new Point(def1x, bSyPoint1);
            def2.Location = new Point(def2x, bSyPoint2);
            def3.Location = new Point(def3x, bSyPoint3);
            def4.Location = new Point(def4x, bSyPoint4);
            def5.Location = new Point(def5x, bSyPoint5);
            def6.Location = new Point(def6x, bSyPoint6);
            def7.Location = new Point(def7x, bSyPoint7);

        }
        public void EdgeReject()
        {
            //int SizeofWaferMM = 125;
            //int EdgeRejctMM = 5;
            //int MapResolutionPixels = 500;
            int MapRadiusPixels;
            int PixelsPerMM;
            int EdgeRejectPixels;
            int WaferDiamPixels;
            int xPixelLoc;
            int yPixelLoc;
            int ZoneCenterPoint;

            // **** Setup all the variables for calculations - Second the DOUBLES for TRIG Math ****
            double j, i;
            double degrees;
            double angle;
            double sinAngle;
            double cosAngle;
            double ZoneRadiusPixels;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // **** Setup all the variables for calculations - Third the STRINGS ****
            // **** Initial Calculations ****
            PixelsPerMM = Globals.mapRes / Globals.waferDiam;
            EdgeRejectPixels = PixelsPerMM * Globals.edgeRej;
            WaferDiamPixels = PixelsPerMM * (Globals.waferDiam);
            MapRadiusPixels = Globals.mapRes / 2;

            ZoneRadiusPixels = WaferDiamPixels / 2;
            ZoneCenterPoint = Convert.ToInt32(ZoneRadiusPixels) + EdgeRejectPixels;



            // **** TRIG Calculations to draw wafer edge line ****
            for (i = 0; i < 3; i++)
            {
                for (j = 0.2; j < 360;)
                {
                    degrees = j;
                    angle = Math.PI * degrees / 180.0;
                    sinAngle = Math.Sin(angle);
                    cosAngle = Math.Cos(angle);
                    xPixelLoc = MapRadiusPixels + Convert.ToInt32(MapRadiusPixels * cosAngle);
                    yPixelLoc = MapRadiusPixels + Convert.ToInt32(MapRadiusPixels * sinAngle);

                    ((Bitmap)pictureBox1.Image).SetPixel(xPixelLoc, yPixelLoc, Color.Black);
                    //bmp.SetPixel(xPixelLoc, yPixelLoc, Color.Black);
                    j = j + 0.2;
                }
            }

            for (i = 2; i < (EdgeRejectPixels + 2); i++)
            {
                for (j = 0.2; j < 360;)
                {
                    degrees = j;
                    angle = Math.PI * degrees / 180.0;
                    sinAngle = Math.Sin(angle);
                    cosAngle = Math.Cos(angle);
                    xPixelLoc = MapRadiusPixels + Convert.ToInt32((MapRadiusPixels - i) * cosAngle);
                    yPixelLoc = MapRadiusPixels + Convert.ToInt32((MapRadiusPixels - i) * sinAngle);

                    ((Bitmap)pictureBox1.Image).SetPixel(xPixelLoc, yPixelLoc, Color.DarkGray);
                    j = j + 0.2;
                }
            }
            bmp = (Bitmap)pictureBox1.Image;
        }
    }
}
