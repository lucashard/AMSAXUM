using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashBoard.ViewModel;

namespace DashBoard.Models.Interface
{
   public interface IForecast
    {
        void Import();
        void AddInvoiced(ForecastViewModel invoice);
        ForecastViewModel Get();
    }
}
