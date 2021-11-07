using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;

namespace ООP_Laba4.Managers.Events
{
    public interface IEventManager
    {
        Task<Event> GetById(Guid id);
        Task<Event> AddEvent(CreateOrUpdateEventRequest request);
        Task<Event> UpdateEvent(Guid id, CreateOrUpdateEventRequest request);
        Task<Event> DeleteEvent(Guid id);
        Task<List<Event>> GetAll();
        Task<Event> GetAllSport(Guid id);
    }
}
