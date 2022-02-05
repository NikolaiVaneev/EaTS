using EaTS.Data;
using EaTS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EaTS.Controllers
{
    public class EquipmentKindController : Controller
    {
        public EquipmentKindController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;
        public async Task<IActionResult> Index(int? id)
        {
            EquipmentKindViewModel model = new()
            {
                EquipmentClass = _db.EquipmentClass.Include(t => t.EqupmentType).FirstOrDefault(x => x.Id == id),
                Equipments = await _db.EquipmentKind.Where(ec => ec.EquipmentClass.Id == id).ToListAsync()
            };

            return View(model);
        }
    }
}
