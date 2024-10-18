using KoiOrderingSystem.Data.Base;
using KoiOrderingSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystem.Data.Repository
{
    public class TravelRepository : GenericRepository<Travel>
    {

        public TravelRepository() { }

        public TravelRepository(FA24_SE1717_PRN231_G3_KOIORDERINGSYSTEMINJAPANContext testFAContext)
            => _context = testFAContext;
        public async Task<List<Travel>> GetAllAsync()
        {
            return await _context.Set<Travel>().Include(m => m.BookingRequests).ToListAsync();
        }
    }
}
