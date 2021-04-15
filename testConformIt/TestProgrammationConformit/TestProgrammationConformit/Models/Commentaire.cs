using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProgrammationConformit.Models
{
    public class Commentaire
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("EvenementId")]
        public int EvenementId { get; set; }
        [JsonIgnore]
        public Evenement Evenement { get; set; }
    }
}
