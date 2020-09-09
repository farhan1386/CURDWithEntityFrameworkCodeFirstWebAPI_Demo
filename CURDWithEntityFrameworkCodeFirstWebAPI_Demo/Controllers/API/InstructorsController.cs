using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Data;
using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Models;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Controllers.API
{
    public class InstructorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Instructors
        public IQueryable<Instructor> GetInstructors()
        {
            return db.Instructors;
        }

        // GET: api/Instructors/5
        [ResponseType(typeof(Instructor))]
        public IHttpActionResult GetInstructor(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(instructor);
        }

        // PUT: api/Instructors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstructor(int id, Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instructor.Id)
            {
                return BadRequest();
            }

            db.Entry(instructor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Instructors
        [ResponseType(typeof(Instructor))]
        public IHttpActionResult PostInstructor(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instructors.Add(instructor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instructor.Id }, instructor);
        }

        // DELETE: api/Instructors/5
        [ResponseType(typeof(Instructor))]
        public IHttpActionResult DeleteInstructor(int id)
        {
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }

            db.Instructors.Remove(instructor);
            db.SaveChanges();

            return Ok(instructor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstructorExists(int id)
        {
            return db.Instructors.Count(e => e.Id == id) > 0;
        }
    }
}