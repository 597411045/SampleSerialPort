using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace SampleSerialPort
{
    class iSerialPort
    {
        private SerialPort serialPort;
        private byte[] bytesRead;
        private byte[] bytesWrite;
        private byte[] bytesReturn;
        private int bytesLength;

        public iSerialPort(int arg_bytesLength)
        {
            bytesLength = arg_bytesLength;
            serialPort = new SerialPort();
            bytesRead = new byte[bytesLength];
            bytesWrite = new byte[bytesLength];
            initialize();
        }

        public void initialize()
        {
            serialPort.PortName = "COM1";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
        }


        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", serialPort.PortName, serialPort.BaudRate, serialPort.Parity, serialPort.DataBits, serialPort.StopBits);
        }

        public void open()
        {
            try
            {
                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    serialPort.Open();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool isOpen()
        {
            return serialPort.IsOpen;
        }

        public byte[] read()
        {
            try
            {
                bytesRead = new byte[bytesLength];
                if (serialPort.Read(bytesRead, 0, bytesRead.Length) > 0)
                {
                    return Encoding.ASCII.GetString(bytesRead);
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public int readBufferLength()
        {
            return serialPort.BytesToRead;
        }

        private void write()
        {
            try
            {
                serialPort.Write(bytesWrite, 0, bytesWrite.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void close()
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }


}
