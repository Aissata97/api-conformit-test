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
    public class CommentaireController : ControllerBase
    {
        private readonly ConformitContext _context;

        public CommentaireController(ConformitContext context)
        {
           _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: api/commentaire
        [HttpGet]
        public IEnumerable<Commentaire> Get()
        {
            var listCommentaire = _context.Commentaires.ToList();
            return listCommentaire;
        }

        // GET api/commentaire/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var commentaire = _context.Commentaires.Find(id);

            if (commentaire == null)
            {
                return NotFound("Commentaire non trouvé !");
            }

            return Ok(commentaire);
        }

        // POST api/commentaire
        [HttpPost]
        public IActionResult Post([FromBody] Commentaire commentaire)
        {

            commentaire.Date = DateTime.Now;
            _context.Add(commentaire);
            _context.SaveChanges();


            return CreatedAtRoute(new { id = commentaire.Id, date = commentaire.Date.ToString("D")}, commentaire);
        }

        // PUT api/commentaire/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentaireToUpdate = _context.Commentaires.Find(id);
            if (commentaireToUpdate == null)
            {
                return NotFound("Commentaire non trouvée !");
            }

            commentaireToUpdate.Description = commentaire.Description;

            _context.Update(commentaireToUpdate);
            _context.SaveChanges();

            return NoContent();

        }

        // DELETE api/commentaire/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var commentaireBd = _context.Commentaires.Find(id);

            if (commentaireBd == null)
            {
                return NotFound("Commentaire non trouvée !");
            }

            _context.Commentaires.Remove(commentaireBd);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
