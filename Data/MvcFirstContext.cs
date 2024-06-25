using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFirst.Models;

namespace MvcFirst.Data
{
    public class MvcFirstContext : DbContext
    {
        public MvcFirstContext (DbContextOptions<MvcFirstContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFirst.Models.Places> Places { get; set; } = default!;
    }
}
