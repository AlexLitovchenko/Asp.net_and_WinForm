using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;
using ООP_Laba4.Storage.Migrations;

namespace ООP_Laba4.Managers.Participants
{
    public class ParticipantManager :IParticipantManager
    {
        private readonly SportEventsDataContext _dbContext;

        public ParticipantManager(SportEventsDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        //добавляем запись в бд таблица участников
        public async Task<Participant> AddParticipant(Guid SportId, CreateOrUpdateParticipantRequest request)
        {
            var entity = new Participant
            {
                Id = Guid.NewGuid(),
                SportId = SportId,
                SurName = request.SurName,
                Name = request.Name,
                LastName = request.LastName,
                Birthday = request.MyDay

            };
            _dbContext.Participant.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //обновляем запись в бд таблица участников
        public async Task<Participant> UpdateParticipant(Guid id, CreateOrUpdateParticipantRequest request)
        {
            var entity = await _dbContext.Participant.FirstOrDefaultAsync(g => g.Id == id);
            entity.SurName = request.SurName;
            entity.Name = request.Name;
            entity.LastName = request.LastName;
            entity.Birthday = request.MyDay;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //удаляем запись из бд таблица участников
        public async Task<Guid> DeleteParticipant(Guid id)
        {
            var entity = await _dbContext.Participant.FirstOrDefaultAsync(g => g.Id == id);
            Guid SportId = entity.SportId;
            _dbContext.Participant.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return SportId;
        }
        public async Task<Participant> GetById(Guid id)
        {
            return await _dbContext.Participant.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
