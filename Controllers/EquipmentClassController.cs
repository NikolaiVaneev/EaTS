using EaTS.Data;
using EaTS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EaTS.Controllers
{
    public class EquipmentClassController : Controller
    {
        public EquipmentClassController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;
        public async Task<IActionResult> Index(int? id)
        {
            EquipmentClassViewModel model = new()
            {
                EquipmentType = _db.EquipmentType.Find(id),
                EquipmentClasses = await _db.EquipmentClass.Include(a => a.Equipments).Where(ec => ec.EqupmentType.Id == id).ToListAsync()
            };

            return View(model);
        }
    }
}
