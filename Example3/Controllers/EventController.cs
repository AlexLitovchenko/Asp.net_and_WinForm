using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using ООP_Laba4.Managers.Events;

namespace ООP_Laba4.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventManager _manager;

        public EventController(IEventManager manager)
        {
            _manager = manager;
        }
        //представления
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        public async Task<ViewResult> Event(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        public ViewResult CreateEvent()
        {
            return View();
        }
        public async Task<ViewResult> UpdateEvent(Guid id)
        {
            var entity = await _manager.GetById(id);
            return View(entity);
        }
        public async Task<ViewResult> AllEvent()
        {
            var entities = await _manager.GetAll();
            return View(entities);
        }
        public async Task<ViewResult> AllSport(Guid id)
        {
            var entity = await _manager.GetAllSport(id);
            return View(entity);
        }
        //методы, которые будут вызываться на html странице
        [HttpPost]
        public async Task<ViewResult> Create(CreateOrUpdateEventRequest request)
        {
            await _manager.AddEvent(request);
            var entity = await _manager.GetAll();
            return View("AllEvent", entity);
        }
        public async Task<ViewResult> Update(Guid id, CreateOrUpdateEventRequest request)
        {
            await _manager.UpdateEvent(id, request);
            var entity = await _manager.GetAll();
            return View("AllEvent", entity);
        }
        public async Task<ViewResult> Delete(Guid id)
        {
            await _manager.DeleteEvent(id);
            var entities = await _manager.GetAll();
            return View("AllEvent", entities);
        }
    }
}
