using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Controllers
{
    public class ArtistController : Controller
    {
        ArtistController()
        {

        }

        public IActionResult <List<Artist>> Get()
        {
            return _db.Artists.ToList();
        }
    }
}
