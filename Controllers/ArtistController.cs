using System;
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
        // 1.) Create a route for /artists that returns all artists as JSON 

        [HttpGet]
        [Route("artists")]
        public JsonResult ALLARTIST()
        {
            return Json(allArtists);
        }       

        // 2.) Create a route /artists/name/{name} that returns all artists that match the provided name(RealName)

        [HttpGet]
        [Route("/artists/artistname/{name}")]
        public JsonResult ArtistName(string name)
        {
            var Query2 = 
                from artist in allArtists
                where artist.ArtistName == $"{name}"
                select artist;
            return Json(Query2);
        }

        // 3.) Create a route /artists/realname/{name} that returns all artists who real names match the provided name
        [HttpGet]
        [Route("/artists/realname/{name}")]
        public JsonResult RealName(string name)
        {
            var Query3 = 
                from artist in allArtists
                where artist.RealName == $"{name}"
                select artist;
            return Json(Query3);
        }

        // 4.) Create a route /artists/hometown/{town} that returns all artists who are from the provided town
        [HttpGet]
        [Route("/artists/hometown/{town}")]
        public JsonResult Hometown(string town)
        {
            var Query4 = 
                from artist in allArtists
                where artist.Hometown == $"{town}"
                select artist;
            return Json(Query4);
        }

        // 5.) Create a route /artists/groupid/{id} that returns all artists who have a GroupId that matches id
        [HttpGet]
        [Route("/artists/group/{Id}")]
        public JsonResult GroupID(int Id)
        {
            var Query5 = 
                from artist in allArtists
                where artist.GroupId == Id
                select artist;
            return Json(Query5);
        }        
    }
}