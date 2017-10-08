using System.Net.Http;
using System.Web.Http;
using TheGreenMileAPI.Helpers;
using System.Net;
using System.IO.Ports;

namespace TheGreenMileAPI.Controllers
{
    public class TheGreenMileController : ApiController
    {
        private double intensity = 0;
        private string resultTest = "";

        public HttpResponseMessage Get(int player, float load)
        {
            try
            {
                string portName = "";

                if (player == 1)
                    portName = SerialPortHelper.player1Port;
                else
                    portName = SerialPortHelper.player2Port;

                intensity = SerialPortHelper.CreateIntensity(load);

                SerialPortHelper.WritePort(portName, intensity);

                resultTest = $"Player: {player} Port name: {portName} Intensity: {intensity}";

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (System.Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
