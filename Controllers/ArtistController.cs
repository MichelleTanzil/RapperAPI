using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }
        [HttpGet("artists")]
        public IActionResult AllArtists()
        {
            return Json(allArtists);
        }

        [HttpGet]
        [Route("artists/Name/{artist}")]
        public IActionResult ArtistNames(string artist)
        {
            var artistNames = allArtists.Where(a => a.ArtistName.Contains(artist));
            return Json(artistNames);
        }

        [HttpGet]
        [Route("artists/RealName/{artist}")]
        public IActionResult ArtistRealNames(string artist)
        {
            var artistRealNames = allArtists.Where(a => a.RealName.Contains(artist));
            return Json(artistRealNames);
        }
        [HttpGet]
        [Route("artists/Hometown/{town}")]
        public IActionResult ArtistHometown(string town)
        {
            var artistHometown = allArtists.Where(a => a.Hometown == town);
            return Json(artistHometown);
        }
        [HttpGet]
        [Route("artists/GroupId/{id}")]
        public IActionResult ArtistGroup(int id)
        {
            var artistGroup = allArtists.Where(a => a.GroupId == id);
            return Json(artistGroup);
        }

    }
}