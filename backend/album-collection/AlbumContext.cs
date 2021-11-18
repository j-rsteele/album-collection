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
                            new Artist() { Id = 1, Name = "Prince", imageUrl = "/images/princeartist.jfif", Age = 57, recordLabel = "Columbia Records", Hometown = "Minnesota" },
                            new Artist() { Id = 2, Name = "AC/DC", imageUrl = "/images/ACDCbetter.jpeg", Age = 48, recordLabel = "", Hometown = "Sydney" },
                            new Artist() { Id = 3, Name = "Kevin Gates", imageUrl = "/images/profile.png", Age = 35, recordLabel = "Bread Winners Association", Hometown = "Louisiana" });
            
            modelbuilder.Entity<Album>().HasData(
                            new Album() { Id = 1, Title = "Paisley Park", artistId = 1, Image = "/images/prince.webp", recordLabel = "Atlantic Records"}, 
                            new Album() { Id = 2, Title = "Highway to Hell", artistId = 2, Image = "/images/acdc.jpeg", recordLabel = "EMI"},
                            new Album() { Id = 3, Title = "Isaiah", artistId = 3, Image = "/images/kevingates.jpeg", recordLabel = "Bread Winners Association"});

            modelbuilder.Entity<Song>().HasData(
                                new Song() { Id = 1, Title = "Paisley Park", albumId = 1},
                                new Song() { Id = 2, Title = "Highway to Hell", albumId = 2 },
                                new Song() { Id = 3, Title = "Time for That", albumId = 3 });

            modelbuilder.Entity<Review>().HasData(
                            new Review() { Id = 1, Name = "Joe Blow", Content = "Amazing album.. One of a kind", AlbumId = 1 },
                            new Review() { Id = 2, Name = "Seymour Butts", Content = "Whole albums a classic", AlbumId = 2 },
                            new Review() { Id = 3, Name = "Joseph Maninng", Content = "Incredible beats to every song", AlbumId = 3 });

        }

    }


}
