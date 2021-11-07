using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;
using ООP_Laba4.Storage.Migrations;

namespace ООP_Laba4.Managers.Sports
{
    public class SportManager :ISportManager
    {
        private readonly SportEventsDataContext _dbContext;

        public SportManager(SportEventsDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        //собавляем запись в бд таблица Спорт
        public async Task<Sport> AddSport(Guid EventId, CreateOrUpdateSportRequest request)
        {
            var entity = new Sport
            {
                Id = Guid.NewGuid(),
                EventId = EventId,
                Kind = request.Kind,
            };
            _dbContext.Sport.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //обновляем запись в бд таблица Спорт
        public async Task<Sport> UpdateSport(Guid id, CreateOrUpdateSportRequest request)
        {
            var entity = await _dbContext.Sport.FirstOrDefaultAsync(g => g.Id == id);
            entity.Kind = request.Kind;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //удаляем запись из бд таблица Спорт
        public async Task<Sport> DeleteSport(Guid id)
        {
            var entity = await _dbContext.Sport.FirstOrDefaultAsync(g => g.Id == id);
            _dbContext.Sport.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }
        //получаем запись из бд таблица Спорт
        public async Task<Sport> GetById(Guid id)
        {
            var entity = await _dbContext.Sport.FirstOrDefaultAsync(g => g.Id == id);
            entity.Event = await _dbContext.Event.AsNoTracking().FirstOrDefaultAsync(g => g.Id == entity.EventId);
            return entity;
        }
        //получаем все записи таблица участников
        public async Task<Sport> GetAllPaticipant(Guid id)
        {
            var entity = await _dbContext.Sport.FirstOrDefaultAsync(g => g.Id == id);
            entity.Participants = await _dbContext.Participant.AsNoTracking().Where(g => g.SportId == entity.Id).ToListAsync();
            entity.Event = await _dbContext.Event.AsNoTracking().FirstOrDefaultAsync(g => g.Id == entity.EventId);
            return entity;
        }
    }
}
