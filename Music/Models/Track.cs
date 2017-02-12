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
        [Key]
        public int Id { get; set; }      
        public int AlbumId { get; set; }

        public string Title { get; set; }
        public TimeSpan? Length { get; set; }

        public virtual Album Album { get; set; }

    }
}