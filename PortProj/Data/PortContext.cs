using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PortProj.Data
{
    public class PortContext : DbContext
    {
        public PortContext(DbContextOptions<PortContext> options) : base(options)
        { }
        public DbSet<Users> PortUsers { get; set; }
        public DbSet<Slot> PortSlots { get; set; }
    }
}
