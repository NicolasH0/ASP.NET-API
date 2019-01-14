using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EasyModbus;
using System.Net.Http;
using System.Web.Http;

namespace EmersonWebAPI.Controllers
{
    public class DegreeController : ApiController
    {

        // GET api/<controller>
        public int Get()
        {
            plc.Connect();
            int[] read = plc.ReadHoldingRegisters(3, 1);
            return read[0];
        }
        ModbusClient plc = new ModbusClient("192.168.0.221", 502);

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}