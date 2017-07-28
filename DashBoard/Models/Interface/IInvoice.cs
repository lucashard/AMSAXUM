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
        List<InvoiceViewModel> GetAll();
        void Edit(InvoiceViewModel invoice);
        void Delete(int id);
        void DownloadExcel(int startcolumn, int endcolumn, int startrow, int endrow, string sheet, List<InvoiceViewModel> lista);
    }
}
