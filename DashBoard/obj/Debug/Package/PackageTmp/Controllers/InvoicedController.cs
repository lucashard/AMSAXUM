using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using DashBoard.Models.Interface;

namespace DashBoard.Controllers
{
    public class InvoicedController : BaseController
    {
        //
        // GET: /Invoiced/
        
        private IInvoice _invoice;

        public InvoicedController(IInvoice invoice)
        {
            _invoice = invoice;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtainListResult()
        {
            var listaNoa1 = new List<double>();
            var listaFollowUp1 = new List<int>();
            string total=string.Empty;
            var listaDouble1 = new List<double>();
            var get = _invoice.Get();
            #if(DEBUG)
            string comma = ConfigurationSettings.AppSettings["comma"];
            string dot = ConfigurationSettings.AppSettings["dot"];
            char comachar = ',';
            char dotchar = '.';
            #else
            string comma = ConfigurationSettings.AppSettings["dot"];
            string dot = ConfigurationSettings.AppSettings["comma"];
            char comachar='.';
            char dotchar = ',';
            #endif

            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedJul), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedAug), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedSep), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedOct), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedNov), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedDec), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedJan), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedFeb), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedMar), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedApr), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedMay), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaDouble1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.InvoicedJun), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));

            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJul), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimAug), 0)).ToString("N").Count(x=>x==dotchar)==2?Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimAug), 0)).ToString("N"):Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimAug), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimSep), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimSep), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimSep), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimOct), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimOct), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimOct), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimNov), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimNov), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimNov), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimDec), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimDec), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimDec), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJan), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJan), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJan), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimFeb), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimFeb), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimFeb), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMar), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMar), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMar), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimApr), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimApr), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimApr), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMay), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMay), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimMay), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            listaNoa1.Add(Convert.ToDouble(Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJun), 0)).ToString("N").Count(x => x == dotchar) == 2 ? Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJun), 0)).ToString("N") : Convert.ToDouble(System.Math.Round(Convert.ToDouble(get.ClaimJun), 0)).ToString("N").Split(comachar)[0].Replace(dot, comma)));
            
            listaFollowUp1.Add(get.CountClaimJul);
            listaFollowUp1.Add(get.CountClaimAug);
            listaFollowUp1.Add(get.CountClaimSep);
            listaFollowUp1.Add(get.CountClaimOct);
            listaFollowUp1.Add(get.CountClaimNov);
            listaFollowUp1.Add(get.CountClaimDec);
            listaFollowUp1.Add(get.CountClaimJan);
            listaFollowUp1.Add(get.CountClaimFeb);
            listaFollowUp1.Add(get.CountClaimMar);
            listaFollowUp1.Add(get.CountClaimApr);
            listaFollowUp1.Add(get.CountClaimMay);
            listaFollowUp1.Add(get.CountClaimJun);
            
            decimal total2 = Convert.ToDecimal (get.InvoicedJul + get.InvoicedAug + get.InvoicedSep + get.InvoicedOct + get.InvoicedNov +
                                        get.InvoicedDec + get.InvoicedJan);
            total = "$"+total2.ToString("#.###");

            try
            {
                var totalresult = ReadExcel(9, 9,15, 15, 4);

                foreach (var elem in totalresult.AsEnumerable())
                {
                    foreach (var elem1 in elem.ItemArray)
                    {
                        total = elem1.ToString().Substring(0);
                    }
                } 
                
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
            return Json(new {listadouble=listaDouble1,listanoa=listaNoa1.Where(x=>x!=0), listafollowup=listaFollowUp1.Where(x=>x!=0),total=total}, JsonRequestBehavior.AllowGet);
        }
    }
}