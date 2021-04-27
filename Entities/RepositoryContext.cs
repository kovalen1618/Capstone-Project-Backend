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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PlaylistTag> PlaylistTags { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        public RepositoryContext(DbContextOptions dbContextOptions) : base (dbContextOptions) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tag
            // unique constraint index on Tag.Name
            modelBuilder.Entity<Tag>().HasIndex(tag => tag.Name).IsUnique();

            // PlaylistTag
            // composite primary key for join table
            modelBuilder.Entity<PlaylistTag>()
                .HasKey(plTag => new { plTag.PlaylistId, plTag.TagId });

            modelBuilder.Entity<PlaylistTag>()
                .HasOne(plTag => plTag.Tag)
                .WithMany(tag => tag.PlaylistTags)
                .HasForeignKey(plTag => plTag.TagId);

            modelBuilder.Entity<PlaylistTag>()
                .HasOne(plTag => plTag.Playlist)
                .WithMany(playlist => playlist.PlaylistTags)
                .HasForeignKey(plTag => plTag.PlaylistId);
        }
    }
}
