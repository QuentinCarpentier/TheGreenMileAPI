using System;
using System.IO.Ports;

namespace TheGreenMileConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            float intensity = 10f;
            double result = 0;

            if (intensity != 0.0f)
            {
                if (intensity <= 10.0f)
                {
                    result = Math.Round(intensity / 20.0) * 20;
                    result += 20;
                }
                else
                    result = Math.Round(intensity / 20.0) * 20;

                result = (result / 10) / 2;
            }

            Console.WriteLine(result);
        }
    }
}
