using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public class Band
    {
        public int Id { get; set; }

        [DisplayName("Band Name")]
        public string Name { get; set; }
        public DateTime Formed { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }

    }

    public class BandsContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }

}