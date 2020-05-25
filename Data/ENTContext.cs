using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTask.Data
{
    public class ENTContext : DbContext
    {

            public ENTContext(DbContextOptions<ENTContext> options)
                : base(options)
            {
            }

            public DbSet<TeledocTask.Models.Entity> Entity { get; set; }

    }
}
