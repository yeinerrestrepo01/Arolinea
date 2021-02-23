using Aerolina.Domain.Entities;
using BusinessLayer;
using System.Web.Http;

namespace AerolineaApi.Controllers
{
    public class PilotsController : ApiController
    {
        private readonly IServices<PilotsDTO> ServicesPilots;

        public PilotsController()
        {
            ServicesPilots = new Pilots<PilotsDTO>();
        }

        // GET: api/Pilots
        [HttpGet]
        public ApiResult Get()
        {
            return ServicesPilots.SelectAll();
        }

        // GET: api/Pilots/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pilots
        [HttpPost]
        public ApiResult Post([FromBody] PilotsDTO value)
        {
            return ServicesPilots.Insert(value);
        }

        // PUT: api/Pilots/5
        public ApiResult Put(int id, [FromBody] PilotsDTO value)
        {
            return ServicesPilots.Update(value);
        }
    }
}
