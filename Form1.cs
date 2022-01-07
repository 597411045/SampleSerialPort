using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SampleSerialPort
{
    public partial class Form1 : Form
    {
        private iSerialPort _iSerialPort;
        private iThreadManager _iThreadManager;
        private iTextManager _iTextManager;

        private int tmpInt;

        public Form1()
        {
            InitializeComponent();

            _iSerialPort = new iSerialPort(1);
            _iThreadManager = new iThreadManager(this);
            _iThreadManager.newThread(threadAction_UpdateLabel5);
            _iTextManager = new iTextManager(this);

            label2.Text = _iSerialPort.ToString();
            richTextBox1.Clear();
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            _iSerialPort.close();
            label3.Text = "未连接";
            _iThreadManager._listThreads[0].Abort();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            _iSerialPort.open();
            if (_iSerialPort.isOpen())
                label3.Text = "已连接";
            _iThreadManager._listThreads[0].Start();
        }

        private void threadAction_UpdateLabel5()
        {
            tmpInt = _iSerialPort.readBufferLength();
            label5.Text = tmpInt.ToString();
            if (tmpInt > 0)
            {
                richTextBox1.Text += _iSerialPort.read();
            } 
        }

    }
}
