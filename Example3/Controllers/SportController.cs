using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ООP_Laba4.Managers.Sports;

namespace ООP_Laba4.Controllers
{
    public class SportController : Controller
    {
        private readonly ISportManager _manager;

        public SportController(ISportManager manager)
        {
            _manager = manager;
        }
        //представления
        public ActionResult CreateSport(Guid EventId)
        {
            return View(EventId);
        }
        public async Task<ActionResult> UpdateSport(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        public async Task<ActionResult> AllParticipant(Guid id)
        {
            var entity = await _manager.GetAllPaticipant(id);
            return View(entity);
        }
        //методы, которые будут вызываться на html странице
        public async Task<RedirectToActionResult> Create(Guid EventId, CreateOrUpdateSportRequest request)
        {
            await _manager.AddSport(EventId, request);
            return RedirectToAction("AllSport", "Event", new { id = EventId });
        }
        public async Task<RedirectToActionResult> Update(Guid id, CreateOrUpdateSportRequest request)
        {
            var entity = await _manager.UpdateSport(id, request);
            return RedirectToAction("AllSport", "Event", new { id = entity.EventId });
        }
        public async Task<RedirectToActionResult> Delete(Guid id, Guid EventId)
        {
            await _manager.DeleteSport(id);
            return RedirectToAction("AllSport", "Event", new { id = EventId });
        }
    }
}
