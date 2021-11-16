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

            modelbuilder.Entity<Artist>().HasData(
                            new Artist() { Id = 1, Name = "Prince", imageUrl = "", Age = 50, recordLabel = "Atlantic Records", Hometown = "Akron" },
                            new Artist() { Id = 2, Name = "AC/DC", imageUrl = "", Age = 50, recordLabel = "Atlantic Records", Hometown = "Akron" },
                            new Artist() { Id = 3, Name = "Kevin Gates", imageUrl = "", Age = 50, recordLabel = "Atlantic Records", Hometown = "Akron" });
            
            modelbuilder.Entity<Album>().HasData(
                            new Album() { Id = 1, Title = "Paisley Park", artistId = 1, Image = "", recordLabel = "Atlantic Records"}, 
                            new Album() { Id = 2, Title = "Highway to Hell", artistId = 2, Image = "", recordLabel = "Atlantic Records"},
                            new Album() { Id = 3, Title = "Isaiah", artistId = 3, Image = "", recordLabel = "Atlantic Records"});

            modelbuilder.Entity<Song>().HasData(
                                new Song() { Id = 1, Title = "Paisley Park", albumId = 1},
                                new Song() { Id = 2, Title = "Highway to Hell", albumId = 2 },
                                new Song() { Id = 3, Title = "Time for That", albumId = 3 });

            modelbuilder.Entity<Review>().HasData(
                            new Review() { Id = 1, Name = "Joe Blow", Content = "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", AlbumId = 1 },
                            new Review() { Id = 2, Name = "Seymour Butts", Content = "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", AlbumId = 2 },
                            new Review() { Id = 3, Name = "Joseph Maninng", Content = "Nunc aliquet bibendum enim facilisis. Tellus orci ac auctor augue mauris augue neque. Massa ultricies mi quis hendrerit do", AlbumId = 3 });

        }

    }


}
