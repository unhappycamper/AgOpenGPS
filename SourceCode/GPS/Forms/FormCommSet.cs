﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormCommSet : Form
    {
      //class variables
        private FormGPS mf = null;

        //constructor
        public FormCommSet(Form callingForm)
        {
            //get copy of the calling main form
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormCommSet_Load(object sender, EventArgs e)
        {
            //check if GPS port is open or closed and set buttons accordingly
            if (mf.sp.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }

            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }

            //check if Arduino port is open or closed and set buttons accordingly
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }

            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

            //check if AutoSteer port is open or closed and set buttons accordingly
            if (mf.spAutoSteer.IsOpen)
            {
                cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
            }

            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }

            //load the port box with valid port names
            cboxPort.Items.Clear();
            cboxArdPort.Items.Clear();
            cboxASPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cboxPort.Items.Add(s);
                cboxArdPort.Items.Add(s);
                cboxASPort.Items.Add(s);
            }        

            lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
            lblCurrentPort.Text = mf.sp.PortName;
            lblCurrentArduinoPort.Text = mf.spRelay.PortName;
            lblCurrentAutoSteerPort.Text = mf.spAutoSteer.PortName;
        }

        #region PortSettings //----------------------------------------------------------------

        //AutoSteer
        private void cboxASPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spAutoSteer.PortName = cboxASPort.Text;
            FormGPS.portNameAutoSteer = cboxASPort.Text;
            lblCurrentAutoSteerPort.Text = cboxASPort.Text;
        }

        private void btnOpenSerialAutoSteer_Click(object sender, EventArgs e)
        {
            mf.SerialPortAutoSteerOpen();
            if (mf.spAutoSteer.IsOpen)
            {
                this.cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
                lblCurrentAutoSteerPort.Text = mf.spAutoSteer.PortName;
            }

            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }

        }

        private void btnCloseSerialAutoSteer_Click(object sender, EventArgs e)
        {
            mf.SerialPortAutoSteerClose();
            if (mf.spAutoSteer.IsOpen)
            {
                cboxASPort.Enabled = false;
                btnCloseSerialAutoSteer.Enabled = true;
                btnOpenSerialAutoSteer.Enabled = false;
            }

            else
            {
                cboxASPort.Enabled = true;
                btnCloseSerialAutoSteer.Enabled = false;
                btnOpenSerialAutoSteer.Enabled = true;
            }
        }

        // Arduino 
        private void btnOpenSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortRelayOpen();
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
                lblCurrentArduinoPort.Text = mf.spRelay.PortName;
            }

            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

        }

        private void btnCloseSerialArduino_Click(object sender, EventArgs e)
        {
            mf.SerialPortRelayClose();
            if (mf.spRelay.IsOpen)
            {
                cboxArdPort.Enabled = false;
                btnCloseSerialArduino.Enabled = true;
                btnOpenSerialArduino.Enabled = false;
            }

            else
            {
                cboxArdPort.Enabled = true;
                btnCloseSerialArduino.Enabled = false;
                btnOpenSerialArduino.Enabled = true;
            }

        }

        private void cboxArdPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.spRelay.PortName = cboxArdPort.Text;
            FormGPS.portNameRelaySection = cboxArdPort.Text;
            lblCurrentArduinoPort.Text = cboxArdPort.Text;
        }

        // GPS Serial Port
        private void cboxBaud_SelectedIndexChanged_1(object sender, EventArgs e)
        {
             mf.sp.BaudRate = Convert.ToInt32(cboxBaud.Text);
            FormGPS.baudRateGPS = Convert.ToInt32(cboxBaud.Text);
       
        }

        private void cboxPort_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mf.sp.PortName = cboxPort.Text;
            FormGPS.portNameGPS = cboxPort.Text;
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            mf.SerialPortOpenGPS();
            if (mf.sp.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
                lblCurrentBaud.Text = mf.sp.BaudRate.ToString();
                lblCurrentPort.Text = mf.sp.PortName;
            }

            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }
        }

        private void btnCloseSerial_Click(object sender, EventArgs e)
        {
            mf.SerialPortCloseGPS();
            if (mf.sp.IsOpen)
            {
                cboxBaud.Enabled = false;
                cboxPort.Enabled = false;
                btnCloseSerial.Enabled = true;
                btnOpenSerial.Enabled = false;
            }

            else
            {
                cboxBaud.Enabled = true;
                cboxPort.Enabled = true;
                btnCloseSerial.Enabled = false;
                btnOpenSerial.Enabled = true;
            }
        }

        private void btnRescan_Click(object sender, EventArgs e)
        {
            cboxASPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxASPort.Items.Add(s); }

            cboxArdPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxArdPort.Items.Add(s); }

            cboxPort.Items.Clear();
            foreach (String s in System.IO.Ports.SerialPort.GetPortNames()) { cboxPort.Items.Add(s); }
        }
        
        #endregion PortSettings

        private void timer1_Tick(object sender, EventArgs e)
        {
            //GPS phrase
            textBoxRcv.Text = mf.recvSentenceSettings;
            mf.recvSentenceSettings = "";

            //Arduino phrases
            txtBoxRecvArduino.Text = mf.modcom.serialRecvRelayStr;
            txtBoxSendArduino.Text = mf.modcom.relaySectionControl[0].ToString();

            //autoSteer
            txtBoxRecvAutoSteer.Text = mf.modcom.serialRecvAutoSteerStr;
            txtBoxSendAutoSteer.Text = mf.modcom.autoSteerControl[0].ToString();
        }

        private void btnSerialOK_Click(object sender, EventArgs e)
        {
            //save
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

     } //class
} //namespace
