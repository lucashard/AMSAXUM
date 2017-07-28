using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DashBoard.Models.Interface;
using DashBoard.ViewModel;
using Modelo;

namespace DashBoard.Models.Operation
{
    public class Forecast : OperationBase,IForecast
    {
        public void Import()
        {
            var context = new ContextManager();
            foreach (var element in context.Forecast)
            {
                context.Forecast.Remove(element);
            }
            context.SaveChanges();
            var table = ReadExcel(2, 23, 10, 59, 3);
            var forecast=new List<ViewModel.ForecastViewModel>();
            foreach (DataRow row in table.Rows)
            {
                var fore = new ViewModel.ForecastViewModel();
                fore.ClientName = row["colunmn1"].ToString();
                fore.ClientCategory = row["colunmn2"].ToString();
                fore.ClientStatus = row["colunmn3"].ToString();
                fore.City = row["colunmn4"].ToString();
                fore.AccountManager = row["colunmn5"].ToString();
                fore.Tw = row["colunmn6"].ToString();
                fore.EstHours = row["colunmn7"].ToString();
                fore.FiscalYearEnd = row["colunmn8"].ToString();
                fore.FillingMonth=row["colunmn9"].ToString();
                fore.YearClaimAmount =Convert.ToDecimal(row["colunmn10"].ToString().Substring(1).Contains("NA") ||string.IsNullOrEmpty(row["colunmn10"].ToString().Substring(1))? "0": row["colunmn10"].ToString().Replace(" ",String.Empty).Substring(1));
                fore.ExpectedExpenditures = string.IsNullOrEmpty(row["colunmn11"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn11"].ToString().Substring(1).Contains("NA") || string.IsNullOrEmpty(row["colunmn11"].ToString().Substring(1)) ? "0" : row["colunmn11"].ToString().Replace(" ", String.Empty).Substring(1));
                fore.FilledExpenditures = string.IsNullOrEmpty(row["colunmn12"].ToString())?0:Convert.ToDecimal(row["colunmn12"].ToString().Substring(1).Contains("NA") || string.IsNullOrEmpty(row["colunmn12"].ToString().Substring(1)) ? "0" : row["colunmn12"].ToString().Replace(" ", String.Empty).Substring(1));
                fore.PotentialExpenditures = string.IsNullOrEmpty(row["colunmn13"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn13"].ToString().Contains("NA") || string.IsNullOrEmpty(row["colunmn13"].ToString()) ? "0" : row["colunmn13"].ToString().Replace(" ", String.Empty).Substring(1));
                fore.ReturnRate = string.IsNullOrEmpty(row["colunmn14"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn14"].ToString().TrimEnd(Convert.ToChar("%")).Replace(" ", String.Empty));
                fore.ContractRate = row["colunmn15"].ToString();
                fore.ExpectedClaimValue = string.IsNullOrEmpty(row["colunmn16"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn16"].ToString().Substring(1).Contains("-") ? "0" : row["colunmn16"].ToString().Replace(" ", String.Empty).Substring(1));
                fore.ClaimValue = string.IsNullOrEmpty(row["colunmn17"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn17"].ToString().Substring(1).Contains("-") ? "0" : row["colunmn17"].ToString().Replace(" ", String.Empty).Substring(1));
                //VER
                fore.PotencialClaimValue = string.IsNullOrEmpty(row["colunmn18"].ToString()) ? 0 : Convert.ToDecimal(row["colunmn18"].ToString().Substring(1).Contains("-") ? "0" : row["colunmn18"].ToString().Replace(" ", String.Empty).Substring(1));
                fore.Employees= row["colunmn19"].ToString();
                fore.Industry= row["colunmn20"].ToString();
                fore.Potencial= row["colunmn21"].ToString();
                fore.Comments = row["colunmn22"].ToString();
                forecast.Add(fore);
            }
            foreach (ForecastViewModel model in forecast)
            {
                AddInvoiced(model);
            }
        }

        public void AddInvoiced(ViewModel.ForecastViewModel invoice)
        {
             ContextManager contextManager = new ContextManager();
            contextManager.Forecast.Add(new Modelo.Entity.Forecast()
            {
                ClientName = invoice.ClientName,
                Potencial = invoice.Potencial,
                AccountManager = invoice.AccountManager,
                City = invoice.City,
                ClaimValue = invoice.ClaimValue,
                ClientCategory = invoice.ClientCategory,
                ClientStatus = invoice.ClientStatus,
                Comments = invoice.Comments,
                ContractRate = invoice.ContractRate,
                Employees = invoice.Employees,
                YearClaimAmount = invoice.YearClaimAmount,
                FilledExpenditures = invoice.FilledExpenditures,
                FillingMonth = invoice.FillingMonth,
                EstHours = invoice.EstHours,
                Industry = invoice.Industry,
                Tw = invoice.Tw,
                ReturnRate = invoice.ReturnRate,
                ExpectedClaimValue = invoice.ExpectedClaimValue,
                FiscalYearEnd = invoice.FiscalYearEnd,
                PotentialExpenditures = invoice.PotentialExpenditures,
                ExpectedExpenditures = invoice.ExpectedExpenditures,
                PotencialClaimValue = invoice.PotencialClaimValue
            });
            contextManager.SaveChanges();
        }

        public ViewModel.ForecastViewModel Get()
        {
            var fore = new ViewModel.ForecastViewModel();
            fore.Total = Convert.ToInt32((from od in new ContextManager().Forecast
                                          select od.FilledExpenditures).Sum());
            fore.CountTotal = (from od in new ContextManager().Forecast select od.FilledExpenditures).Count(x => x != 0);
            return fore;
        }
    }
}