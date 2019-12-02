using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
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
        public IActionResult GroupID(int id)
        {
            var groupID = allGroups.Where(a => a.Id == id);
            return Json(groupID);
        }
    }
}