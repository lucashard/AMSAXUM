﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashBoard.ViewModel;
using Modelo.Entity;

namespace DashBoard.Models.Interface
{
    public interface IContractRenew
    {
        void Import();
        void AddPending(DataContractRenewalsViewModel dataContract);
        void AddContract(DataContractRenewalsViewModel dataContract);
        void AddContracto(ContractRenewals dataContract);
        void Edit(ContractRenewals contract);
        void Delete(int id);
        DataContractRenewalsViewModel Get();
        IQueryable<ContractRenewals> GetAll();
        DataContractRenewalsViewModel GetPending();
    }
}