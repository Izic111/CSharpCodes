﻿using BankApp.Core.DataAccess;
using BankApp.Core.Services;

namespace BankApp.Core.Features
{
    public class PayInMoney
    {
        private IAccountRepository _accountRepository;
        private INotificationService _notificationService;

        public PayInMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            _accountRepository = accountRepository;
            _notificationService = notificationService;
        }

        public void Execute(int intoAccountId, decimal amount)
        {
            var into = _accountRepository.GetAccountById(intoAccountId);

            if (into.FraudulentActivityDectected())
            {
                _notificationService.NotifyFraudlentActivity(into);
                throw new Exception($"Account limit reached you cannot payin at this time");
            }

            else if (amount > 0)
            {
                into.PayIn(amount);
                _accountRepository.Update(into);
                if (into.IsLowBalance())
                {
                    _notificationService.NotifyFundsLow(into);
                }
            }
            else if(amount <= 0)
            {
                throw new InvalidOperationException("Invalid Payin Amount");
            }

            else if(amount > into.balance)
            {
                throw new InvalidOperationException();
            }
            else
            {
                throw new Exception();
            }
            
        }
    }
}
