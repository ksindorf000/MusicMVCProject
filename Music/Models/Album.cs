using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Music.Models
{
    /***********************
     * Search By Album
     *********************/
    public class AlbumSearch
    {
        public string Search { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }

        [DisplayName("Band")]
        public int BandId { get; set; }
        public string Title { get; set; }

        //https://www.mikesdotnetting.com/article/229/conversion-of-a-datetime2-data-type-to-a-datetime-data-type-resulted-in-an-out-of-range-value
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        public virtual Band Band { get; set; }
        public virtual Track Track { get; set; }
    }
}