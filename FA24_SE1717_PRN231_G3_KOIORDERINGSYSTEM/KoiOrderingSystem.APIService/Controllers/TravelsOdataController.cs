using KoiOrderingSystem.Data.Models;
using KoiOrderingSystem.Service;
using KoiOrderingSystem.Service.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace KoiOrderingSystem.APIService.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    //[Authorize]
    public class TravelsOdataController : ODataController
    {
        private readonly ITravelService _travelService;

        public TravelsOdataController() => _travelService ??= new TravelService();

        // GET: odata/Travels
        [EnableQuery]
        [HttpGet]
        public IQueryable<Travel> GetTravels()
        {
            var travels = _travelService.GetAll().Result.Data as List<Travel>;
            var result = travels.AsQueryable();
            return result;
        }

        // GET: odata/Travels(5)
        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<Travel> GetTravel([FromODataUri] Guid key)
        {
            var travel = _travelService.GetById(key).Result.Data as Travel;
            var result = new List<Travel> { travel }.AsQueryable(); // Tạo IQueryable từ đối tượng duy nhất
            return SingleResult.Create(result);
        }

        // PUT: odata/Travels(5)
        [HttpPut("{key}")]
        public async Task<IBusinessResult> PutTravel([FromBody] Travel travel)
        {
            return await _travelService.Save(travel);
        }

        // POST: odata/Travels
        [HttpPost]
        public async Task<IBusinessResult> PostTravel([FromBody] Travel travel)
        {
            return await _travelService.Save(travel);
        }

        // DELETE: odata/Travels(5)
        [HttpDelete("{id}")]
        public async Task<IBusinessResult> DeleteTravel(Guid id)
        {
            return await _travelService.DeleteById(id);
        }
    }
}
