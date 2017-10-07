using System;
using System.IO.Ports;

namespace TheGreenMileAPI.Helpers
{
    public static class SerialPortHelper
    {
        public static void WritePort(string portName, double intensity)
        {
            SerialPort port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);

            port.Open();
            port.Write("r");
            port.Close();

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