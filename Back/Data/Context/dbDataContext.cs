using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class dbDataContext:DbContext
    {
        public dbDataContext(DbContextOptions<dbDataContext> options): base(options)
        { 

        }

        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<PodcastGroup> PodcastGroups { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
