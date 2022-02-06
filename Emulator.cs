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

namespace SDA100
{
    class Emulator
    {
        public static string einiOID;
        public static int emapRes;
        public static int ewaferDiam;
        public static int eedgeRej;
        public static string esectorSteps;
        public static string etrackSteps;
        public static string eparkY;
        public static string eparkX;
        public static string eparkZ;
        public static string ecenterY;
        public static string ecenterX;
        public static string epSize1Label;
        public static string epSize2Label;
        public static string epSize3Label;
        public static string epSize4Label;
        public static string epSize5Label;
        public static string epSize6Label;
        public static string epSize7Label;
        public static string eafTimeOut;
        public static string edirData;
        public static string edirRecipe;
        public static string edirINI;
        public static string edirErrorLog;

        public static string erecipeOID;
        public static string eeditDateTime;
        public static string erecipeStatus;
        public static string erecipeName;
        public static string euserName;
        public static string escanID;
        public static string escanArea;
        public static string ezoneType;
        public static string eautoSave;
        public static string erecipeNameDefault; //is this still necessary?
        public static string erejectLimitS1;
        public static string erejectLimitS2;
        public static string erejectLimitS3;
        public static string erejectLimitS4;
        public static string erejectLimitS5;
        public static string erejectLimitS6;
        public static string erejectLimitS7;
        public static string erejectLimitTotal;
        public static string erecipeComments;

        public static int etrackDefectCnt1;
        public static int etrackDefectCnt2;
        public static int etrackDefectCnt3;
        public static int etrackDefectCnt4;
        public static int etrackDefectCnt5;
        public static int etrackDefectCnt6;
        public static int etrackDefectCnt7;

        public static int escanDefectCnt1;
        public static int escanDefectCnt2;
        public static int escanDefectCnt3;
        public static int escanDefectCnt4;
        public static int escanDefectCnt5;
        public static int escanDefectCnt6;
        public static int escanDefectCnt7;        
        }

    public partial class mainForm : Form
    {
        private void EMapDefectData(string[] eScanData)
        {
        for (int x = 4; x < eScanData.Length; x++)
        {
            string eScanTrack = eScanData[x];
            const char DELIM = ';';
            string[] esectors = eScanTrack.Split(DELIM);
            for (int y = 0; y < (esectors.Length - 1); y++)
            {
                string[] eDefectVal = esectors[y].Split(',');
                int[] eDefectValInt = Array.ConvertAll(eDefectVal, int.Parse);
                for (int z = 0; z < eDefectVal.Length; z++)
                {
                    switch (eDefectValInt[2])
                    {
                        case 0:
                            break;
                        case 1:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.Blue);
                            Emulator.etrackDefectCnt1++;
                            break;
                        case 2:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.BlueViolet);
                            Emulator.etrackDefectCnt2++;
                            break;
                        case 3:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.Fuchsia);
                            Emulator.etrackDefectCnt3++;
                            break;
                        case 4:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.Red);
                            Emulator.etrackDefectCnt4++;
                            break;
                        case 5:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.Orange);
                            Emulator.etrackDefectCnt5++;
                            break;
                        case 6:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.Yellow);
                            Emulator.etrackDefectCnt6++;
                            break;
                        case 7:
                            ebmp.SetPixel(eDefectValInt[1], eDefectValInt[0], Color.LightGreen);
                            Emulator.etrackDefectCnt7++;
                            break;
                    }
                }
                eScanDataImage.Image = ebmp;

            }
            // total track counts into the wafer scan counts after
            // each track is processes. Then clear track counts
            // and update Histogram bars.
            // scanDefectCnt passes values to the MaxHeight calculator 
            Emulator.escanDefectCnt1 += Emulator.etrackDefectCnt1;
            Emulator.escanDefectCnt2 += Emulator.etrackDefectCnt2;
            Emulator.escanDefectCnt3 += Emulator.etrackDefectCnt3;
            Emulator.escanDefectCnt4 += Emulator.etrackDefectCnt4;
            Emulator.escanDefectCnt5 += Emulator.etrackDefectCnt5;
            Emulator.escanDefectCnt6 += Emulator.etrackDefectCnt6;
            Emulator.escanDefectCnt7 += Emulator.etrackDefectCnt7;

            Emulator.etrackDefectCnt1 = 0;
            Emulator.etrackDefectCnt2 = 0;
            Emulator.etrackDefectCnt3 = 0;
            Emulator.etrackDefectCnt4 = 0;
            Emulator.etrackDefectCnt5 = 0;
            Emulator.etrackDefectCnt6 = 0;
            Emulator.etrackDefectCnt7 = 0;

            
        }
            EPostHistData();
        }

    public void EPostHistData()
    {
        const int maxTextHeight = 100;
        int maxHeight = 0;
        int maxHeightBar = 0;


        edef1.Size = new Size(50, Emulator.escanDefectCnt1);
        maxHeight = edef1.Height;

        edef2.Size = new Size(50, Emulator.escanDefectCnt2);
        maxHeight = GetMax(maxHeight, edef2.Height);

        edef3.Size = new Size(50, Emulator.escanDefectCnt3);
        maxHeight = GetMax(maxHeight, edef3.Height);

        edef4.Size = new Size(50, Emulator.escanDefectCnt4);
        maxHeight = GetMax(maxHeight, edef4.Height);

        edef5.Size = new Size(50, Emulator.escanDefectCnt5);
        maxHeight = GetMax(maxHeight, edef5.Height);

        edef6.Size = new Size(50, Emulator.escanDefectCnt6);
        maxHeight = GetMax(maxHeight, edef6.Height);

        edef7.Size = new Size(50, Emulator.escanDefectCnt7);
        maxHeight = GetMax(maxHeight, edef7.Height);

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


        lbleMaxHeightBar.Text = maxHeightBar.ToString();
        lbleMidHeightBar.Text = (maxHeightBar / 2).ToString();
        lbleMinHeightBar.Text = ("0");

        lbleScanDefectCnt1.Text = Emulator.escanDefectCnt1.ToString();
        lbleSizeClass_PSize1_Count.Text = Emulator.escanDefectCnt1.ToString();
        lbleScanDefectCnt2.Text = Emulator.escanDefectCnt2.ToString();
        lbleSizeClass_PSize2_Count.Text = Emulator.escanDefectCnt2.ToString();
        lbleScanDefectCnt3.Text = Emulator.escanDefectCnt3.ToString();
        lbleSizeClass_PSize3_Count.Text = Emulator.escanDefectCnt3.ToString();
        lbleScanDefectCnt4.Text = Emulator.escanDefectCnt4.ToString();
        lbleSizeClass_PSize4_Count.Text = Emulator.escanDefectCnt4.ToString();
        lbleScanDefectCnt5.Text = Emulator.escanDefectCnt5.ToString();
        lbleSizeClass_PSize5_Count.Text = Emulator.escanDefectCnt5.ToString();
        lbleScanDefectCnt6.Text = Emulator.escanDefectCnt6.ToString();
        lbleSizeClass_PSize6_Count.Text = Emulator.escanDefectCnt6.ToString();
        lbleScanDefectCnt7.Text = Emulator.escanDefectCnt7.ToString();
        lbleSizeClass_PSize7_Count.Text = Emulator.escanDefectCnt7.ToString();
        lbleSizeClass_PSizeTotal_Count.Text = (Emulator.escanDefectCnt1 + Emulator.escanDefectCnt2 +
            Emulator.escanDefectCnt3 + Emulator.escanDefectCnt4 + Emulator.escanDefectCnt5
            + Emulator.escanDefectCnt6 + Emulator.escanDefectCnt7).ToString();

        //good to scale now replace def height with scaled height
        edef1.Height = edef1.Height * maxTextHeight / maxHeightBar;
        edef2.Height = edef2.Height * maxTextHeight / maxHeightBar;
        edef3.Height = edef3.Height * maxTextHeight / maxHeightBar;
        edef4.Height = edef4.Height * maxTextHeight / maxHeightBar;
        edef5.Height = edef5.Height * maxTextHeight / maxHeightBar;
        edef6.Height = edef6.Height * maxTextHeight / maxHeightBar;
        edef7.Height = edef7.Height * maxTextHeight / maxHeightBar;

        int edisHisx = eDisHis.Location.X;
        int edisHisy = eDisHis.Location.Y;
        int edisHisHeight = eDisHis.Size.Height;
        int edisHisWidth = eDisHis.Size.Width;

        int edef1Am = edef1.Size.Height;
        int edef1x = edef1.Location.X;
        int edef1y = edef1.Location.Y;

        int edef2Am = edef2.Size.Height;
        int edef2x = edef2.Location.X;
        int edef2y = edef2.Location.Y;

        int edef3Am = edef3.Size.Height;
        int edef3x = edef3.Location.X;
        int edef3y = edef3.Location.Y;

        int edef4Am = edef4.Size.Height;
        int edef4x = edef4.Location.X;
        int edef4y = edef4.Location.Y;

        int edef5Am = edef5.Size.Height;
        int edef5x = edef5.Location.X;
        int edef5y = edef5.Location.Y;

        int edef6Am = edef6.Size.Height;
        int edef6x = edef6.Location.X;
        int edef6y = edef6.Location.Y;

        int edef7Am = edef7.Size.Height;
        int edef7x = edef7.Location.X;
        int edef7y = edef7.Location.Y;

        int edisYPoint = edisHisy + edisHisHeight;

        int ebSyPoint1 = edisYPoint - edef1Am;
        int ebSyPoint2 = edisYPoint - edef2Am;
        int ebSyPoint3 = edisYPoint - edef3Am;
        int ebSyPoint4 = edisYPoint - edef4Am;
        int ebSyPoint5 = edisYPoint - edef5Am;
        int ebSyPoint6 = edisYPoint - edef6Am;
        int ebSyPoint7 = edisYPoint - edef7Am;

        edef1.Location = new Point(edef1x, ebSyPoint1);
        edef2.Location = new Point(edef2x, ebSyPoint2);
        edef3.Location = new Point(edef3x, ebSyPoint3);
        edef4.Location = new Point(edef4x, ebSyPoint4);
        edef5.Location = new Point(edef5x, ebSyPoint5);
        edef6.Location = new Point(edef6x, ebSyPoint6);
        edef7.Location = new Point(edef7x, ebSyPoint7);

    }
        public void EEdgeReject()
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

            eScanDataImage.Image = new Bitmap(eScanDataImage.Width, eScanDataImage.Height);

            // **** Setup all the variables for calculations - Third the STRINGS ****
            // **** Initial Calculations ****
            PixelsPerMM = Emulator.emapRes / Emulator.ewaferDiam;
            EdgeRejectPixels = PixelsPerMM * Emulator.eedgeRej;
            WaferDiamPixels = PixelsPerMM * (Emulator.ewaferDiam);
            MapRadiusPixels = Emulator.emapRes / 2;

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

                    ((Bitmap)eScanDataImage.Image).SetPixel(xPixelLoc, yPixelLoc, Color.Black);
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

                    ((Bitmap)eScanDataImage.Image).SetPixel(xPixelLoc, yPixelLoc, Color.DarkGray);
                    j = j + 0.2;
                }
            }
            ebmp = (Bitmap)eScanDataImage.Image;
        }
    }
}
