using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }
        // 1.) Create a route /groups that returns all groups as JSON
        [HttpGet]
        [Route("groups")]
        public JsonResult AllGroups()
        {
            return Json(allGroups);
        }

        // 2.) Create a route /groups/name/{name} that returns all groups that match the provided name
        [HttpGet]
        [Route("groups/name/{name}")]
        public JsonResult AllGroups(string name)
        {
            var Query2 =
            from groups in allGroups
                where groups.GroupName == $"{name}"
                select groups;
            return Json(Query2);
        }

        // 3.) Create a route /groups/id/{id} that returns all groups with the provided Id value
        [HttpGet]
        [Route("groups/id/{id}")]
        public JsonResult AllGroups(int id)
        {
            var Query3 =
            from groups in allGroups
                where groups.Id == id
                select groups;
            return Json(Query3);
        }
        
        // 4.) (Optional) Add an extra boolean parameter to the group routes called displayArtists that will include members for all Group JSON responses
        [HttpGet]
        [Route("groupname/artist/{GroupId}")]
        public JsonResult DispalyArtists(int GroupId)
        {
            IEnumerable<Artist> Query4 =
            from artist in allArtists
            where artist.GroupId == GroupId
            select artist;
            List<string> musicians = new List<string>();
            foreach (var artist in Query4)
            {
                System.Console.WriteLine("{0}", artist.ArtistName);
                System.Console.WriteLine("**********************************************");
                musicians.Add(artist.ArtistName);
            }
            if (musicians.Count > 1)
            {
                System.Console.WriteLine("We currently know {0} musicians in the group", musicians.Count);
                return Json(Query4);
            }
            else
            {
                return Json(allGroups);
            }
            
        }
    }
}