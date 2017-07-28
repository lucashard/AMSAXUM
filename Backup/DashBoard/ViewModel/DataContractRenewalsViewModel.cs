using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DashBoard.ViewModel
{
    public class DataContractRenewalsViewModel
    {
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

    public class DataContractRenewalsVm
    {
        public List<DataContractRenewalsViewModel> List=new List<DataContractRenewalsViewModel>();
        [DisplayName("Business")]
        public string Business { get; set; }
    }
}