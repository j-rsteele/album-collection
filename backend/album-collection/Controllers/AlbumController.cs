using album_collection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AlbumController : ControllerBase
    {
        private AlbumContext _context;

        public AlbumController(AlbumContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Album>> Get()
        {
            return _context.Albums.ToList();
        }

        [HttpPost]
        public ActionResult<IEnumerable<Album>> Post([FromBody] Album album)
        {
            var albumTable = _context.Albums;
            albumTable.Add(album);
            _context.SaveChanges();

            return _context.Albums.ToList();         
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Album>> Delete(int id)
        {
            var album = _context.Albums.Find(id);
            _context.Albums.Remove(album);
            _context.SaveChanges();

            return _context.Albums.ToList();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Album>> Put(int id, [FromBody]Album album)
        {
            if(album.Id == id)
            {
                _context.Albums.Update(album);
                _context.SaveChanges();
            }

            return _context.Albums.ToList();
        }


    }
}
