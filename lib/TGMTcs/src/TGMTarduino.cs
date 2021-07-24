using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TGMTcs
{
    public class ArduinoEventArgs : EventArgs
    {
        public string message { get; private set; }

        public ArduinoEventArgs(string msg)
        {
            message = msg;
        }
    }

    class TGMTarduino
    {
        struct ArduinoProperties
        {
            public string portName;
            public int baudRate;
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private SerialPort m_port;
        string m_portName = "";
        public delegate void OnMessageReceivedHandler(object sender, ArduinoEventArgs e);
        public OnMessageReceivedHandler onMessageReceived;

        public delegate void OnBoardDisconnectedHandler(object sender, ArduinoEventArgs e);
        public OnBoardDisconnectedHandler onBoardDisconnectedHandler;

        Thread m_threadCheckDisconnected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //if port is empty program will auto select arduino port
        public TGMTarduino(string portName = "", int baudRate = 9600)
        {
            if (portName == "")
            {
                ArduinoProperties arduinoProperties = AutoDetectArduinoPort();
                portName = arduinoProperties.portName;
                baudRate = arduinoProperties.baudRate;

                if (portName == null)
                {                    
                    return;
                }
            }
            try
            {
                m_port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                // Attach a method to be called when there
                // is data waiting in the port's buffer
                m_port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

                // Begin communications
                m_port.Open();

                m_portName = portName;

                m_threadCheckDisconnected = new Thread(new ThreadStart(CheckDisconnected));
                m_threadCheckDisconnected.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ~TGMTarduino()
        {
            Disconnect();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void CheckDisconnected()
        {
            bool connected = true;
            while(connected)
            {
                Thread.Sleep(1000);
                if (m_port == null || !m_port.IsOpen)
                {
                    connected = false;
                    onBoardDisconnectedHandler?.Invoke(this, new ArduinoEventArgs("board disconnected"));
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!Connected)
                return;

            // Show all the incoming data in the port's buffer
            string message = m_port.ReadLine();
            if (message == "")
                return;

            if (message[message.Length - 1] == '\r')
            {
                message = message.Substring(0, message.Length - 1);
            }

            if(message != "")
            {
                onMessageReceived?.Invoke(this, new ArduinoEventArgs(message));
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Send(string msg)
        {
            if (Connected)
                m_port.WriteLine(msg);
            //else
            //throw new Exception("Arduino not connected");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Send(char c)
        {
            if (Connected)
                m_port.Write(c.ToString());
            //else
            //throw new Exception("Arduino not connected");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private ArduinoProperties AutoDetectArduinoPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            ArduinoProperties result = new ArduinoProperties();

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();
                    string pnp = item["PNPDeviceID"].ToString();

                    if (desc.Contains("Arduino")
                        || pnp.Contains("VID_10C4")// Vietduino
                        || pnp.Contains("VID_2341")) //arduino)
                    {
                        result.portName = deviceId;
                    }

                    var config = item.GetRelated("Win32_SerialPortConfiguration").Cast<ManagementObject>().ToList().FirstOrDefault();
                    if (config == null)
                        continue;

                    result.baudRate = (config != null)
                                        ? int.Parse(config["BaudRate"].ToString())
                                        : int.Parse(item["MaxBaudRate"].ToString());
                }
            }
            catch (ManagementException e)
            {
                throw new Exception("Can not get Arduino port, please check connection");
            }

            if(result.portName == null)
            {
                //find Arduino nano
                // Get all serial (COM)-ports you can see in the devicemanager
                searcher = new ManagementObjectSearcher("root\\cimv2",
                    "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");



                // Add all available (COM)-ports to the combobox
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    if (desc.Contains("USB-SERIAL CH340")) //arduino nano
                    {
                        string port = item["Caption"].ToString();
                        int indexOfCom = port.IndexOf("(COM");

                        result.portName = port.Substring(indexOfCom + 1, port.Length - indexOfCom - 2);
                        result.baudRate = 9600; //TODO: edit later
                    }
                }
                    
            }
            return result;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Connected
        {
            get
            {
                if (m_port == null)
                    return false;
                return m_port.IsOpen;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ConnectedPort
        {
            get
            {
                return m_portName;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Disconnect()
        {
            if(Connected)
            {
                m_port.Close();
            }
        }
    }
}