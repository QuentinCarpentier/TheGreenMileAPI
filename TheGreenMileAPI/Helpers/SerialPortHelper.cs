using System;
using System.IO.Ports;

namespace TheGreenMileAPI.Helpers
{
    public static class SerialPortHelper
    {
        private static int player1Port;
        private static int player2Port;

        public static void SetPorts()
        {
            foreach(string item in ports)
            {
                SerialPort port = new SerialPort(item, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("i");
                byte[] buffer;
                port.Read(buffer);
                port.Close();

                string res = System.Text.Encoding.Default.GetString(buffer);
                if (res == "1")
                    SerialPortHelper.player1Port = item;
                else if (res == "2")
                    SerialPortHelper.player2Port = item;

            }
        }

        public static void WritePort(string portName, double intensity)
        {
            port.Open();
            port.Write(intensity.ToString());
            port.Close();
        }

        public static double CreateIntensity(float intensity)
        {
            double result = 0;

            if (intensity != 0.0f)
            {
                if (intensity <= 10.0f)
                {
                    result = Math.Round(intensity / 20.0) * 20;
                    result += 20;
                }
                else
                {
                    result = Math.Round(intensity / 20.0) * 20;
                }

                result = (result / 10) / 2;
            }

            return result;
        }
    }
}