using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext context;

        public MovieController()
        {
            context = new ApplicationDbContext();
        }

    public IEnumerable<Movie> Get()
    {
        var movie = context.Movies.ToList();
        return movie;
    }

    //GET api/values/5
    public IHttpActionResult Get(int id)
    {
        var movie = context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    // POST api/values
    public void Post([FromBody]Movie value)
        {
            // Create movie in db 
            

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // Delete movie from db logic
        }
    }

}