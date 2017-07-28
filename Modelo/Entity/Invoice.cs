using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Modelo.Entity
{
    [Table("Invoice", Schema = "dbo")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SentToAccount { get; set; }
        public string Company { get; set; }
        public string YearFiled { get; set; }
        public decimal? ClaimJul { get; set; }
        public decimal? InvoicedJul { get; set; }
        public decimal? ClaimAug { get; set; }
        public decimal? InvoicedAug { get; set; }
        public decimal? ClaimSep { get; set; }
        public decimal? InvoicedSep { get; set; }
        public decimal? ClaimOct { get; set; }
        public decimal? InvoicedOct { get; set; }
        public decimal? ClaimNov { get; set; }
        public decimal? InvoicedNov { get; set; }
        public decimal? ClaimDec { get; set; }
        public decimal? InvoicedDec { get; set; }
        public decimal? ClaimJan { get; set; }
        public decimal? InvoicedJan { get; set; }
        public decimal? ClaimFeb { get; set; }
        public decimal? InvoicedFeb { get; set; }
        public decimal? ClaimMar { get; set; }
        public decimal? InvoicedMar { get; set; }
        public decimal? ClaimApr { get; set; }
        public decimal? InvoicedApr { get; set; }
        public decimal? ClaimMay { get; set; }
        public decimal? InvoicedMay { get; set; }
        public decimal? ClaimJun { get; set; }
        public decimal? InvoicedJun { get; set; }

    }
}
