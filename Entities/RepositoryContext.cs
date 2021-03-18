using Microsoft.EntityFrameworkCore;
using playlist_app_backend.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playlist_app_backend.Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        public RepositoryContext(DbContextOptions dbContextOptions) : base (dbContextOptions) 
        {
        }
    }
}
