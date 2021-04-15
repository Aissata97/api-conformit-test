using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProgrammationConformit.Models
{
    public class Evenement
    {
        public Evenement()
        {
            Commentaires = new HashSet<Commentaire>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Le titre ne peut pas être null"), StringLength(100)]
        public string Titre { get; set; }
        public string Description { get; set; }
        public string Organisateur { get; set; }

        public ICollection<Commentaire> Commentaires { get; set; }
    }
}
