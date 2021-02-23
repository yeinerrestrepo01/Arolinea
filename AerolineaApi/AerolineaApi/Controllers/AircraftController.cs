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
    public class AircraftController : ApiController
    {
        private readonly IServices<AircarftDTO> ServicesAircraft;

        public AircraftController()
        {
            ServicesAircraft = new Aircraft<AircarftDTO>();
        }

        // GET: api/Aircraft
        public ApiResult Get()
        {
            return ServicesAircraft.SelectAll();
        }

        // GET: api/Aircraft/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Aircraft
        public ApiResult Post([FromBody] AircarftDTO value)
        {
            return ServicesAircraft.Insert(value);
        }

        // PUT: api/Aircraft/5
        public ApiResult Put(int id, [FromBody] AircarftDTO value)
        {
            return ServicesAircraft.Update(value);
        }
    }
}
