using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DashBoard.Models.Interface;
using DashBoard.ViewModel;
using Modelo;
using Modelo.Entity;

namespace DashBoard.Models.Operation
{
    public class ContractRenew : OperationBase,IContractRenew
    {
        public void Import()
        {
            var context = new ContextManager();
            foreach (var element in context.Pending)
            {
                context.Pending.Remove(element);
            }
            foreach (var element in context.Contracts)
            {
                context.Contracts.Remove(element);
            }
            context.SaveChanges();
            var table = ReadExcel(2, 14, 7, 21, 5);
            var Pending = new List<DataContractRenewalsViewModel>();
            foreach (DataRow row in table.Rows)
            {
                var contract=new DataContractRenewalsViewModel();
                contract.Business = row["colunmn1"].ToString();
                contract.Column1 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn2"].ToString()) ? "0" : row["colunmn2"].ToString());
                contract.Column2 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn3"].ToString()) ? "0" : row["colunmn3"].ToString());
                contract.Column3 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn4"].ToString()) ? "0" : row["colunmn4"].ToString());
                contract.Column4 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn5"].ToString()) ? "0" : row["colunmn5"].ToString());
                contract.Column5 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn6"].ToString()) ? "0" : row["colunmn6"].ToString());
                contract.Column6 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn7"].ToString()) ? "0" : row["colunmn7"].ToString());
                contract.Column7 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn8"].ToString()) ? "0" : row["colunmn8"].ToString());
                contract.Column8 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn9"].ToString()) ? "0" : row["colunmn9"].ToString());
                contract.Column9 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn10"].ToString()) ? "0" : row["colunmn10"].ToString());
                contract.Column10 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn11"].ToString()) ? "0" : row["colunmn11"].ToString());
                contract.Column11 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn12"].ToString()) ? "0" : row["colunmn12"].ToString());
                contract.Column12 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn13"].ToString()) ? "0" : row["colunmn13"].ToString());
                Pending.Add(contract);
            }

            var Contract = ReadExcel(2, 14, 30, 44, 5);
            var ContractList = new List<DataContractRenewalsViewModel>();
            foreach (DataRow row in Contract.Rows)
            {
                var contract = new DataContractRenewalsViewModel();
                contract.Business = row["colunmn1"].ToString();
                contract.Column1 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn2"].ToString()) ? "0" : row["colunmn2"].ToString());
                contract.Column2 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn3"].ToString()) ? "0" : row["colunmn3"].ToString());
                contract.Column3 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn4"].ToString()) ? "0" : row["colunmn4"].ToString());
                contract.Column4 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn5"].ToString()) ? "0" : row["colunmn5"].ToString());
                contract.Column5 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn6"].ToString()) ? "0" : row["colunmn6"].ToString());
                contract.Column6 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn7"].ToString()) ? "0" : row["colunmn7"].ToString());
                contract.Column7 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn8"].ToString()) ? "0" : row["colunmn8"].ToString());
                contract.Column8 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn9"].ToString()) ? "0" : row["colunmn9"].ToString());
                contract.Column9 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn10"].ToString()) ? "0" : row["colunmn10"].ToString());
                contract.Column10 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn11"].ToString()) ? "0" : row["colunmn11"].ToString());
                contract.Column11 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn12"].ToString()) ? "0" : row["colunmn12"].ToString());
                contract.Column12 = Convert.ToInt32(string.IsNullOrEmpty(row["colunmn13"].ToString()) ? "0" : row["colunmn13"].ToString());
                ContractList.Add(contract);
            }
            ContextManager contextManager = new ContextManager();
            foreach (DataContractRenewalsViewModel elem in Pending)
            {
                AddPending(elem);
            }

            foreach (DataContractRenewalsViewModel elem in ContractList)
            {
                AddContract(elem);
            }
        }

        public void Edit(ContractRenewals contract)
        {
            ContextManager contextManager = new ContextManager();
            contextManager.Entry(contract).State = EntityState.Modified;
            contextManager.SaveChanges();
        }

        public void EditPending(Pending contract)
        {
            ContextManager contextManager = new ContextManager();
            //tocar modidificacion
            //hacer comparacion, viendo la ultima modificacion con lo q esta en la DB y ir comparando de derecha a izquirda
            //segun la deteccion de cambio, poner todos ese digito a la derecha y en contract inverto el digito ese segun la deteccion del mes
            var query = (from context in contextManager.Pending where context.Id == contract.Id select context).SingleOrDefault();
            var query2 = (from context in contextManager.Contracts
                          where context.Business.Equals(contract.Business)
                          select context).SingleOrDefault();
            if (query.Column12 != contract.Column12)
            {
                query.Column12 = contract.Column12;
                query2.Column12 = contract.Column12 == 0 ? 1 : 0;
                contextManager.SaveChanges();
            }
            if (query.Column11 != contract.Column11)
            {
                query.Column11 = contract.Column11;
                query.Column12=contract.Column11;
                var valorcalculado = contract.Column11 == 0 ? 1 : 0;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column10 != contract.Column10)
            {
                query.Column10 = contract.Column10;
                query.Column11 = contract.Column10;
                query.Column12 = contract.Column10;
                var valorcalculado = contract.Column10 == 0 ? 1 : 0;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column9 != contract.Column9)
            {
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column8 != contract.Column8)
            {
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column7 != contract.Column7)
            {
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column6 != contract.Column6)
            {
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column6 = valorcalculado; 
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column5 != contract.Column5)
            {
                query.Column5 = contract.Column5;
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column5 = valorcalculado;
                query2.Column6 = valorcalculado;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column4 != contract.Column4)
            {
                query.Column4 = contract.Column4;
                query.Column5 = contract.Column5;
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column4 = valorcalculado; 
                query2.Column5 = valorcalculado;
                query2.Column6 = valorcalculado;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column3 != contract.Column3)
            {
                query.Column3 = contract.Column3;
                query.Column4 = contract.Column4;
                query.Column5 = contract.Column5;
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column3 = valorcalculado;
                query2.Column4 = valorcalculado;
                query2.Column5 = valorcalculado;
                query2.Column6 = valorcalculado;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column2 != contract.Column2)
            {
                query.Column2 = contract.Column2;
                query.Column3 = contract.Column3;
                query.Column4 = contract.Column4;
                query.Column5 = contract.Column5;
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column2 = valorcalculado; 
                query2.Column3 = valorcalculado;
                query2.Column4 = valorcalculado;
                query2.Column5 = valorcalculado;
                query2.Column6 = valorcalculado;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            if (query.Column1 != contract.Column1)
            {
                query.Column1 = contract.Column1;
                query.Column2 = contract.Column2;
                query.Column3 = contract.Column3;
                query.Column4 = contract.Column4;
                query.Column5 = contract.Column5;
                query.Column6 = contract.Column6;
                query.Column7 = contract.Column7;
                query.Column8 = contract.Column8;
                query.Column9 = contract.Column9;
                query.Column10 = contract.Column9;
                contract.Column11 = contract.Column9;
                contract.Column12 = contract.Column9;
                var valorcalculado = contract.Column9 == 0 ? 1 : 0;
                query2.Column1 = valorcalculado;
                query2.Column2 = valorcalculado;
                query2.Column3 = valorcalculado;
                query2.Column4 = valorcalculado;
                query2.Column5 = valorcalculado;
                query2.Column6 = valorcalculado;
                query2.Column7 = valorcalculado;
                query2.Column8 = valorcalculado;
                query2.Column9 = valorcalculado;
                query2.Column10 = valorcalculado;
                query2.Column11 = valorcalculado;
                query2.Column12 = valorcalculado;
                contextManager.SaveChanges();
            }
            //contextManager.Entry(contract).State = EntityState.Modified;
            contextManager.SaveChanges();
        }
       

        public void AddPending(DataContractRenewalsViewModel dataContract)
        {
            ContextManager contextManager=new ContextManager();
            contextManager.Pending.Add(new Pending()
            {
                Business = dataContract.Business,
                Column1 = dataContract.Column1,
                Column2 = dataContract.Column2,
                Column3 = dataContract.Column3,
                Column4 = dataContract.Column4,
                Column5 = dataContract.Column5,
                Column6 = dataContract.Column6,
                Column7 = dataContract.Column7,
                Column8 = dataContract.Column9,
                Column9 = dataContract.Column9,
                Column10 = dataContract.Column10,
                Column11 = dataContract.Column11,
                Column12 = dataContract.Column12
            });
            contextManager.SaveChanges();
        }


        public void AddContract(DataContractRenewalsViewModel dataContract)
        {
            ContextManager contextManager = new ContextManager();
            contextManager.Contracts.Add(new ContractRenewals()
            {
                Business = dataContract.Business,
                Column1 = dataContract.Column1,
                Column2 = dataContract.Column2,
                Column3 = dataContract.Column3,
                Column4 = dataContract.Column4,
                Column5 = dataContract.Column5,
                Column6 = dataContract.Column6,
                Column7 = dataContract.Column7,
                Column8 = dataContract.Column9,
                Column9 = dataContract.Column9,
                Column10 = dataContract.Column10,
                Column11 = dataContract.Column11,
                Column12 = dataContract.Column12
            });
            contextManager.SaveChanges();
        }


        public void AddContracto(ContractRenewals dataContract)
        {
            ContextManager contextManager = new ContextManager();
            contextManager.Contracts.Add(new ContractRenewals()
            {
                Business = dataContract.Business,
                Column1 = dataContract.Column1,
                Column2 = dataContract.Column2,
                Column3 = dataContract.Column3,
                Column4 = dataContract.Column4,
                Column5 = dataContract.Column5,
                Column6 = dataContract.Column6,
                Column7 = dataContract.Column7,
                Column8 = dataContract.Column9,
                Column9 = dataContract.Column9,
                Column10 = dataContract.Column10,
                Column11 = dataContract.Column11,
                Column12 = dataContract.Column12
            });
            contextManager.SaveChanges();
        }

        public void AddPending(Pending dataContract)
        {
            ContextManager contextManager = new ContextManager();
            contextManager.Pending.Add(new Pending()
            {
                Business = dataContract.Business,
                Column1 = dataContract.Column1,
                Column2 = dataContract.Column2,
                Column3 = dataContract.Column3,
                Column4 = dataContract.Column4,
                Column5 = dataContract.Column5,
                Column6 = dataContract.Column6,
                Column7 = dataContract.Column7,
                Column8 = dataContract.Column9,
                Column9 = dataContract.Column9,
                Column10 = dataContract.Column10,
                Column11 = dataContract.Column11,
                Column12 = dataContract.Column12
            });
            contextManager.SaveChanges();
        }


        public DataContractRenewalsViewModel Get()
        {
            var dtContract=new DataContractRenewalsViewModel();
            dtContract.Column1 = Convert.ToInt32((from od in new ContextManager().Contracts
                select od.Column1).Sum());
            dtContract.Column2 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column2).Sum());
            dtContract.Column3 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column3).Sum());
            dtContract.Column4 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column4).Sum());
            dtContract.Column5 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column5).Sum());
            dtContract.Column6 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column6).Sum());
            dtContract.Column7 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column7).Sum());
            dtContract.Column8 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column8).Sum());
            dtContract.Column9 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                  select od.Column9).Sum());
            dtContract.Column10 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                   select od.Column10).Sum()) ;
            dtContract.Column11 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                   select od.Column11).Sum()) ;
            dtContract.Column12 = Convert.ToInt32((from od in new ContextManager().Contracts
                                                   select od.Column12).Sum());

            return dtContract;
        }


        public DataContractRenewalsViewModel GetPending()
        {
                 var dtContract=new DataContractRenewalsViewModel();
            dtContract.Column1 = Convert.ToInt32((from od in new ContextManager().Pending
                select od.Column1).Sum());
            dtContract.Column2 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column2).Sum()) ;
            dtContract.Column3 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column3).Sum()) ;
            dtContract.Column4 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column4).Sum()) ;
            dtContract.Column5 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column5).Sum()) ;
            dtContract.Column6 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column6).Sum()) ;
            dtContract.Column7 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column7).Sum()) ;
            dtContract.Column8 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column8).Sum()) ;
            dtContract.Column9 = Convert.ToInt32((from od in new ContextManager().Pending
                                                  select od.Column9).Sum()) ;
            dtContract.Column10 = Convert.ToInt32((from od in new ContextManager().Pending
                                                   select od.Column10).Sum()) ;
            dtContract.Column11 = Convert.ToInt32((from od in new ContextManager().Pending
                                                   select od.Column11).Sum()) ;
            dtContract.Column12 = Convert.ToInt32((from od in new ContextManager().Pending
                                                   select od.Column12).Sum()) ;

            return dtContract;
        }



        public IQueryable<ContractRenewals> GetAll()
        {
            var context=new ContextManager();
            IQueryable<ContractRenewals> alList =
                from data in context.Contracts select data;
            return alList;
        }

        public IQueryable<Pending> GetAllPending()
        {
            var context = new ContextManager();
            IQueryable<Pending> alList =
                from data in context.Pending select data;
            return alList;
        }


        public void Delete(int id)
        {
            var context = new ContextManager();
            var todolist = context.Contracts.Find(id);
            context.Contracts.Remove(todolist);
            context.SaveChanges();
        }

        public void DeletePending(int id)
        {
            var context = new ContextManager();
            var todolist = context.Pending.Find(id);
            context.Pending.Remove(todolist);
            context.SaveChanges();
        }


        public List<DataContractRenewalsViewModel> GetAllList()
        {
            var contex = new ContextManager();

            List<DataContractRenewalsViewModel> result = (from con in contex.Contracts
                                              select new DataContractRenewalsViewModel() { Column1 =con.Column1,Column2 = con.Column2,Column3 = con.Column3,Column4 = con.Column4,Column5=con.Column5,Column6 = con.Column6,Column7 = con.Column7,Column8 = con.Column8,Column9 = con.Column9,Column10 = con.Column10,Column11 = con.Column11,Column12 = con.Column12,Business = con.Business}).ToList();
            return result;
        }
    }
}