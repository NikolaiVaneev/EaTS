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
    public class EquipmentTypeController : Controller
    {
        public EquipmentTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        private readonly ApplicationDbContext _db;
        public async Task<IActionResult> Index()
        {
            return View(await _db.EquipmentType.Include(a => a.Classes).ThenInclude(c => c.Equipments).OrderBy(s => s.DisplayOrder).ToListAsync());
        }

        #region Upsert
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {

                return PartialView("_UpsertModal", new EquipmentType());
                //return View(new EquipmentType());
            }
            else
            {
                EquipmentType obj = _db.EquipmentType.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return PartialView("_UpsertModal", obj);
                    //return View(obj);
                }
            }
        }

        //POST - Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EquipmentType obj)
        {
            if (obj.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _db.EquipmentType.Add(obj);
                    await _db.SaveChangesAsync();

                    //   TempData[WC.Success] = "Исполнитель успешно добавлен";
                }
                else
                {
                    //    TempData[WC.Error] = "Ошибка добавления исполнителя";
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _db.EquipmentType.Update(obj);
                    await _db.SaveChangesAsync();

                    //    TempData[WC.Success] = "Исполнитель успешно изменен";
                }
                else
                {
                    //    TempData[WC.Error] = "Ошибка изменения исполнителя";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        [HttpPost]
        public bool UpdateListOrder([FromBody] dynamic item)
        {
            if (item is not null)
            {
                var type = item.GetType();

                var objString = JsonSerializer.Serialize(item);
                // Убираем квадратные скобки
                objString = objString.Substring(1, objString.Length - 2);

                string[] arr = objString.Split(',');
                int[] IdCollection = Array.ConvertAll(arr, s => int.Parse(s));
                // привязываем к модели полученные данные
                int position = 0;
                foreach (var id in IdCollection)
                {
                    var obj = _db.EquipmentType.Where(x => x.Id == id).FirstOrDefault();
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
