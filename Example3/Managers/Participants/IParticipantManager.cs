using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;

namespace ООP_Laba4.Managers.Participants
{
    public interface IParticipantManager
    {
        Task<Participant> AddParticipant(Guid SportId, CreateOrUpdateParticipantRequest request);
        Task<Participant> UpdateParticipant(Guid id, CreateOrUpdateParticipantRequest request);
        Task<Guid> DeleteParticipant(Guid id);
        Task<Participant> GetById(Guid id);
    }
}
