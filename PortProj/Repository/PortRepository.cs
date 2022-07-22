using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PortProj.Data;
using PortProj.Models;

namespace PortProj.Repository
{
    public class PortRepository : IPortRepository
    {
        private readonly PortContext _Context;
        private readonly IMapper mapper;

        public PortRepository(PortContext context, IMapper mapper)
        {
            this._Context = context;
            this.mapper = mapper;
        }
        public async Task UpdateSlot(int slotId, SlotsModel slotsModel)
        {
            var slot = await _Context.PortSlots.FindAsync(slotId);
            if (slot != null)
            {
                slot.RUID = slotsModel.RUID;
                slot.status = 0;
                slot.cost = slot.cost + slotsModel.cost;
                slot.Sdate = slotsModel.Sdate;
                slot.Edate = slotsModel.Edate;
                await _Context.SaveChangesAsync();
            }
        }
        public async Task<List<SlotsModel>> GetAvalSlotsAsync()
        {
            var records = await _Context.PortSlots.Where(x => x.status == 1).Select(x => new SlotsModel()
            {
                SlotId = x.SlotId,
                SLUserID=x.SLUserID,
                status = x.status


            }).ToListAsync();
            return records;
        }
        public async Task<UsersModel> AddUserAsync(UsersModel usersModel)
        {
            if (usersModel.usertype == "SL")
            {
                var user = new Users()
                {
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    usertype = usersModel.usertype,
                    StartDate = usersModel.StartDate,
                    EndDate = usersModel.EndDate,
                    cost = usersModel.cost,
                };
                _Context.PortUsers.Add(user);
                await _Context.SaveChangesAsync();
                var slot = new Slot
                {
                    status = 1,
                    SLUserID = user.ID,
                    RUID = 0
                };
                _Context.PortSlots.Add(slot);
                await _Context.SaveChangesAsync();
                return mapper.Map<UsersModel>(user);
            }

            else
            {
                var user = new Users()
                {
                    ID = usersModel.ID,
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    usertype = usersModel.usertype,
                };
                _Context.PortUsers.Add(user);
                await _Context.SaveChangesAsync();
                return mapper.Map<UsersModel>(user);
            };

        }
    }
}
