using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDA100
{
    class Globals
    {
        public static string inData;
        public static string scanTrack;
        public static string statusMessage;
        public static string scanReply;
        public static string scanUnknownMessage;

        public static string teensyComPort;
        public static bool teensyComPortOK = true;

        public static string iniOID;
        public static int mapRes;
        public static int waferDiam;
        public static int edgeRej;
        public static string sectorSteps;
        public static string trackSteps;
        public static string parkY;
        public static string parkX;
        public static string parkZ;
        public static string centerY;
        public static string centerX;
        public static string pSize1Label;
        public static string pSize2Label;
        public static string pSize3Label;
        public static string pSize4Label;
        public static string pSize5Label;
        public static string pSize6Label;
        public static string pSize7Label;
        public static string afTimeOut;
        public static string dirData;
        public static string dirRecipe;
        public static string dirINI;
        public static string dirErrorLog;

        public static string recipeOID;
        public static string editDateTime;
        public static string recipeStatus;
        public static string recipeName;
        public static string userName;
        public static string scanID;
        public static string scanArea;
        public static string zoneType;
        public static string autoSave;
        public static string recipeNameDefault;
        public static string rejectLimitS1;
        public static string rejectLimitS2;
        public static string rejectLimitS3;
        public static string rejectLimitS4;
        public static string rejectLimitS5;
        public static string rejectLimitS6;
        public static string rejectLimitS7;
        public static string rejectLimitTotal;
        public static string recipeComments;

        public static int mxFrontLimitFlag;
        public static int mxBackLimitFlag;
        public static int myLeftLimitFlag;
        public static int myRightLimitFlag;
        public static int mzTopLimitFlag;
        public static int mzBottomLimitFlag;
        public static int doorOpenFlag;
        public static int doorCloseFlag;
        public static int doorOKFlag;
        public static int vacMainFlag;
        public static int vacChuckFlag;
        public static int chuckValveFlag;
        public static int scanStopFlag;
        public static int mxPosAbsVal;
        public static int myPosAbsVal;
        public static int mzPosAbsVal;
        public static int mxScanTrackWidthVal;
        public static int myScanSectorWidthVal;
        public static double percentScanVal;
        public static int homeNotOK;
        public static int zHomeNotOK;
        public static int autoFocusOK;
        public static int autoFocusVal;
        public static int speedVal;
        public static int maxSpeed;
        public static int waferRadius;
        public static int waferEdgeReject;
        public static int countAbort;
        public static int sysError;

        public static string[] recLines;
    }
}
