using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDA100
{
    class ErrorHandler
    {
        public string DoorOpenError(SerialPort serialPort)
        {
            string errorMessage = "Door failed to open";
            Globals.doorCloseFlag = 1;
            serialPort.Write("n"); //Close door if failed to open?
            return errorMessage;
        }
    }
}
