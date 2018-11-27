using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EasyModbus;
using System.Web.Configuration;

namespace EmersonWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        public float analogValue;
        public float mAValue;
        public int pvHigh;
        public int pvLow;
        public int iHigh;
        public int iLow;
        public float temperature;
        public Double result;

        public ValuesController()
        {
            pvHigh = Int32.Parse(WebConfigurationManager.AppSettings["maxTemp"]);
            pvLow = Int32.Parse(WebConfigurationManager.AppSettings["minTemp"]);
            iHigh = 20;
            iLow = 4;
        }

        ModbusClient plc = new ModbusClient("192.168.0.221", 502);

        // GET api/values
        public double Get()
        {
            plc.Connect();
            int[] read = plc.ReadHoldingRegisters(2, 1);
            analogValue = read[0]; // I

            mAValue = analogValue / 1000;

            temperature = ((pvHigh - pvLow) / (iHigh - iLow)) * (mAValue - iLow) + pvLow;

            result = Math.Round(temperature, 1);

            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
