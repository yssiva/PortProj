using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortProj.Models;

namespace PortProj.Repository
{
   public interface IPortRepository
    {
        Task<List<SlotsModel>> GetAvalSlotsAsync();
        Task<UsersModel> AddUserAsync(UsersModel usersModel);
        Task UpdateSlot(int slotId, SlotsModel slotsModel);
    }
}
