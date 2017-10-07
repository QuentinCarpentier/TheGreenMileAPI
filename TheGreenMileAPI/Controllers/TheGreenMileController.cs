using System.Net.Http;
using System.Web.Http;
using TheGreenMileAPI.Helpers;
using System.Net;

namespace TheGreenMileAPI.Controllers
{
    public class TheGreenMileController : ApiController
    {
        private string portName = "";
        private double intensity = 0;
        private string resultTest = "";

        public HttpResponseMessage Get(int player, float load)
        {
            try
            {
                if (player == 1)
                    portName = "COM5";
                else
                    portName = "COM1";

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
