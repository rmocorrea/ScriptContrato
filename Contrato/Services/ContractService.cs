using System;
using System.Collections.Generic;
using System.Text;
using Contrato.Entities;

namespace Contrato.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymantService)
        {
            _onlinePaymentService = onlinePaymantService;
        }

        public void ProcessCotract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for(int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }       
        
    }
}
