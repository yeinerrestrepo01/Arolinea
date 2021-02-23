using Aerolina.Domain.Entities;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AerolineaApi.Controllers
{
    public class AirlineController : ApiController
    {
        private readonly IServices<AirlinesDTO> ServicesAirline;

        public AirlineController()
        {
            ServicesAirline = new Airlines<AirlinesDTO>();
        }
        // GET: api/Airline
        [HttpGet]
        public ApiResult Get()
        {
            return ServicesAirline.SelectAll();
        }

        // GET: api/Airline/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Airline
        [HttpPost]
        public ApiResult Post([FromBody] AirlinesDTO value)
        {
            return ServicesAirline.Insert(value);
        }

        // PUT: api/Airline/5
        public ApiResult Put(int id, [FromBody] AirlinesDTO value)
        {
            return ServicesAirline.Update(value);
        }
    }
}
