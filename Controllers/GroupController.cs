using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists = JsonToFile<Artist>.ReadJson();
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }
        [HttpGet("groups")]
        public IActionResult AllGroups()
        {
            return Json(allGroups);
        }

        [HttpGet]
        [Route("groups/Name/{name}")]
        public IActionResult GroupNames(string name)
        {
            var groupNames = allGroups.Where(a => a.GroupName.Contains(name));
            return Json(groupNames);
        }

        [HttpGet]
        [Route("groups/groupid/{id}")]
        [Route("groups/groupid/{id}/{displayArtists}")]
        public IActionResult GroupID(int id, bool displayArtists)
        {
            var groups = allGroups.Where(a => a.Id == id);
            if (displayArtists == true)
            {
                groups = groups.Join(allArtists,
                    g => g.Id,
                    a => a.GroupId,
                    (g, a) => {
                        Console.WriteLine(g);
                        Console.WriteLine(a);
                        g.Members.Add(a); 
                        return g;
                        }
                );
            }
            return Json(groups);
        }
    }
}