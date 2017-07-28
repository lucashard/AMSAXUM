using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Modelo.Entity
{
    [Table("Forecast", Schema = "dbo")]
    public class Forecast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientCategory { get; set; }
        public string ClientStatus { get; set; }
        public string City { get; set; }
        public string AccountManager { get; set; }
        public string Tw { get; set; }
        public string EstHours { get; set; }
        public string FiscalYearEnd { get; set; }
        public string FillingMonth { get; set; }
        public Decimal? YearClaimAmount { get; set; }
        public Decimal? ExpectedExpenditures { get; set; }
        public Decimal? FilledExpenditures { get; set; }
        public Decimal? PotentialExpenditures { get; set; }
        public Decimal? ReturnRate { get; set; }
        public string ContractRate { get; set; }
        public Decimal? ExpectedClaimValue { get; set; }
        public Decimal? ClaimValue { get; set; }
        public Decimal? PotencialClaimValue { get; set; }
        public string Employees { get; set; }
        public string Industry { get; set; }
        public string Potencial { get; set; }
        public string Comments { get; set; }



    }
}
