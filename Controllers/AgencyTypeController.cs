using EaTS.Data;
using EaTS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EaTS.Controllers
{
    public class AgencyTypeController : Controller
    {
        public AgencyTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;
        public async Task<IActionResult> Index()
        {
            return View(await _db.AgencyType.Include(a => a.Agencies).ToListAsync());
        }


    }
}
