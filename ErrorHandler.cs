using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SDA100
{
    class ErrorHandler
    {
        private static string errorMessage { get; set; }
        private static string errorResponse { get; set; }
        public static void CheckForErrors()
        {
            //Errors will match this regular expression
            Regex regex = new Regex("^![A-Za-z]{1}0{1}\r{1}$");
            if (regex.IsMatch(Globals.inData) && !Globals.errorMessageDisplayed)
            {
                char letter = Globals.inData[1];
                //int maxFailedAttempts = 3;
                switch (letter)
                {
                    case 'O':
                        errorResponse = "N";
                        //Globals.vacChuckFlag = 0;
                        errorMessage = "No wafer detected";
                        break;
                    case 'o':
                        errorMessage = "Door failed to open";
                        Globals.doorCloseFlag = 1;
                        Console.WriteLine("ERROR o");
                        break;
                    case 'n':
                        errorMessage = "Door failed to close";
                        Globals.doorCloseFlag = 0;
                        break;
                    case 'H':
                        errorMessage = "Failed to get to Home";
                        break;
                    default:
                        errorMessage = "Unknown error";
                        break;
                }

            }
            
        }

    }
}