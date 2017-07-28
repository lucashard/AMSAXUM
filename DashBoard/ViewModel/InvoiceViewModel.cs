using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DashBoard.ViewModel
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        [DisplayName("Sent To Account")]
        public string SentToAccount  { get; set; }
        [DisplayName("Company")]
        public string Company { get; set; }
        [DisplayName("Year Filed")]
        public string YearFiled { get; set; }
        [DisplayName("Claim Jul")]
        public decimal? ClaimJul { get; set; }
        [DisplayName("Invoiced Jul")]
        public decimal? InvoicedJul { get; set; }
        [DisplayName("ClaimAug")]
        public decimal? ClaimAug { get; set; }
        [DisplayName("Invoiced Aug")]
        public decimal? InvoicedAug { get; set; }
        [DisplayName("Claim Sep")]
        public decimal? ClaimSep { get; set; }
        [DisplayName("Invoiced Sep")]
        public decimal? InvoicedSep { get; set; }
        [DisplayName("Claim Oct")]
        public decimal? ClaimOct { get; set; }
        [DisplayName("Invoiced Oct")]
        public decimal? InvoicedOct { get; set; }
        [DisplayName("Claim Nov")]
        public decimal? ClaimNov { get; set; }
        [DisplayName("Invoiced Nov")]
        public decimal? InvoicedNov { get; set; }
        [DisplayName("Claim Dec")]
        public decimal? ClaimDec { get; set; }
        [DisplayName("Invoiced Dec")]
        public decimal? InvoicedDec { get; set; }
        [DisplayName("Claim Jan")]
        public decimal? ClaimJan { get; set; }
        [DisplayName("Invoiced Jan")]
        public decimal? InvoicedJan { get; set; }
        [DisplayName("Claim Feb")]
        public decimal? ClaimFeb { get; set; }
        [DisplayName("Invoiced Feb")]
        public decimal? InvoicedFeb { get; set; }
        [DisplayName("Claim Mar")]
        public decimal? ClaimMar { get; set; }
        [DisplayName("Invoiced Mar")]
        public decimal? InvoicedMar { get; set; }
        [DisplayName("Claim Apr")]
        public decimal? ClaimApr { get; set; }
        [DisplayName("Invoiced Apr")]
        public decimal? InvoicedApr { get; set; }
        [DisplayName("Claim May")]
        public decimal? ClaimMay { get; set; }
        [DisplayName("Invoiced May")]
        public decimal? InvoicedMay { get; set; }
        [DisplayName("Claim Jun")]
        public decimal? ClaimJun { get; set; }
        [DisplayName("Invoiced Jun")]
        public decimal? InvoicedJun { get; set; }
        
        public int CountClaimJul { get; set; }
        public int CountClaimAug { get; set; }
        public int CountClaimSep { get; set; }
        public int CountClaimOct { get; set; }
        public int CountClaimNov { get; set; }
        public int CountClaimDec { get; set; }
        public int CountClaimJan { get; set; }
        public int CountClaimFeb { get; set; }
        public int CountClaimMar { get; set; }
        public int CountClaimApr { get; set; }
        public int CountClaimMay { get; set; }
        public int CountClaimJun { get; set; }
    }

    public class InvoiceVm
    {
        public List<InvoiceViewModel> InvoiceViewModel { get; set; }
        [DisplayName("Sent To Account")]
        public string SentToAccount { get; set; }
    }
    
}