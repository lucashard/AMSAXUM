using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashBoard.ViewModel;

namespace DashBoard.Models.Interface
{
    public interface IInvoice
    {
        void Import();
        void AddInvoiced(InvoiceViewModel invoice);
        InvoiceViewModel Get();
    }
}
