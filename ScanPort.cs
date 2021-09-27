using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SDA100
{
    class ScanPort
    {
        static SerialPort _serialPort;

        public static void ScanComPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            int portFoundCount = ports.Length;
            _serialPort = new SerialPort();

            for (int px = 0; px < portFoundCount; px++)
            {
                Console.WriteLine(ports[px]);
            }

            for (int x = 0; x < portFoundCount; x++)
            {
                //try
                //{
                _serialPort.PortName = ports[x];
                _serialPort.BaudRate = 115200;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Parity = Parity.None;
                _serialPort.Open();

                _serialPort.Write("?");
                int portTestCount = 0;
                string portTest = "";

                while ((portTest == "") && (portTestCount < 100))
                {
                    portTest = _serialPort.ReadExisting();
                    portTestCount++;
                }

                if (portTest.Contains("!"))
                {
                    Console.WriteLine("Found the ! Flag on ComPort: " + ports[x].ToString());
                    Globals.teensyComPort = Convert.ToString(ports[x]);
                    x = portFoundCount;
                    _serialPort.Close();
                }
                else
                {
                    _serialPort.Close();
                }
                if ((x == portFoundCount - 1))
                {
                    Globals.teensyComPortOK = false;
                }
                //}

                //catch
                //{
                //    Console.WriteLine(ports[x].ToString() + " Is NOT OK");
                //}                
            }
        }
        public static void UpdateStatus()
        {

            const char DELIM = ',';

            //Globals.inData = Globals.inData.Remove(0, 1);
            //Globals.inData = Globals.inData.Remove(Globals.inData.Length - 3, 3);
            string[] fields = Globals.statusMessage.Split(DELIM);
            int dataINLength = Globals.statusMessage.Length;
           
            Globals.mxFrontLimitFlag = Convert.ToInt32(fields[0]);
            Globals.mxBackLimitFlag = Convert.ToInt32(fields[1]);
            Globals.myLeftLimitFlag = Convert.ToInt32(fields[2]);
            Globals.myRightLimitFlag = Convert.ToInt32(fields[3]);
            Globals.mzTopLimitFlag = Convert.ToInt32(fields[4]);
            Globals.mzBottomLimitFlag = Convert.ToInt32(fields[5]);
            Globals.doorOpenFlag = Convert.ToInt32(fields[6]);
            Globals.doorCloseFlag = Convert.ToInt32(fields[7]);
            Globals.doorOKFlag = Convert.ToInt32(fields[8]);
            Globals.vacMainFlag = Convert.ToInt32(fields[9]);
            Globals.vacChuckFlag = Convert.ToInt32(fields[10]);
            Globals.chuckValveFlag = Convert.ToInt32(fields[11]);
            Globals.scanStopFlag = Convert.ToInt32(fields[12]);
            Globals.mxPosAbsVal = Convert.ToInt32(fields[13]);
            Globals.myPosAbsVal = Convert.ToInt32(fields[14]);
            Globals.mzPosAbsVal = Convert.ToInt32(fields[15]);
            Globals.mxScanTrackWidthVal = Convert.ToInt32(fields[16]);
            Globals.myScanSectorWidthVal = Convert.ToInt32(fields[17]);
            Globals.percentScanVal = Convert.ToDouble(fields[18]);
            Globals.homeNotOK = Convert.ToInt32(fields[19]);
            Globals.zHomeNotOK = Convert.ToInt32(fields[20]);
            Globals.autoFocusOK = Convert.ToInt32(fields[21]);
            Globals.autoFocusVal = Convert.ToInt32(fields[22]);
            Globals.speedVal = Convert.ToInt32(fields[23]);
            Globals.maxSpeed = Convert.ToInt32(fields[24]);
            Globals.waferRadius = Convert.ToInt32(fields[25]);
            Globals.waferEdgeReject = Convert.ToInt32(fields[26]);
            Globals.countAbort = Convert.ToInt32(fields[27]);
            Globals.sysError = Convert.ToInt32(fields[28]);
        }
    }
}
