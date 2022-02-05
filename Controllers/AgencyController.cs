using EaTS.Data;
using EaTS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EaTS.Controllers
{
    public class AgencyController : Controller
    {
        public AgencyController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;

        public async Task<IActionResult> Index()
        {
            return View(await _db.Agency.Include(t => t.AgencyType).OrderBy(t => t.DisplayOrder).ToListAsync());
        }

        [HttpPost]
        public bool UpdateOrder([FromBody] dynamic item)
        {
            if (item is not null)
            {
                var type = item.GetType();
                var objString = JsonSerializer.Serialize(item);
                objString = objString.Substring(1, objString.Length - 2);


                string[] arr = objString.Split(',');
                int[] IdCollection = Array.ConvertAll(arr, s => int.Parse(s));
                // привязываем к модели полученные данные
                int position = 0;
                foreach (var id in IdCollection)
                {
                    var obj = _db.Agency.Where(x => x.Id == id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.DisplayOrder = position++;
                    }
                    _db.SaveChanges();
                }
            }
            return true;
        }
    }
}
