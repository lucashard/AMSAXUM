using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DashBoard.ViewModel
{
    public class ForecastViewModel
    {
        public int id { get; set; }
        [DisplayName("Client Name")]
        public string ClientName { get; set; }
        [DisplayName("Client Category")]
        public string ClientCategory { get; set; }
        [DisplayName("Client Status")]
        public string ClientStatus { get; set; }
        public string City { get; set; }
        [DisplayName("Account Manager")]
        public string AccountManager { get; set; }
        
        public string Tw { get; set; }
        [DisplayName("Est Hours")]
        public string EstHours { get; set; }
        [DisplayName("Fiscal Year End")]
        public string FiscalYearEnd { get; set; }
        [DisplayName("Filling Month")]
        public string FillingMonth { get; set; }
        [DisplayName("Year Claim Amount")]
        public Decimal? YearClaimAmount { get; set; }
        [DisplayName("Expected Expenditures")]
        public Decimal? ExpectedExpenditures { get; set; }
        [DisplayName("Filled Expenditures")]
        public Decimal? FilledExpenditures { get; set; }
        [DisplayName("Potential Expenditures")]
        public Decimal? PotentialExpenditures { get; set; }
        [DisplayName("Return Rate")]
        public Decimal? ReturnRate { get; set; }
        [DisplayName("Contract Rate")]
        public string ContractRate { get; set; }
        [DisplayName("Expected ClaimValue")]
        public Decimal? ExpectedClaimValue { get; set; }
        public Decimal? ClaimValue { get; set; }
        [DisplayName("Potencial ClaimValue")]
        public Decimal? PotencialClaimValue { get; set; }
        public string Employees { get; set; }
        public string Industry { get; set; }
        public string Potencial { get; set; }
        public string Comments { get; set; }

        public decimal Total { get; set; }
        public int CountTotal { get; set; }
    }

    public class Forecastvm
    {
        public List<ForecastViewModel> ForecastView { get; set; }
        [DisplayName("Client Name")]
        public string ClientName { get; set; }
    }
}