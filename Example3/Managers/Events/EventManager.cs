using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;
using ООP_Laba4.Storage.Migrations;

namespace ООP_Laba4.Managers.Events
{
    public class EventManager : IEventManager
    {
        private readonly SportEventsDataContext _dbContext;

        public EventManager(SportEventsDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        //получаем запись из бд таблица событий
        public async Task<Event> GetById(Guid id)
        {
            return await _dbContext.Event.FirstOrDefaultAsync(g => g.Id == id);
        }
        //добавляем запись в бд таблица событий
        public async Task<Event> AddEvent(CreateOrUpdateEventRequest request)
        {
            var entity = new Event
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
            };
            _dbContext.Event.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //оновляем запись в бд таблица событий
        public async Task<Event> UpdateEvent(Guid id, CreateOrUpdateEventRequest request)
        {
            var entity = await _dbContext.Event.FirstOrDefaultAsync(g => g.Id == id);
            entity.Name = request.Name;
            entity.Date = DateTime.Parse(request.Date);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //удаляем запись в бд таблица Событий
        public async Task<Event> DeleteEvent(Guid id)
        {
            var entity = await _dbContext.Event.FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.Event.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
        //получем все записи из бд таблица Событий
        public async Task<List<Event>> GetAll()
        {
            return await _dbContext.Event.AsNoTracking().ToListAsync();
        }
      
        //получаем все записи названий соревнований таблица Sport
        public async Task<Event> GetAllSport(Guid id)
        {
            var entity = await _dbContext.Event.FirstOrDefaultAsync(g => g.Id == id);
            entity.Sports = await _dbContext.Sport.AsNoTracking().Where(g => g.EventId == id).ToListAsync();
            return entity;
        }
       
    }
}
