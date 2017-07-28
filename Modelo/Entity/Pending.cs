using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Modelo.Entity
{
    [Table("Pending", Schema = "dbo")]
    public class Pending
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Column1 { get; set; }
        public int? Column2 { get; set; }
        public int? Column3 { get; set; }
        public int? Column4 { get; set; }
        public int? Column5 { get; set; }
        public int? Column6 { get; set; }
        public int? Column7 { get; set; }
        public int? Column8 { get; set; }
        public int? Column9 { get; set; }
        public int? Column10 { get; set; }
        public int? Column11 { get; set; }
        public int? Column12 { get; set; }
        public string Business { get; set; }
    }
}
