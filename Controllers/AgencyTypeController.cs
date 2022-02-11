using EaTS.Data;
using EaTS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EaTS.Controllers
{
    //[Authorize]
    //[ApiController]
    public class AgencyTypeController : Controller
    {
        public AgencyTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgencyType>>> GetTypes()
        {
            return await _db.AgencyType.Include(a => a.Agencies).ToListAsync();
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AgencyType agencyType)
        {
            // TODO Засунуть эти проверки в отдельный метод  
            if (agencyType == null)
            {
                return BadRequest("Object is null");
            }

            if (string.IsNullOrWhiteSpace(agencyType.Name) || string.IsNullOrWhiteSpace(agencyType.ShortName))
            {
                return BadRequest("Object data is not correct (name or shortname)");
            }

            if (_db.AgencyType.Where(a => a.Name == agencyType.Name || a.ShortName == agencyType.ShortName).Any())
            {
                return BadRequest("Object already exists in the database");
            }
            ////////////////////////////////////////


            _db.AgencyType.Add(agencyType);
            await _db.SaveChangesAsync();
            return Ok("Object added successfully");
        }

        //[Authorize(Roles = "admin")]
        [HttpPatch]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AgencyType agencyType)
        {
            // TODO Засунуть эти проверки в отдельный метод            
            if (agencyType == null)
            {
                return BadRequest("Object is null");
            }

            if (string.IsNullOrWhiteSpace(agencyType.Name) || string.IsNullOrWhiteSpace(agencyType.ShortName))
            {
                return BadRequest("Object data is not correct (name or shortname)");
            }

            if (_db.AgencyType.Where(a => a.Name == agencyType.Name && a.ShortName == agencyType.ShortName).Any())
            {
                return BadRequest("Object already exists in the database");
            }
            ////////////////////////////////////////


            var type = _db.AgencyType.Find(agencyType.Id);

            if (type == null)
            {
                return BadRequest("Object not found. Check key field");
            }
            
            type.ShortName = agencyType.ShortName;
            type.Name = agencyType.Name;

            _db.AgencyType.Update(type);
            await _db.SaveChangesAsync();
            return Ok("Object updated successfully");
        }

        //[Authorize(Roles = "admin")]
        [HttpDelete]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(AgencyType agencyType)
        {
            // TODO Засунуть эти проверки в отдельный метод            
            if (agencyType == null)
            {
                return BadRequest("Object is null");
            }

            var type = _db.AgencyType.Find(agencyType.Id);

            if (type == null)
            {
                return BadRequest("Object not found. Check key field");
            }

            _db.AgencyType.Remove(type);
            await _db.SaveChangesAsync();
            return Ok("Object deleted successfully");
        }





        public async Task<IActionResult> Index()
        {
            return View(await _db.AgencyType.Include(a => a.Agencies).ToListAsync());
        }


    }
}
