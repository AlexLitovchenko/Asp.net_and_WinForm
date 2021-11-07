using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ООP_Laba4.Storage.Entity;

namespace ООP_Laba4.Managers.Sports
{
    public interface ISportManager
    {
        Task<Sport> AddSport(Guid EventId, CreateOrUpdateSportRequest request);
        Task<Sport> UpdateSport(Guid id, CreateOrUpdateSportRequest request);
        Task<Sport> DeleteSport(Guid id);
        Task<Sport> GetById(Guid id);
        Task<Sport> GetAllPaticipant(Guid id);

    }
}
