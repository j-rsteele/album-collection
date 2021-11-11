using album_collection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection
{
    public class AlbumContext: DbContext 
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            base.OnConfiguring(Builder);
            string connectionString = @"Server=(localdb)\mssqllocaldb; Database=AlbumProject_11_11; Trusted_Connection=True";
            Builder.UseSqlServer(connectionString).UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
        }

    }


}
