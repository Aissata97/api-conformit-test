using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProgrammationConformit.Infrastructures;
using TestProgrammationConformit.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProgrammationConformit.Controllers
{
    [Route("api/[controller]")]
    public class EvenementController : ControllerBase
    {
        private readonly ConformitContext _context;

        public EvenementController(ConformitContext context)
        {
            //_context = context;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/evenement
        [HttpGet]
        public IEnumerable<Evenement> Get()
        {
            var listEvenement = _context.Evenements.ToList();
            return listEvenement;
        }

        // GET api/evement/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evenement = _context.Evenements.Find(id);

            if (evenement == null)
            {
                return NotFound("Evenement non trouvée !");
            }
            return Ok(evenement);
        }

        // POST api/evenement
        [HttpPost]
        public IActionResult Post([FromBody] Evenement evenement)
        {
            if (evenement.Titre.Length > 100)
            {
                return BadRequest("Le titre ne peut pas depasser 100 caractères");
            }

            _context.Add(evenement);
            _context.SaveChanges();

            return CreatedAtRoute(new { id = evenement.Id }, evenement);
        }

        // PUT api/evenement/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Evenement evenement)
        {
            var evenementToUpdate = _context.Evenements.Find(id);
            if (evenementToUpdate == null)
            {
                return NotFound("Evenement non trouvée !");
            }

            evenementToUpdate.Titre = evenement.Titre;
            evenementToUpdate.Description = evenement.Description;
            evenementToUpdate.Organisateur = evenement.Organisateur;

            _context.Update(evenementToUpdate);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evenementBd = _context.Evenements.Find(id);
            var listCommentaires = evenementBd.Commentaires;

            if (evenementBd == null)
            {
                return BadRequest("Evenement non trouvée !");
            }

            //Si l'evènement a des commentaires....
            if (listCommentaires.Count > 0)
            {
                listCommentaires.Clear();
            }

            _context.Evenements.Remove(evenementBd);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
