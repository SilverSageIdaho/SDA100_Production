using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace SDA100
{
    public partial class mainForm : Form
    {
        private void cbxConsoleCommands_SelectedIndexChanged(object sender, EventArgs e)    //<-- THIS EVENT STILL NEEDS TO BE GENERATED ON FORM1.CS(DESIGN) CONSOLE TAB
        {
            sender = cbxConsoleCommands.SelectedItem;
            switch (sender)
            {
                case ".":
                    //Note: scanner.NumVal = 0;  <--(I can't find NumVal)
                    //resets number counter for Number Value inputs

                    break;
                case "?":

                    //response = !?
                    break;
                case "A":
                    //Gets the home status & current position of XYZ stages

                    //response = !Hh,A,X,Y,Z
                    break;
                case "B":
                    //Note: BACK -  the X Stage moves towards the stepper motor
                    //Move back Relative.nnnnB steps

                    //response = !Bnnnn
                    break;
                case "C":
                    //Clear Hyper Terminal Display

                    //response = !C
                    break;
                case "D":
                    //Move Z-Focus DOWN Relative (.nnnnD) steps

                    //response = !Dnnnn
                    break;
                case "E":

                    //response =
                    break;
                case "F":
                    //Note: FRONT -  the X Stage moves away from the stepper motor
                    //Move Front Relative .nnnnF steps

                    //response = !Fnnnn
                    break;
                case "G":
                    //Note: Sends scan line data to Com Port #1 as formatted strings
                    //Raster Scan the XY stages and collect DATA

                    //response =
                    break;
                case "H":
                    //Note: Open loop command, goes until Opto or STOP button
                    //Moves FRONT/RIGHT to opto detectors set stage XY position to one

                    //response = !H
                    break;
                case "I":
                    //Moves XYZ stages to position defined by .nnnnX and .nnnnY and .nnnnZ values

                    //response = !I
                    break;
                case "J":

                    //response =
                    break;
                case "K":

                    //response =
                    break;
                case "L":
                    //Note: LEFT -  the Y Stage moves towards the stepper motor
                    //Move Left Relative.nnnnL steps

                    //response = !Lnnnn
                    break;
                case ".1M":
                    //Note: Sends all system parameters to terminal
                    //Verbose 1 of 2 lists of Scanner Parameters

                    //response = !M1
                    break;
                case ".2M":
                    //Note: Sends all system parameters to terminal
                    //Verbose 1 of 2 lists of Scanner Parameters

                    //response = !M2
                    break;
                case ".3M":
                    //Verbose 1 of 2 lists of Scanner Commands

                    //response = !M3
                    break;
                case ".4M":
                    //Verbose 1 of 2 lists of Scanner Commands

                    //response = !M4
                    break;
                case "N":
                    //Note: VAC Ralay/24V Valve  is OFF
                    //Release Vacuum to Sample Chuck/ ChuckVac Valve OF

                    //response = !N
                    break;
                case "O":
                    //Note: VAC Ralay/24V Valve  is ON
                    //Apply Vacuum to Sample Chuck / ChuckVac Valve ON

                    //response = !O
                    break;
                case "P":
                    //Note: use after scan to move stages back to load port
                    //Move XY stage to load port position .nnnnx and .nnnny

                    //response = !P
                    break;
                case "Q":
                    //Note: RESPONSE includes the PHA value read by Q cmd
                    //Reads PHA output and displayes value

                    //response = !Qnnnn
                    break;
                case "R":
                    //Note: RIGHT -  the Y Stage moves away from the stepper motor
                    //Move Right Relative .nnnnR steps

                    //response = !Rnnnn
                    break;
                case "S":
                    //Note: The PHA is active from start to end of each sector
                    // # of ABS steps to form a SECTOR .nnnnS

                    //response = !Snnnn
                    break;
                case "T":
                    //Note: The Mx steps the # to start new My scan
                    // # of ABS steps to move to form a TRACK .nnnnT

                    //response = !Tnnnn
                    break;
                case "U":
                    //Move Z-Focus UP Relative (.nnnnU) steps

                    //response = !Unnnn
                    break;
                case "V":
                    //response =
                    break;
                case "W":
                    //response =
                    break;
                case "X":
                    //Note: Pre-position stage to XY location with "I" command
                    //Input of ABS value of Mx position .nnnnX steps

                    //response = !Xnnnn
                    break;
                case "Y":
                    //Note: Pre-position stage to XY location with "I" command
                    //Input of ABS value of My position .nnnnY steps

                    //response = !Ynnnn
                    break;
                case "Z":
                    //Note: Pre-position stage to XY location with "z*" command
                    //Input of ABS value of Mz position .nnnnZ steps

                    //response = !Znnnn
                    break;
                case "a":
                    //Note: in machine message
                    //SET Max raw defect count to stop scan .nnnna

                    //response = !a
                    break;
                case "b":
                    //response =
                    break;
                case "c":
                    //Note: just for system trouble shooting
                    //CLEAR -  STOP/ Move/Home flags

                    //response = !c
                    break;
                case "d":
                    //Note: SETS value of ScanWaferRadius, in machine message
                    //Calculates and converts mm to steps for  wafer radius value

                    //response = !dnnn
                    break;
                case "e":
                    //Note: SETS value of ScanEdgeReject, in machine message
                    //Calculates and converts mm to steps for wafer edge reject val

                    //response = !ennn
                    break;
                case "f":
                    //Read auto Focus A/D value 0-1024

                    //response = !f
                    break;
                case "g":
                    //all stage movement flags are set to false (zero) to stop machine movements

                    //response = !g
                    break;
                case "h":
                    //MOVE - Z-Stage to TOP/UP HOME opto stop and set position to one

                    //response = !h
                    break;
                case "i":
                    //Note: Transfers (lc)uvw to (uc)XYZ for motion command (uc)I
                    //SETS -  I to default position of stage chuck center

                    //response = !i
                    break;
                case "j":
                    //response =
                    break;
                case "k":
                    //response =
                    break;
                case "l":
                    //response =
                    break;
                case "m":
                    //SEND scanner parameters to host in machine format

                    //response = !m
                    break;
                case "n":
                    //response = !n
                    break;
                case "o":
                    //response = !o
                    break;
                case "p":
                    //Move Z stage to load port position .nnnnz

                    //response = !p
                    break;
                case "q":
                    //response = 
                    break;
                case "r":
                    //SET Host defect map resolution used to calculate scan data compression

                    //response = !rnnn
                    break;
                case "s":
                    //response = !s
                    break;
                case "t":
                    //Test code and output to treminal

                    //response = !t
                    break;
                case "u":
                    //Note: Used to set focus position value.
                    //SET the optics head above the focus detector point .nnnnz steps

                    //response = !unnn
                    break;
                case "v":
                    //Note: Used to set focus position value.
                    //SET the mechanical center of chuck X value  .nnnnv

                    //response = !vnnn
                    break;
                case "w":
                    //Note: Used to set focus position value.
                    //SET the mechanical center of chuck Y value  .nnnnw

                    //response = !wnnn
                    break;
                case "x":
                    //Note: Used to set park values.
                    //SET the chuck load position X value  .nnnnx

                    //response = !xnnn
                    break;
                case "y":
                    //Note: Used to set park values.
                    //SET the chuck load position Y value  .nnnny

                    //response = !ynnn
                    break;
                case "z":
                    //Note: Used to set park values.
                    //SET the chuck load position Y value  .nnnny   <-- SHOULD THIS BE THEY Z VALUE?

                    //response = !znnn
                    break;
                default:
                    MessageBox.Show("Please make a valid selection.");
                    break;
            }
        }



        /*YOU SHOULD BE ABLE TO COPY AND PASTE IN THIS LIST OF COMMANDS TO cbxConsoleCommands' Items (Collection) list:

        .
        ?
        A
        B
        C
        D
        E
        F
        G
        H
        I
        J
        K
        L
        .1M
        .2M
        .3M
        .4M
        N
        O
        P
        Q
        R
        S
        T
        U
        V
        W
        X
        Y
        Z
        a
        b
        c
        d
        e
        f
        g
        h
        i
        j
        k
        l
        m
        n
        o
        p
        q
        r
        s
        t
        u
        v
        w
        x
        y
        z	

        */
    }
}
