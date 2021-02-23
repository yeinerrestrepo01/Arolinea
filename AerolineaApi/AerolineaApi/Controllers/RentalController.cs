using Aerolina.Domain.Entities;
using BusinessLayer;
using System.Web.Http;

namespace AerolineaApi.Controllers
{
    public class RentalController : ApiController
    {
        private readonly IServices<RentalDTO> ServicesRental;

        public RentalController()
        {
            ServicesRental = new Rental<RentalDTO>();
        }

        // GET: api/Rental
        public ApiResult Get()
        {
            return ServicesRental.SelectAll();
        }

        // GET: api/Rental/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rental
        public ApiResult Post([FromBody] RentalDTO value)
        {
            return ServicesRental.Insert(value);
        }

        // PUT: api/Rental/5
        public ApiResult Put(int id, [FromBody] RentalDTO value)
        {
            return ServicesRental.Update(value);
        }
    }
}
