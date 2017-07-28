using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using DashBoard.Models.Interface;
using DashBoard.ViewModel;
using Modelo;
using Modelo.Entity;

namespace DashBoard.Models.Operation
{
    public class Invoice : OperationBase, IInvoice
    {
        public void Import()
        {
            var context = new ContextManager();
            foreach (var element in context.Invoice)
            {
                context.Invoice.Remove(element);
            }
            context.SaveChanges();
            var table= ReadExcel(2, 28, 20, 51, 4);
            var Invoiced = new List<InvoiceViewModel>();
#if(DEBUG)
            string comma = ConfigurationSettings.AppSettings["dot"];
#else
            string comma = ConfigurationSettings.AppSettings["comma"];
#endif
            foreach (DataRow row in table.Rows)
            {
                var invoice=new InvoiceViewModel();

                invoice.SentToAccount = row["colunmn1"].ToString();
                invoice.Company = row["colunmn2"].ToString();
                invoice.YearFiled = row["colunmn3"].ToString();
                invoice.ClaimJul = string.IsNullOrEmpty(row["colunmn4"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn4"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedJul= string.IsNullOrEmpty(row["colunmn5"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn5"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimAug = string.IsNullOrEmpty(row["colunmn6"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn6"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedAug = string.IsNullOrEmpty(row["colunmn7"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn7"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimSep = string.IsNullOrEmpty(row["colunmn8"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn8"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedSep = string.IsNullOrEmpty(row["colunmn9"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn9"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimOct= string.IsNullOrEmpty(row["colunmn10"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn10"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedOct = string.IsNullOrEmpty(row["colunmn11"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn11"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimNov = string.IsNullOrEmpty(row["colunmn12"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn12"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedNov = string.IsNullOrEmpty(row["colunmn13"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn13"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimDec = string.IsNullOrEmpty(row["colunmn14"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn14"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedDec = string.IsNullOrEmpty(row["colunmn15"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn15"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimJan = string.IsNullOrEmpty(row["colunmn16"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn16"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedJan = string.IsNullOrEmpty(row["colunmn17"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn17"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimFeb= string.IsNullOrEmpty(row["colunmn18"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn18"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedFeb = string.IsNullOrEmpty(row["colunmn19"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn19"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimMar = string.IsNullOrEmpty(row["colunmn20"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn20"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedMar = string.IsNullOrEmpty(row["colunmn21"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn21"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimApr = string.IsNullOrEmpty(row["colunmn22"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn22"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedApr= string.IsNullOrEmpty(row["colunmn23"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn23"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimMay = string.IsNullOrEmpty(row["colunmn24"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn24"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedMay = string.IsNullOrEmpty(row["colunmn25"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn25"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.ClaimJun = string.IsNullOrEmpty(row["colunmn26"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn26"].ToString().Substring(1).Replace(comma, string.Empty));
                invoice.InvoicedJun = string.IsNullOrEmpty(row["colunmn27"].ToString()) ? Convert.ToDecimal("0") : Convert.ToDecimal(row["colunmn27"].ToString().Substring(1).Replace(comma, string.Empty));
                
                
                Invoiced.Add(invoice);
            }

            foreach (InvoiceViewModel elem in Invoiced)
            {
                AddInvoiced(elem);
            }
        }

        public void AddInvoiced(InvoiceViewModel invoice)
        {
            ContextManager contextManager = new ContextManager();
            contextManager.Invoice.Add(new Modelo.Entity.Invoice()
            {
                SentToAccount = invoice.SentToAccount,
                Company = invoice.Company,
                YearFiled = invoice.YearFiled,
                ClaimJul = invoice.ClaimJul,
                InvoicedJul = invoice.InvoicedJul,
                ClaimAug = invoice.ClaimAug,
                InvoicedAug = invoice.InvoicedAug,
                ClaimSep = invoice.ClaimSep,
                InvoicedSep = invoice.InvoicedSep,
                ClaimOct = invoice.ClaimOct,
                InvoicedOct = invoice.InvoicedOct,
                ClaimNov = invoice.ClaimNov,
                InvoicedNov = invoice.InvoicedNov,
                ClaimDec = invoice.ClaimDec,
                InvoicedDec = invoice.InvoicedDec,
                ClaimJan = invoice.ClaimJan,
                InvoicedJan = invoice.InvoicedJan,
                ClaimFeb= invoice.ClaimFeb,
                InvoicedFeb=invoice.InvoicedFeb,
                ClaimMar = invoice.ClaimMar,
                InvoicedMar = invoice.InvoicedMar,
                ClaimApr = invoice.ClaimApr,
                InvoicedApr = invoice.InvoicedApr,
                ClaimMay = invoice.ClaimMay,
                InvoicedMay = invoice.InvoicedMay,
                ClaimJun = invoice.ClaimJun,
                InvoicedJun = invoice.ClaimJun

            });
            contextManager.SaveChanges();
        }


        public InvoiceViewModel Get()
        {
            var invoice=new InvoiceViewModel();
            invoice.ClaimJul = Convert.ToDecimal((from od in new ContextManager().Invoice
                select od.ClaimJul).Sum());
            invoice.InvoicedJul = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.InvoicedJul).Sum());
            invoice.ClaimAug = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimAug).Sum());
            invoice.InvoicedAug = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.InvoicedAug).Sum());
            invoice.ClaimSep= Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimSep).Sum());
            invoice.InvoicedSep = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedSep).Sum());
            invoice.ClaimOct = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimOct).Sum());
            invoice.InvoicedOct = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedOct).Sum());
            invoice.ClaimNov= Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimNov).Sum());
            invoice.InvoicedNov = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedNov).Sum());
            invoice.ClaimDec = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimDec).Sum());
            invoice.InvoicedDec = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedDec).Sum());
            invoice.ClaimJan = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedJan).Sum());
            invoice.InvoicedJan = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedJan).Sum());
            invoice.ClaimFeb = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimFeb).Sum());
            invoice.InvoicedFeb = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedFeb).Sum());
            invoice.ClaimMar = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimMar).Sum());
            invoice.InvoicedMar = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.InvoicedMar).Sum());
            invoice.ClaimApr = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                     select od.ClaimApr).Sum());
            invoice.InvoicedApr = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.InvoicedApr).Sum());
            invoice.ClaimMay = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.ClaimMay).Sum());
            invoice.InvoicedMay = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.InvoicedMay).Sum());
            invoice.ClaimJun = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.ClaimJun).Sum());
            invoice.InvoicedJun = Convert.ToDecimal((from od in new ContextManager().Invoice
                                                  select od.InvoicedJun).Sum());
            invoice.CountClaimJul = (from od in new ContextManager().Invoice select od.ClaimJul ).Count(x=>x!=0);
            invoice.CountClaimAug = (from od in new ContextManager().Invoice select od.ClaimAug).Count(x => x != 0);
            invoice.CountClaimSep = (from od in new ContextManager().Invoice select od.ClaimSep).Count(x => x != 0);
            invoice.CountClaimOct = (from od in new ContextManager().Invoice select od.ClaimOct).Count(x => x != 0);
            invoice.CountClaimNov = (from od in new ContextManager().Invoice select od.ClaimNov).Count(x => x != 0);
            invoice.CountClaimDec = (from od in new ContextManager().Invoice select od.ClaimDec).Count(x => x != 0);
            invoice.CountClaimJan = (from od in new ContextManager().Invoice select od.ClaimJan).Count(x => x != 0);
            invoice.CountClaimFeb = (from od in new ContextManager().Invoice select od.ClaimFeb).Count(x => x != 0);
            invoice.CountClaimMar = (from od in new ContextManager().Invoice select od.ClaimMar).Count(x => x != 0);
            invoice.CountClaimApr = (from od in new ContextManager().Invoice select od.ClaimApr).Count(x => x != 0);
            invoice.CountClaimMay = (from od in new ContextManager().Invoice select od.ClaimMay).Count(x => x != 0);
            invoice.CountClaimJul = (from od in new ContextManager().Invoice select od.ClaimJun).Count(x => x != 0);
            return invoice;
        }
    }
}