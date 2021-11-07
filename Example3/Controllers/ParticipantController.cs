using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ООP_Laba4.Managers.Participants;

namespace ООP_Laba4.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IParticipantManager _manager;

        public ParticipantController(IParticipantManager manager)
        {
            _manager = manager;
        }
        //представления
        [HttpGet]
        public ActionResult CreateParticipant(Guid SportId)
        {
            return View(SportId);
        }
        public async Task<ActionResult> UpdateParticipant(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        //методы, которые будут вызываться на html странице
        [HttpPost]
        public async Task<RedirectToActionResult> Create(Guid SportId, CreateOrUpdateParticipantRequest request)
        {
            var entity = await _manager.AddParticipant(SportId, request);
            return RedirectToAction("AllParticipant", "Sport", new { id = entity.SportId });
        }
        public async Task<RedirectToActionResult> Update(Guid id, CreateOrUpdateParticipantRequest request)
        {
            var entity = await _manager.UpdateParticipant(id, request);
            return RedirectToAction("AllParticipant", "Sport", new { id = entity.SportId });
        }
        public async Task<RedirectToActionResult> Delete(Guid id)
        {
            var SportId = await _manager.DeleteParticipant(id);
            return RedirectToAction("AllParticipant", "Sport", new { id = SportId });
        }
    }
}
