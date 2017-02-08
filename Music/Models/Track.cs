using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class Track
    {
        public int Id { get; set; }

        //http://stackoverflow.com/questions/6531671/what-does-principal-end-of-an-association-means-in-11-relationship-in-entity-fr
        [Required]
        public Album Album { get; set; }

        public string Title { get; set; }
        public TimeSpan? Length { get; set; }

    }
}