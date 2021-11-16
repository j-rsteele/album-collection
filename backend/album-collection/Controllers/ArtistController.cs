using album_collection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private AlbumContext _db;
        public ArtistController(AlbumContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> Get()
        {
            return _db.Artists.ToList();
        }
        [HttpPost]
        public ActionResult<IEnumerable<Artist>> Post([FromBody] Artist artist)
        {
            _db.Artists.Add(artist);
            _db.SaveChanges();

            return _db.Artists.ToList();
        }
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Artist>> Put(int id, [FromBody] Artist artist)
        {
            if (artist.Id == id)
            {
                _db.Artists.Update(artist);
                _db.SaveChanges();
            }
            return _db.Artists.ToList();
        }
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Artist>> Delete(int id)
        {
            var artist = _db.Artists.Find(id);
            _db.Artists.Remove(artist);
            _db.SaveChanges();
            return _db.Artists.ToList();
        }
    }
}
