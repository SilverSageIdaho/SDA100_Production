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
                    //_serialPort.Write("m");
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

            Globals.inData = Globals.inData.Remove(0, 1);
            Globals.inData = Globals.inData.Remove(Globals.inData.Length - 3, 3);
            string[] fields = Globals.inData.Split(DELIM);
            int dataINLength = Globals.inData.Length;

            Globals.MxFrontLimitFlag = Convert.ToInt32(fields[0]);
            Globals.MxBackLimitFlag = Convert.ToInt32(fields[1]);
            Globals.MyLeftLimitFlag = Convert.ToInt32(fields[2]);
            Globals.MyRightLimitFlag = Convert.ToInt32(fields[3]);
            Globals.MzTopLimitFlag = Convert.ToInt32(fields[4]);
            Globals.MzBottomLimitFlag = Convert.ToInt32(fields[5]);
            Globals.DoorOpenFlag = Convert.ToInt32(fields[6]);
            Globals.DoorCloseFlag = Convert.ToInt32(fields[7]);
            Globals.DoorOKFlag = Convert.ToInt32(fields[8]);
            Globals.VacMainFlag = Convert.ToInt32(fields[9]);
            Globals.VacChuckFlag = Convert.ToInt32(fields[10]);
            Globals.NoMIPFlag = Convert.ToInt32(fields[11]);
            Globals.ChuckValveFlag = Convert.ToInt32(fields[12]);
            Globals.ScanStopFlag = Convert.ToInt32(fields[13]);
            Globals.MxPosAbsVal = Convert.ToInt32(fields[14]);
            Globals.MyPosAbsVal = Convert.ToInt32(fields[15]);
            Globals.MzPosAbsVal = Convert.ToInt32(fields[16]);
            Globals.MxScanTrackWidthVal = Convert.ToInt32(fields[17]);
            Globals.MyScanSectorWidthVal = Convert.ToInt32(fields[18]);
            Globals.PercentScanVal = Convert.ToInt32(fields[19]);
            Globals.HomeNotOK = Convert.ToInt32(fields[20]);
            Globals.zHomeNotOK = Convert.ToInt32(fields[21]);
            Globals.DoorValveFlag = Convert.ToInt32(fields[22]);
            Globals.PHA_SizeNum = Convert.ToInt32(fields[23]);
            Globals.AutoFocusOK = Convert.ToInt32(fields[24]);
            Globals.AutoFocusVal = Convert.ToInt32(fields[25]);
            Globals.SpeedVal = Convert.ToInt32(fields[26]);
            Globals.MaxSpeed = Convert.ToInt32(fields[27]);
            Globals.WaferRadius = Convert.ToInt32(fields[28]);
            Globals.WaferEdgeReject = Convert.ToInt32(fields[29]);
            Globals.CountAbort = Convert.ToInt32(fields[30]);

            

            
        }
    }
}
