using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wefate.Models;

namespace Wefate.Data
{
    public class WefateContext:DbContext
    {
        public WefateContext(DbContextOptions<WefateContext> options)
            : base(options)
        {

        }

        public DbSet<IpAddress> IpAddresses { get; set; }
    }
}
