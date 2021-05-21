using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzhGyak2.AllatokModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SzhGyak2.Controllers
{
    [Route("api/allatok")]
    [ApiController]
    public class AllatokController : ControllerBase
    {
        // GET: api/allatoks
        [HttpGet]
        public IEnumerable<Allatok> Get()
        {
            StudentContext context = new StudentContext();
            return context.Allatoks.ToList();
        }

        // GET api/allatoks/5
        [HttpGet("{id}")]
        public Allatok Get(int id)
        {
            StudentContext context = new StudentContext();
            var keresettAllat = (from x in context.Allatoks
                                where x.AllatSk == id
                                select x).FirstOrDefault();
            return keresettAllat;
        }

        // POST api/<AllatokController>
        [HttpPost]
        public void Post([FromBody] Allatok ujAllat)
        {
            StudentContext context = new StudentContext();
            context.Allatoks.Add(ujAllat);
            context.SaveChanges();
        }

        // PUT api/<AllatokController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AllatokController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentContext context = new StudentContext();
            var törlendőÁllat = (from x in context.Allatoks
                                where x.AllatSk == id
                                select x).FirstOrDefault();
            context.Remove(törlendőÁllat);
            context.SaveChanges();
        }
    }
}
