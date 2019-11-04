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
    [HttpPost]
    public IHttpActionResult Post([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Movies.Add(movie);
            context.SaveChanges();

            return Ok(movie);

        }

        // PUT api/values/5
        [HttpPut]
        public IHttpActionResult Put(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newMovie = context.Movies.Where(m => m.MovieId == id).FirstOrDefault();

            if(newMovie != null)
            {
                newMovie.MovieId = movie.MovieId;
                newMovie.Title = movie.Title;
                newMovie.Director = movie.Director;
                newMovie.Genre = movie.Genre;

                context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok(newMovie);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            var movie = context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }

}